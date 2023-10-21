using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using System.IO;
using Unity.SharpZipLib.Utils;
using System;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using System.Threading;

public class SongSelectCarousel : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void audioPlay(string audioFileDataBase64);

    [DllImport("__Internal")]
    private static extern void audioPause();

    [DllImport("__Internal")]
    private static extern void audioUnPause();

    [DllImport("__Internal")]
    private static extern void audioSetTime(float time);

    [DllImport("__Internal")]
    private static extern string audioMakeBlob(string audioFileDataBase64, float time, string parentObjectName,
        bool isSongSelect);

    public GameObject songObject;
    private int yCount = 0;

    public bool mouse_over = false;

    public GameObject selectedSong;

    public GameObject SoundSystemPrefab;
    public GameObject LoadingScreen;

    //public GameObject songContainer;

    // Start is called before the first frame update

    public void SongClick(GameObject gameobject)
    {
        if (GameObject.Find("SoundSystem") != null)
            GameObject.Find("SoundSystem").GetComponent<AudioSource>().Pause();
        else
            Debug.LogWarning("Cannot pause audio, sound system does not exist!");
        selectedSong = gameobject;

        for (var i = 0; i < gameObject.transform.childCount; i++)
            gameObject.transform.GetChild(i).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                353.5f, gameObject.transform.GetChild(i).gameObject.GetComponent<RectTransform>().anchoredPosition.y);

        gameobject.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(246.3f, gameobject.GetComponent<RectTransform>().anchoredPosition.y);


        var imgDir = gameobject.transform.GetChild(7).name;
        if (File.Exists(imgDir))
        {
            var imgData = File.ReadAllBytes(imgDir);
            var imageTexture = new Texture2D(2, 2);
            imageTexture.LoadImage(imgData);
            var sprite = Sprite.Create(imageTexture, new Rect(0f, 0f, imageTexture.width, imageTexture.height),
                new Vector2(0.5f, 0.5f));
            GameObject.Find("Seasonal Background").GetComponent<Image>().sprite = sprite;
        }


        GameObject.FindGameObjectWithTag("SelectedSong").GetComponent<SelectedSong>()
            .setStringBackground(gameobject.gameObject.transform.GetChild(7).name);
        GameObject.FindGameObjectWithTag("SelectedSong").GetComponent<SelectedSong>().songName =
            gameobject.transform.GetChild(1).GetComponent<TMP_Text>().text;
        GameObject.FindGameObjectWithTag("SelectedSong").GetComponent<SelectedSong>().SID =
            gameobject.gameObject.transform.GetChild(10).name;
        GameObject.FindGameObjectWithTag("SelectedSong").GetComponent<SelectedSong>().DiffName =
            gameobject.gameObject.transform.GetChild(4).GetComponent<TMP_Text>().text;
        GameObject.FindGameObjectWithTag("SelectedSong").GetComponent<SelectedSong>().Artist =
            gameobject.transform.GetChild(9).GetComponent<TMP_Text>().text;
        GameObject.FindGameObjectWithTag("SelectedSong").GetComponent<SelectedSong>().mapDir =
            gameobject.transform.GetChild(12).name;
        var previewTimeMS = float.Parse(gameobject.gameObject.transform.GetChild(11).name);
        var previewTimeSec = previewTimeMS / 1000;
        LoadingScreen.SetActive(true);
        Debug.Log(gameObject.name);

#if UNITY_EDITOR
        StartCoroutine(getSongPCOnly(gameobject.transform.GetChild(5).name, previewTimeSec));
#else
        byte[] audioData = File.ReadAllBytes(gameobject.transform.GetChild(5).name);
        string base64EncodedAudio = Convert.ToBase64String(audioData);
        audioMakeBlob(base64EncodedAudio, previewTimeSec, gameObject.name, true);
        audioPlay(base64EncodedAudio);
        audioUnPause();
        audioSetTime(previewTimeSec);
