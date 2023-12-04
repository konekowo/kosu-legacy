using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using BeatmapParser.Exceptions;
using TMPro;
using Unity.SharpZipLib.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SongV2 : MonoBehaviour
{
    [Header("TMP Text Objects")] [SerializeField]
    private TMP_Text TitleText;

    [SerializeField] private TMP_Text ArtistText;
    [SerializeField] private TMP_Text MapperText;

    [Header("Thumbnail Image Object")] [SerializeField]
    private Image image;

    [Header("Buttons")] [SerializeField] private GameObject previewButton;
    [SerializeField] private GameObject downloadButton;
    [SerializeField] private Sprite PauseSprite;
    [SerializeField] private Sprite PlaySprite;
    [SerializeField] private Sprite downloadedSprite;

    [Header("Audio Sources")] [SerializeField]
    private AudioSource audioSource;

    [SerializeField] private AudioSource soundSystem;

    [Header("Loading Screens")] [SerializeField]
    private GameObject previewMusicLoadingBox;

    [SerializeField] private GameObject downloadLoadingBox;
    [SerializeField] private GameObject processingMapLoadingBox;

    [Header("Error Screens")] [SerializeField]
    private GameObject errorScreen;

    [Header("Rhodium Proxy to use (For getting images when you're in a school)")]
    [Header(
        "IMPORTANT: You must have your proxy's prefix in the url (example: [url here]/service/), you must also have a \"/\" at the end of the url.")]
    [Header(
        "You can also use localhost urls, although they would only work if the website that the game is on does not have ssl.")]
    [Header("Example URL:")]
    [Header("https://example-rhodiumproxy.com/service/")]
    [Header("")]
    [SerializeField]
    private bool useProxy;

    [SerializeField] private string localhostRhodiumProxyURL;
    [SerializeField] private string RhodiumProxyURL;

    [HideInInspector] public string Title;
    [HideInInspector] public string Artist;
    [HideInInspector] public string Mapper;
    [HideInInspector] public string minoServerURL;
    [HideInInspector] public string SID;
    [HideInInspector] public bool isAlreadyDownloaded = false;

    private bool isPreviewPlaying;
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken cancellationToken;


    // Start is called when the parent gameobject gets enabled.
    private async void Start()
    {
        checkBeatmapAlreadyDownloaded();
        TitleText.SetText(Title);
        ArtistText.SetText(Artist);
        MapperText.SetText(Mapper);

        var imageURL = "";
#if UNITY_WEBGL && !UNITY_EDITOR
        if (Application.absoluteURL.StartsWith("http://127.0.0.1") || Application.absoluteURL.StartsWith("http://localhost"))
        {
            imageURL = localhostRhodiumProxyURL;
        }
        else
        {
            imageURL = RhodiumProxyURL;
        }
#endif
#if UNITY_EDITOR
        imageURL = localhostRhodiumProxyURL;
#endif
        if (useProxy)
        {
            imageURL += "https://assets.ppy.sh/beatmaps/" + SID + "/covers/cover.jpg";
        }
        else
        {
            imageURL = "https://assets.ppy.sh/beatmaps/" + SID + "/covers/cover.jpg";
        }
        


        var data = UnityWebRequestTexture.GetTexture(imageURL);
        Debug.Log("Image Url: " + data.url);
        await data.SendWebRequest();
        if (data.result == UnityWebRequest.Result.Success)
        {
            var texture = data.downloadHandler as DownloadHandlerTexture;
            var sprite = Sprite.Create(texture.texture, new Rect(0f, 0f, texture.texture.width, texture.texture.height),
                new Vector2(0.5f, 0.5f));
            image.sprite = sprite;
        }
        else
        {
            Debug.LogError("Could not get thumbnail image for beatmap. Error: " + data.error);
        }
    }

    private void checkBeatmapAlreadyDownloaded()
    {
        
        string[] dbFile = File.ReadAllLines(Application.persistentDataPath+"/beatmaps.kosudb");
        for (int i = 0; i < dbFile.Length; i++)
        {
            BeatmapsDB beatmapsDB = new BeatmapsDB();
            beatmapsDB.strToObj(dbFile[i]);
            if (beatmapsDB.SID == SID)
            {
                isAlreadyDownloaded = true;
                downloadButton.GetComponent<Image>().color = new Color(255, 218, 0);
                downloadButton.GetComponent<Button>().interactable = false;
                downloadButton.transform.GetChild(0).GetComponent<Image>().sprite = downloadedSprite;
                break;
            }
        }
    }


    public void downloadBeatmap()
    {
        downloadButton.GetComponent<Button>().interactable = false;
        downloadLoadingBox.SetActive(true);

        processingMapLoadingBox.SetActive(false);
        checkBeatmapAlreadyDownloaded();
    }

    public async void download()
    {
        var path = Application.persistentDataPath + "/Songs/" + SID + " " + Artist + " - " + Title;
        var data = UnityWebRequest.Get(minoServerURL + "d/" + SID);
        data.SendWebRequest();
        if (data.result == UnityWebRequest.Result.Success)
        {
            downloadLoadingBox.SetActive(false);
            processingMapLoadingBox.SetActive(true);
            var results = data.downloadHandler.data;

            try
            {
                Debug.Log("Path: "+ path);
                Debug.Log("URL: "+ minoServerURL + "d/" + SID);
                File.WriteAllBytes(path + ".zip", results);
                Debug.Log("Downloaded Beatmap, uncompressing...");
                ZipUtility.UncompressFromZip(path + ".zip", null, path);
                File.Delete(path + ".zip");
            }
            catch (FileNotFoundException error)
            {
                downloadError(error.Message, SID);
            }
            catch (FileLoadException error)
            {
                downloadError(error.Message, SID);
            }
            catch (DirectoryNotFoundException error)
            {
                downloadError(error.Message, SID);
            }

            Debug.Log("Uncompress done, original zip file deleted.");
            if (Directory.Exists(path))
            {
                try
                {
                    processMap(path, SID);
                }
                catch (BeatMapNotSupportedException e)
                {
                    downloadError(e.Message, SID);
                }

            }

            
        }
        else
        {
            Debug.LogError("Could not donwload beatmap. Error: " + data.error);
        }
    }


    public static void processMap(string path, string SID)
    {
        // Process beatmap
        
        // check if beatmap is in correct format
        string[] files = Directory.GetFiles(path);
        bool wrongFormat = false;
        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].EndsWith(".osu"))
            {
                if (!File.ReadAllLines(files[i])[0].StartsWith("osu file format v14") && !File.ReadAllLines(files[i])[0].StartsWith("osu file format v13")
                    && !File.ReadAllLines(files[i])[0].StartsWith("osu file format v12"))
                {
                    Debug.LogError("Beatmap is not in correct format, deleting!");
                    wrongFormat = true;
                }
            }
            
        }

        for (int i = 0; i < files.Length; i++)
        {
            if (wrongFormat)
            {
                File.Delete(files[i]);
            }
        }

        if (!wrongFormat)
        {
            string textToWrite = File.ReadAllText(Application.persistentDataPath + "/beatmaps.kosudb") + SongSelectCarousel.processFolder(path);
            File.WriteAllText(Application.persistentDataPath + "/beatmaps.kosudb", textToWrite);
        }
        else
        {
            Directory.Delete(path);
            throw new BeatMapNotSupportedException("BeatMap is too old!");
        }
    }

    private void downloadError(string message, string sid)
    {
        var newErrorScreen = Instantiate(errorScreen, errorScreen.transform.parent, false);
        var errorScreenObj = newErrorScreen.GetComponent<SongBrowserError>();
        errorScreenObj.setContent("Beatmap SID: " + sid + "\n" +message);
        errorScreenObj.setTitle("Error when downloading beatmap");
        errorScreenObj.show();
    }


    public async void playMusicPreviewAsync()
    {
        if (isPreviewPlaying)
        {
            cancellationTokenSource.Cancel();
            audioSource.Pause();
            soundSystem.Play();
            previewButton.transform.GetChild(0).GetComponent<Image>().sprite = PlaySprite;
            isPreviewPlaying = false;
        }
        else
        {
            var previewURL = "";
#if UNITY_WEBGL && !UNITY_EDITOR
        if (Application.absoluteURL.StartsWith("http://127.0.0.1") || Application.absoluteURL.StartsWith("http://localhost"))
        {
            previewURL = localhostRhodiumProxyURL;
        }
        else
        {
            previewURL = RhodiumProxyURL;
        }
#endif
#if UNITY_EDITOR
            previewURL = localhostRhodiumProxyURL;
#endif
            if (useProxy)
            {
                previewURL += minoServerURL + "preview/audio/" + SID + "?set=1";
            }
            else
            {
                previewURL = minoServerURL + "preview/audio/" + SID + "?set=1";
            }
            

            previewButton.transform.GetChild(0).GetComponent<Image>().sprite = PauseSprite;
            soundSystem.Pause();
            previewMusicLoadingBox.SetActive(true);
            var data = UnityWebRequestMultimedia.GetAudioClip(previewURL, AudioType.MPEG);
            Debug.Log("Preview Music Url: " + data.url);
            await data.SendWebRequest();
            if (data.result == UnityWebRequest.Result.Success)
            {
                previewMusicLoadingBox.SetActive(false);
                var source = new CancellationTokenSource();
                var token = source.Token;
                cancellationToken = token;
                cancellationTokenSource = source;
                var audioPreview = DownloadHandlerAudioClip.GetContent(data);
                audioSource.clip = audioPreview;

                isPreviewPlaying = true;
                audioSource.Play();
                await UniTask.Delay(Mathf.RoundToInt(audioPreview.length * 1000), cancellationToken: token);
                soundSystem.Play();
                audioSource.Pause();
                previewButton.transform.GetChild(0).GetComponent<Image>().sprite = PlaySprite;
                isPreviewPlaying = false;
            }
            else
            {
                soundSystem.Play();
                previewButton.transform.GetChild(0).GetComponent<Image>().sprite = PlaySprite;
                isPreviewPlaying = false;
                Debug.LogError("Could not get preview music. Error: " + data.error);
            }
        }
    }
}