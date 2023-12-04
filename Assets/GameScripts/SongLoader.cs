using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using System;
using BeatmapParser;
using BeatmapParser.HitObjData;
using BeatmapParser.util;
using Cysharp.Threading.Tasks;
using UnityEngine.Rendering;
using UnityEngine.U2D;

public class SongLoader : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void audioPlay(string audioFileDataBase64);

    [DllImport("__Internal")]
    private static extern void audioPause();

    [DllImport("__Internal")]
    private static extern void audioUnPause();

    [DllImport("__Internal")]
    private static extern string audioMakeBlob(string audioFileDataBase64, float time, string parentObjectName,
        bool isSongSelect);

    [Header("Prefabs")] public GameObject hitObject;
    public GameObject soundSystem;
    public GameObject hitSlider;

    [Header("Song if there was one selected in song select")]
    public string songName;

    public string SID;
    public string DiffName;
    public string mapDir;
    [Header("Test Song for Unity Editor")] public string testSongName;
    public string testSID;
    public string testDiffName;
    public string testMapDir;
    [Header("Other Stuff (Do not edit)")] public string correctOsuFile = "";
    public int comboCounter = 1;
    public TimingPoint currentTimingPoint = null;
    //public List<string> allTimingPoints = new();
    public long startTime;
    public float sliderMultiplier;

    [Header("Song Import Settings")]
    // Used for placing Hit Circles and Sliders
    public static float divideAmount = 50f;

    public Sprite[] num;
    public int noteOffset; // (in miliseconds)
    [Header("Other")] public GameObject songPlayButton;

    public bool startSongButtonHasBeenClicked = false;

    public BeatmapData beatmapData;

    public static bool inGameplay = false;

    public GameObject cursor;

    public long mapMS;
    
    private void Start()
    {
#if !UNITY_EDITOR
        audioPause();
#endif
        if (GameObject.FindGameObjectWithTag("SoundSystem") == null) Instantiate(soundSystem);
        GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<AudioSource>().Pause();
        GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<AudioSource>().time = 0;
        if (GameObject.FindGameObjectWithTag("SelectedSong") != null)
        {
            var selectedSong = GameObject.FindGameObjectWithTag("SelectedSong").GetComponent<SelectedSong>();
            songName = selectedSong.songName;
            SID = selectedSong.SID;
            DiffName = selectedSong.DiffName;
            mapDir = selectedSong.mapDir;
        }
        else
        {
            songName = testSongName;
            SID = testSID;
            DiffName = testDiffName;
            mapDir = testMapDir;
        }

        
        
        var osuFile = findCorrectOsuFile();
        correctOsuFile = osuFile;
        readOsuFile(correctOsuFile, mapDir);
    }


    private void readOsuFile(string filePath, string songFolderPath)
    {
        beatmapData = new BeatmapParser.BeatmapParser(filePath).GetParsedData();
        string songFilePath = songFolderPath + "/" + beatmapData.AudioFilename;
        

        // load audio
        #if UNITY_EDITOR || !UNITY_WEBGL
                StartCoroutine(getSongPCOnly(songFilePath));
        #endif

        #if UNITY_WEBGL && !UNITY_EDITOR
                byte[] audioData = File.ReadAllBytes(songFilePath);
                string base64EncodedAudio = Convert.ToBase64String(audioData);
                audioMakeBlob(base64EncodedAudio, 0, gameObject.name, false);
                audioPlay(base64EncodedAudio);

        #endif


        int zIndex = 0;
        float zPos = 15.0f;
        
        var msBeforeObjectHit = 0;
        if (beatmapData.ApproachRate < 5.0f)
            msBeforeObjectHit = Mathf.RoundToInt(1200 + 600 * (5 - beatmapData.ApproachRate) / 5);
        else if (beatmapData.ApproachRate == 5.0f)
            msBeforeObjectHit = 1200;
        else if (beatmapData.ApproachRate > 5.0f) msBeforeObjectHit = Mathf.RoundToInt(1200 - 750 * (beatmapData.ApproachRate - 5) / 5);

        
        
        foreach (HitCircleData hitCircleData in beatmapData.HitCircles)
        {
            var newHitObject = Instantiate(hitObject);

            newHitObject.GetComponent<HitCircle>().ApproachRate = beatmapData.ApproachRate;
            newHitObject.GetComponent<HitCircle>().CircleSize = beatmapData.CircleSize;
            newHitObject.GetComponent<HitCircle>().OverallDifficulty = beatmapData.OverallDifficulty;
            newHitObject.GetComponent<HitCircle>().hitData = hitCircleData;
            newHitObject.GetComponent<HitCircle>().Cursor = cursor;
            
            #region Combo stuff
                for (var x = 0; x < 1000; x++)
                    if (comboCounter < 10)
                    {
                        newHitObject.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = num[comboCounter];
                    }
                    else if (comboCounter < 100)
                    {
                        newHitObject.transform.GetChild(3).gameObject.SetActive(false);
                        newHitObject.transform.GetChild(4).gameObject.SetActive(true);
                        newHitObject.transform.GetChild(5).gameObject.SetActive(true);

                        var numStr = comboCounter.ToString();
                        var firstDigitStr = numStr[1] + " ";
                        var firstDigit = int.Parse(firstDigitStr);
                        var secondDigitStr = numStr[0] + " ";
                        var secondDigit = int.Parse(secondDigitStr);

                        //Debug.Log(firstDigit);
                        //Debug.Log(secondDigit);
                        newHitObject.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = num[firstDigit];
                        newHitObject.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = num[secondDigit];
                    }

                comboCounter++;
            #endregion

            Vector2 hitObjGamePos = hitCircleData.GetGamePosition();


            newHitObject.transform.position = new Vector3(hitObjGamePos.x, hitObjGamePos.y, zPos);
            newHitObject.GetComponent<SortingGroup>().sortingOrder = zIndex;
            zIndex++;
            zPos += 0.1f;
            if (hitCircleData.newCombo) comboCounter = 1;
            //Debug.Log(hitCircleData.time);
            newHitObject.GetComponent<HitCircle>().unHideOsuObject(hitCircleData.time - msBeforeObjectHit);
        }
        
        /*
        foreach (SliderData sliderData in beatmapData.Sliders)
        {
            var newHitObject = Instantiate(hitSlider);

            newHitObject.GetComponent<HitCircleSlider>().ApproachRate = beatmapData.ApproachRate;
            newHitObject.GetComponent<HitCircleSlider>().CircleSize = beatmapData.CircleSize;
            
            #region Combo stuff
            for (var x = 0; x < 1000; x++)
                if (comboCounter < 10)
                {
                    newHitObject.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = num[comboCounter];
                }
                else if (comboCounter < 100)
                {
                    newHitObject.transform.GetChild(3).gameObject.SetActive(false);
                    newHitObject.transform.GetChild(4).gameObject.SetActive(true);
                    newHitObject.transform.GetChild(5).gameObject.SetActive(true);

                    var numStr = comboCounter.ToString();
                    var firstDigitStr = numStr[1] + " ";
                    var firstDigit = int.Parse(firstDigitStr);
                    var secondDigitStr = numStr[0] + " ";
                    var secondDigit = int.Parse(secondDigitStr);

                    //Debug.Log(firstDigit);
                    //Debug.Log(secondDigit);
                    newHitObject.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = num[firstDigit];
                    newHitObject.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = num[secondDigit];
                }

            comboCounter++;
            #endregion
            
            var hitY = 0 - (sliderData.position.y / divideAmount - 4f);


            newHitObject.transform.position = new Vector3(sliderData.position.x / divideAmount - 5.2f, hitY, zPos);
            zPos += 0.1f;
            if (sliderData.newCombo) comboCounter = 1;
            newHitObject.GetComponent<HitCircleSlider>().unHideOsuObject(sliderData.time - msBeforeObjectHit);
            newHitObject.GetComponent<HitSlider>().sliderData = sliderData;


        }
        
        */
        
        foreach (SpinnerData spinnerData in beatmapData.Spinners)
        {
            //TODO
        }


        GameObject.Find("Cursor").GetComponentInChildren<SpriteRenderer>().sortingOrder = zIndex + 1;
        songPlayButton.SetActive(true);
        
        
    }

    public void startSong()
    {
        songPlayButton.SetActive(false);
        startSongButtonHasBeenClicked = true;
        inGameplay = true;
        GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<AudioSource>().Play();
        var now = DateTimeOffset.UtcNow;
        var unixTimeMilliseconds = now.ToUnixTimeMilliseconds();

        startTime = unixTimeMilliseconds;
    }


    public void playAndDownloadAudio(string url)
    {
        StartCoroutine(getSongPCOnly(url));
    }


    private IEnumerator getSongPCOnly(string url)
    {
#if UNITY_EDITOR || UNITY_64
        var mp3Url = "file://" + url;
#else
        string mp3Url = url;
#endif
        var www = UnityWebRequestMultimedia.GetAudioClip(mp3Url, AudioType.MPEG);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var audioClip = DownloadHandlerAudioClip.GetContent(www);

            if (GameObject.FindGameObjectWithTag("SoundSystem") != null)
                GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<AudioSource>().clip = audioClip;
            else
                Debug.LogWarning("Cannot play audio, sound system does not exist!");
        }
    }


    private async void unHideOsuObject(int timeMS, GameObject hitObj)
    {
        while (!startSongButtonHasBeenClicked) await UniTask.Delay(100);
        await UniTask.Delay(timeMS + noteOffset);
        if (Application.isPlaying) hitObj.SetActive(true);
    }


    private string findCorrectOsuFile()
    {
        var songFiles = Directory.GetFiles(mapDir);
        var correctOsuFile = "";
        for (var i = 0; i < songFiles.Length; i++)
            if (songFiles[i].EndsWith(".osu"))
            {
                var songLines = File.ReadAllLines(songFiles[i]);
                for (var x = 0; x < songLines.Length; x++)
                    if (songLines[x].StartsWith("Version:" + DiffName))
                    {
                        correctOsuFile = songFiles[i];
                        break;
                    }
            }

        return correctOsuFile;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().loadSongSelect();
            inGameplay = false;
        }
        var now = DateTimeOffset.UtcNow;
        var unixTimeMilliseconds = now.ToUnixTimeMilliseconds();
        var msSinceSongStart = unixTimeMilliseconds - startTime;
        mapMS = unixTimeMilliseconds - startTime;
        
        TimingPoint currentTimingPoint = null;


        foreach (TimingPoint timingPoint in beatmapData.TimingPoints)
        {
            var timingPointMS = timingPoint.time;
            if (msSinceSongStart > timingPointMS) currentTimingPoint = timingPoint;
        }

        this.currentTimingPoint = currentTimingPoint;
    }

    public void OnDrawGizmos()
    {
        // Playfield
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(OsuPixelsToGameVector.ConvertToGameVector(new Vector2(0,0), Camera.main),
            OsuPixelsToGameVector.ConvertToGameVector(new Vector2(512,384), Camera.main));
        
        Gizmos.DrawLine(OsuPixelsToGameVector.ConvertToGameVector(new Vector2(0,0), Camera.main),
            OsuPixelsToGameVector.ConvertToGameVector(new Vector2(0,384), Camera.main));
        Gizmos.DrawLine(OsuPixelsToGameVector.ConvertToGameVector(new Vector2(0,384), Camera.main),
            OsuPixelsToGameVector.ConvertToGameVector(new Vector2(512,384), Camera.main));
        Gizmos.DrawLine(OsuPixelsToGameVector.ConvertToGameVector(new Vector2(512,384), Camera.main),
            OsuPixelsToGameVector.ConvertToGameVector(new Vector2(512,0), Camera.main));
        Gizmos.DrawLine(OsuPixelsToGameVector.ConvertToGameVector(new Vector2(512,0), Camera.main),
            OsuPixelsToGameVector.ConvertToGameVector(new Vector2(0,0), Camera.main));

        
        
    }
}