#endif

        LoadingScreen.SetActive(false);
    }


    public void playAndDownloadAudio(string url)
    {
        StartCoroutine(getSongPCOnly(url, 0));
    }

    public IEnumerator getSongPCOnly(string url, float time)
    {
#if UNITY_EDITOR
        var mp3Url = "file://" + url;
#else
        string mp3Url = url;
#endif
        var www = UnityWebRequestMultimedia.GetAudioClip(mp3Url, AudioType.MPEG);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var audioClip = DownloadHandlerAudioClip.GetContent(www);

            if (GameObject.Find("SoundSystem") != null)
            {
                GameObject.Find("SoundSystem").GetComponent<AudioSource>().clip = audioClip;
                GameObject.Find("SoundSystem").GetComponent<AudioSource>().Play();
                //GameObject.Find("SoundSystem").GetComponent<AudioSource>().time = time;
            }
            else
            {
                Debug.LogWarning("Cannot play audio, sound system does not exist!");
            }
        }
    }


    private async void Start()
    {
        await UniTask.Delay(1000);
        getAllSongsFromStorage();
    }


    private async void getAllSongsFromStorage()
    {
        var dir = Directory.GetDirectories(Application.persistentDataPath);


        for (var i = 0; i < dir.Length; i++)
        {
            var files = Directory.GetFiles(dir[i]);
            for (var x = 0; x < files.Length; x++)
            {
                var SongID = "";
                var SongTitle = "";
                var SongArtist = "";
                var SongMapper = "";
                var imgDir = "";
                var songDir = "";
                var songFileName = "";
                var difficulty = "";
                var previewTime = "";

                if (files[x].EndsWith(".osu"))
                {
                    var osuFile = File.ReadAllLines(files[x]);
                    for (var y = 0; y < osuFile.Length; y++)
                    {
                        if (osuFile[y].StartsWith("BeatmapSetID:")) SongID = osuFile[y].Split(":")[1];
                        if (osuFile[y].StartsWith("Title:")) SongTitle = osuFile[y].Split(":")[1];
                        if (osuFile[y].StartsWith("Artist:")) SongArtist = osuFile[y].Split(":")[1];
                        if (osuFile[y].StartsWith("Creator:")) SongMapper = osuFile[y].Split(":")[1];
                        if (osuFile[y].StartsWith("//Background and Video events"))
                            imgDir = dir[i] + "/" + osuFile[y + 1].Split(",")[2].Split('"')[1];
                        //Debug.Log(imgDir);
                        if (osuFile[y].StartsWith("AudioFilename"))
                        {
                            songDir = dir[i] + "/" + osuFile[y].Split(": ")[1];
                            songFileName = osuFile[y].Split(": ")[1];
                        }

                        if (osuFile[y].StartsWith("Version:")) difficulty = osuFile[y].Split(":")[1];
                        if (osuFile[y].StartsWith("PreviewTime:")) previewTime = osuFile[y].Split(":")[1];
                    }

                    yCount++;
                    await UniTask.Delay(1);
                    var newSongObject = Instantiate(songObject);
                    newSongObject.GetComponent<RectTransform>()
                        .SetParent(gameObject.transform.GetComponent<RectTransform>());
                    newSongObject.transform.localScale = songObject.transform.localScale;

                    newSongObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                        songObject.GetComponent<RectTransform>().anchoredPosition.x,
                        songObject.GetComponent<RectTransform>().anchoredPosition.y - 72 * yCount + 72);
                    newSongObject.transform.GetChild(1).GetComponent<TMP_Text>().text = SongTitle;
                    newSongObject.transform.GetChild(4).GetComponent<TMP_Text>().text = difficulty;
                    if (File.Exists(imgDir))
                    {
                        var imgData = File.ReadAllBytes(imgDir);
                        var imageTexture = new Texture2D(2, 2);
                        imageTexture.LoadImage(imgData);
                        var sprite = Sprite.Create(imageTexture,
                            new Rect(0f, 0f, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f));
                        newSongObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Image>()
                            .sprite = sprite;
                    }

                    newSongObject.transform.GetChild(5).name = songDir;
                    newSongObject.transform.GetChild(6).name = dir[i];
                    newSongObject.transform.GetChild(7).name = imgDir;
                    newSongObject.transform.GetChild(8).GetComponent<TMP_Text>().text = SongMapper;
                    newSongObject.transform.GetChild(9).GetComponent<TMP_Text>().text = SongArtist;
                    newSongObject.transform.GetChild(10).name = SongID;
                    newSongObject.transform.GetChild(11).name = previewTime;
                    newSongObject.transform.GetChild(12).name = dir[i];
                    //newSongObject.transform.position = new Vector3(newSongObject.transform.position.x, newSongObject.transform.position.y, 0f);
                    newSongObject.SetActive(true);

                    //yield return true;
                    //break;
                }
            }
        }
    }


    private void getAllSongsAndDownload()
    {
        var listString = PlayerPrefs.GetString("BeatmapList").Split(",");
        for (var i = 1; i < listString.Length; i++) StartCoroutine(GetSID(listString[i]));
    }

    private IEnumerator GetSID(string SID)
    {
        using (var data = UnityWebRequest.Get("https://catboy.best/api/search?amount=1&query=" + SID))
        {
            yield return data.SendWebRequest();

            if (data.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error While Fetching Latest Beatmaps: " + data.error);
            }
            else
            {
                Debug.Log("Recieved Latest Beatmaps: " + data.downloadHandler.text);
                afterDownload(data.downloadHandler.text, SID);
            }
        }
    }


    private void afterDownload(string data, string SID)
    {
        var array = JArray.Parse(data);
        foreach (var obj in array.Children<JObject>())
        {
            yCount++;
            var newSongObject = Instantiate(songObject);
            newSongObject.transform.parent = gameObject.transform;
            newSongObject.transform.localScale = songObject.transform.localScale;

            newSongObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                songObject.GetComponent<RectTransform>().anchoredPosition.x,
                songObject.GetComponent<RectTransform>().anchoredPosition.y - 72 * yCount + 72);
            var ImgUrl = "https://rh.konesproxy.ga/service/https://assets.ppy.sh/beatmaps/" + SID + "/covers/cover.jpg";
            if (Application.isEditor)
                ImgUrl = "http://192.168.1.183:8081/service/https://assets.ppy.sh/beatmaps/" + SID +
                         "/covers/cover.jpg";


            StartCoroutine(GetImg(ImgUrl,
                newSongObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Image>()));

            newSongObject.SetActive(true);


            foreach (var singleProp in obj.Properties())
            {
                var name = singleProp.Name;
                var value = singleProp.Value.ToString();


                if (name == "Title")
                {
                    //Debug.Log("Title: " + value);
                    newSongObject.transform.GetChild(1).GetComponent<TMP_Text>().text = value;
                }
                else if (name == "SetID")
                {
                    // Debug.Log("Song ID: " + value);
                    newSongObject.transform.GetChild(4).GetComponent<TMP_Text>().text = value;
                }
                else if (name == "Artist")
                {
                    // Debug.Log("Artist: " + value);
                    //currentSong.GetComponent<Song>().Author = value;
                }
                else if (name == "Creator")
                {
                    // Debug.Log("Mapper: " + value);
                    //currentSong.GetComponent<Song>().Mapper = value;
                }
            }
        }
    }


    private IEnumerator GetImg(string imgurl, Image image)
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

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 &&
            gameObject.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition.y > -37.2f)
            //wheel goes up
            scrollUp();
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && gameObject.transform
                     .GetChild(gameObject.transform.childCount - 1).GetComponent<RectTransform>().anchoredPosition.y <
                 -298f)
            //wheel goes down
            scrollDown();

        for (var i = 1; i < gameObject.transform.childCount; i++)
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<RectTransform>().anchoredPosition.y > 50 ||
                gameObject.transform.GetChild(i).gameObject.GetComponent<RectTransform>().anchoredPosition.y < -370f)
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            else
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
    }

    private float defaultScrollSpeed = 15f;

    private float scrollSpeed = 15f;

    private async void scrollUp()
    {
        scrollSpeed = defaultScrollSpeed;
        if (gameObject.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition.y < 101.7f)
        {
            InvokeRepeating("smoothScrollUp", 0.0f, 0.010f);
            await Task.Delay(200);
            scrollSpeed = defaultScrollSpeed;
            InvokeRepeating("smoothScrollDown", 0.0f, 0.010f);
        }
        else
        {
            InvokeRepeating("smoothScrollUp", 0.0f, 0.010f);
        }
    }

    private async void scrollDown()
    {
        scrollSpeed = defaultScrollSpeed;
        if (gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<RectTransform>()
                .anchoredPosition.y > -120.0f)
        {
            InvokeRepeating("smoothScrollDown", 0.0f, 0.010f);
            await Task.Delay(200);
            scrollSpeed = defaultScrollSpeed;
            InvokeRepeating("smoothScrollUp", 0.0f, 0.010f);
        }
        else
        {
            InvokeRepeating("smoothScrollDown", 0.0f, 0.010f);
        }
    }

    private void smoothScrollUp()
    {
        if (scrollSpeed < 1f) CancelInvoke("smoothScrollUp");
        for (var i = 0; i < gameObject.transform.childCount; i++)
            gameObject.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2(
                gameObject.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x,
                gameObject.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y - scrollSpeed);
        scrollSpeed -= 0.5f;
    }

    private void smoothScrollDown()
    {
        if (scrollSpeed < 1f) CancelInvoke("smoothScrollDown");
        for (var i = 0; i < gameObject.transform.childCount; i++)
            gameObject.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2(
                gameObject.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x,
                gameObject.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y + scrollSpeed);
        scrollSpeed -= 0.5f;
    }
}