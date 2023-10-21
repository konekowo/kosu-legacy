using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Unity.SharpZipLib.Utils;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

public class Song : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void audioPause();

    public TMP_Text TextSID;
    public TMP_Text TextTitle;
    public TMP_Text TextMapper;
    public TMP_Text TextAuthor;

    public GameObject LoadingPanel;
    public GameObject previewButton;
    public GameObject downloadButton;

    public Sprite playButton;
    public Sprite pauseButton;
    public Sprite downloadedButtonIcon;

    public GameObject addToBeatMapListButton;

    public Image image;

    public string Title = "";
    public string Author = "";
    public string Mapper = "";
    public string SID = "";

    public bool isPreviewPlaying = false;


    private void Start()
    {
        checkBeatmapAlreadyDownloaded();

        updateData();
        //InvokeRepeating("updateImage", 0, 5);
        updateImage();

        if (PlayerPrefs.HasKey("BeatmapList"))
        {
            var currentStrings = PlayerPrefs.GetString("BeatmapList");
            var currentStringsArray = currentStrings.Split(",");
            for (var i = 0; i < currentStringsArray.Length; i++)
                if (currentStringsArray[i] == SID)
                    addToBeatMapListButton.GetComponent<Button>().interactable = false;
        }
    }

    private void checkBeatmapAlreadyDownloaded()
    {
        var dir = Directory.GetDirectories(Application.persistentDataPath + "/Songs/");
        for (var i = 0; i < dir.Length; i++)
        {
            var files = Directory.GetFiles(dir[i]);
            for (var x = 0; x < files.Length; x++)
                if (files[x].EndsWith(".osu"))
                {
                    var osuFile = File.ReadAllLines(files[x]);
                    for (var y = 0; y < osuFile.Length; y++)
                        if (osuFile[y].StartsWith("BeatmapSetID:"))
                        {
                            var SIDfromFile = osuFile[y].Split(":");
                            if (SIDfromFile[1] == SID)
                            {
                                downloadButton.GetComponent<Button>().interactable = false;
                                downloadButton.GetComponent<Image>().color = new Color(255, 218, 0);
                                downloadButton.transform.GetChild(0).GetComponent<Image>().sprite =
                                    downloadedButtonIcon;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                }
        }
    }


    private void updateData()
    {
        TextSID.text = SID;
        TextTitle.text = Title;
        TextMapper.text = "mapped by " + Mapper;
        TextAuthor.text = Author;
    }

    private void updateImage()
    {
        var ImgUrl = "https://rh.konesproxy.camdvr.org/service/https://assets.ppy.sh/beatmaps/" + SID +
                     "/covers/cover.jpg";
        if (Application.isEditor)
            ImgUrl = "http://192.168.1.183:8081/service/https://assets.ppy.sh/beatmaps/" + SID + "/covers/cover.jpg";


        StartCoroutine(GetLatest(ImgUrl));
    }

    private IEnumerator GetLatest(string imgurl)
    {
        using (var data = UnityWebRequestTexture.GetTexture(imgurl))
        {
            yield return data.SendWebRequest();

            if (data.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error While Fetching Latest Beatmaps: " + data.error);
            }
            else
            {
                //Debug.Log("Recieved Latest Beatmaps: " + data.downloadHandler.text);
                var texture = data.downloadHandler as DownloadHandlerTexture;
                var sprite = Sprite.Create(texture.texture,
                    new Rect(0f, 0f, texture.texture.width, texture.texture.height), new Vector2(0.5f, 0.5f));
                image.sprite = sprite;
            }
        }
    }

    public void addToBeatMapList()
    {
        LoadingPanel.SetActive(true);
        StartCoroutine(DownloadSong());
    }


    public async void playPreview()
    {
        if (isPreviewPlaying)
        {
            pausePreview();
        }
        else
        {
            isPreviewPlaying = true;
            StartCoroutine(GetAudioPreview());
            GameObject.Find("SoundSystem").GetComponent<AudioSource>().Pause();
            previewButton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = pauseButton;
#if !UNITY_EDITOR
audioPause();

#endif

            if (gameObject != null)
            {
                while (!gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    await Task.Delay(2000);
                    var previewClip = gameObject.GetComponent<AudioSource>().clip;
                    var miliseconds = Mathf.RoundToInt(previewClip.length * 1000);
                    await Task.Delay(miliseconds - 2000);
                    pausePreview();
                }
            }
            else
            {
                isPreviewPlaying = false;
                GameObject.Find("SoundSystem").GetComponent<AudioSource>().Play();
            }
        }
    }


    public void pausePreview()
    {
        if (!isPreviewPlaying)
        {
            Debug.LogWarning("The preview is already stopped!");
        }
        else
        {
            isPreviewPlaying = false;
            gameObject.GetComponent<AudioSource>().Pause();
            GameObject.Find("SoundSystem").GetComponent<AudioSource>().Play();
            previewButton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = playButton;
        }
    }

    private IEnumerator GetAudioPreview()
    {
#if UNITY_EDITOR
        var www = UnityWebRequestMultimedia.GetAudioClip(
            "http://192.168.1.183:8081/service/https://b.ppy.sh/preview/" + SID + ".mp3", AudioType.MPEG);
#else
        UnityWebRequest www =
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     UnityWebRequestMultimedia.GetAudioClip("https://rh.konesproxy.camdvr.org/service/https://b.ppy.sh/preview/" +SID+ ".mp3", AudioType.MPEG);
#endif
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var audioPreview = DownloadHandlerAudioClip.GetContent(www);
            gameObject.GetComponent<AudioSource>().clip = audioPreview;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }


    private IEnumerator DownloadSong()
    {
        var www = UnityWebRequest.Get("https://catboy.best/d/" + SID + "n");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var results = www.downloadHandler.data;
            var path = Application.persistentDataPath + "/Songs/" + SID + " - " + Title + ".zip";
            File.WriteAllBytes(path, results);
            Debug.Log("Downloaded Beatmap, uncompressing...");
            ZipUtility.UncompressFromZip(path, null, Application.persistentDataPath + "/Songs/" + SID + " - " + Title);
            File.Delete(path);
            Debug.Log("Uncompress done, original zip file deleted.");
            LoadingPanel.SetActive(false);
            checkBeatmapAlreadyDownloaded();
        }
    }

    private void Update()
    {
    }
}