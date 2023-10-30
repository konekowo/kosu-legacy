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
using Cysharp.Threading.Tasks;
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
    public string currentTimingPoint = "";
    //public List<string> allTimingPoints = new();
    public long startTime;
    public float sliderMultiplier;

    [Header("Song Import Settings")]
    // Used for placing Hit Circles and Sliders
    public float divideAmmount = 10f;

    public Sprite[] num;
    public int noteOffset; // (in miliseconds)
    [Header("Other")] public GameObject songPlayButton;

    public bool startSongButtonHasBeenClicked = false;

    public BeatmapData beatmapData;
    
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
        //var songLines = File.ReadAllLines(filePath);
        beatmapData = new BeatmapParser.BeatmapParser(filePath).GetParsedData();
        string songFilePath = songFolderPath + "/" + beatmapData.AudioFilename;
        


#if UNITY_EDITOR
        StartCoroutine(getSongPCOnly(songFilePath));
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        byte[] audioData = File.ReadAllBytes(songFilePath);
        string base64EncodedAudio = Convert.ToBase64String(audioData);
        audioMakeBlob(base64EncodedAudio, 0, gameObject.name, false);
        audioPlay(base64EncodedAudio);

#endif
        var zPos = 14.0f;
        for (var i = HitObjectsLine + 1; i < songLines.Length; i++)
        {
            var msBeforeObjectHit = 0;

            if (ApproachRate < 5.0f)
                msBeforeObjectHit = Mathf.RoundToInt(1200 + 600 * (5 - ApproachRate) / 5);
            else if (ApproachRate == 5.0f)
                msBeforeObjectHit = 1200;
            else if (ApproachRate > 5.0f) msBeforeObjectHit = Mathf.RoundToInt(1200 - 750 * (ApproachRate - 5) / 5);
            //Debug.Log(songLines[i]);
            //var line = songLines[i].Split(",");
            // ---------- Hit Circle -----------
            if (line.Length == 6)
            {
                var newHitObject = Instantiate(hitObject);

                newHitObject.GetComponent<HitCircle>().ApproachRate = ApproachRate;
                newHitObject.GetComponent<HitCircle>().CircleSize = CircleSize;

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
                var hitY = 0 - (float.Parse(line[1]) / divideAmmount - 4f);


                newHitObject.transform.position = new Vector3(float.Parse(line[0]) / divideAmmount - 5.2f, hitY, zPos);
                zPos += 0.1f;
                if (line[3] == "2" || line[3] == "4" || line[3] == "5" || line[3] == "6") comboCounter = 1;
                newHitObject.GetComponent<HitCircle>().unHideOsuObject(int.Parse(line[2]) - msBeforeObjectHit);
            }

            // ----------------------------------
            // ------------- Slider -------------
            if (line.Length == 11)
            {
                var sliderInfo = line[5].Split("|");
                if (sliderInfo[0].StartsWith('L'))
                {
                    // use hit object for the slider's head
                    var newSliderHitObject = Instantiate(hitSlider);

                    newSliderHitObject.GetComponent<HitCircleSlider>().ApproachRate = beatmapData.ApproachRate;
                    newSliderHitObject.GetComponent<HitCircleSlider>().CircleSize = beatmapData.CircleSize;
                    newSliderHitObject.GetComponent<HitCircleSlider>().hitObjectLine = songLines[i];

                    for (var x = 0; x < 1000; x++)
                        if (comboCounter < 10)
                        {
                            newSliderHitObject.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite =
                                num[comboCounter];
                        }
                        else if (comboCounter < 100)
                        {
                            newSliderHitObject.transform.GetChild(3).gameObject.SetActive(false);
                            newSliderHitObject.transform.GetChild(4).gameObject.SetActive(true);
                            newSliderHitObject.transform.GetChild(5).gameObject.SetActive(true);

                            var numStr = comboCounter.ToString();
                            var firstDigitStr = numStr[1] + " ";
                            var firstDigit = int.Parse(firstDigitStr);
                            var secondDigitStr = numStr[0] + " ";
                            var secondDigit = int.Parse(secondDigitStr);

                            newSliderHitObject.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite =
                                num[firstDigit];
                            newSliderHitObject.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite =
                                num[secondDigit];
                        }

                    comboCounter++;
                    var hitY = 0 - (float.Parse(line[1]) / divideAmmount - 4f);


                    newSliderHitObject.transform.position =
                        new Vector3(float.Parse(line[0]) / divideAmmount - 5.2f, hitY, zPos);
                    zPos += 0.1f;
                    if (line[3] == "2" || line[3] == "4" || line[3] == "5" || line[3] == "6") comboCounter = 1;

                    newSliderHitObject.GetComponent<HitCircleSlider>()
                        .unHideOsuObject(int.Parse(line[2]) - msBeforeObjectHit);

                    // draw slider body
                    var point = sliderInfo[1].Split(':');
                    // convert the x, y coordinates so it's not mirrored or something.
                    //Debug.Log(songLines[i]);

                    var pointX = float.Parse(point[0]) / divideAmmount - 5.2f;
                    var pointY = 0 - (float.Parse(point[1]) / divideAmmount - 4f);
                    newSliderHitObject.GetComponent<HitSlider>().xPos = pointX;
                    newSliderHitObject.GetComponent<HitSlider>().yPos = pointY;
                    newSliderHitObject.GetComponent<HitSlider>().zPos = zPos;
                    newSliderHitObject.GetComponent<HitSlider>().pos = songLines[i];
                }
            }

            // -------------------------------
            // ---------  Spinner  -----------
            if (line.Length == 7)
            {
            }

            songPlayButton.SetActive(true);
            // -------------------------------
        }
    }

    public void startSong()
    {
        songPlayButton.SetActive(false);
        startSongButtonHasBeenClicked = true;

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
        var now = DateTimeOffset.UtcNow;
        var unixTimeMilliseconds = now.ToUnixTimeMilliseconds();
        var msSinceSongStart = unixTimeMilliseconds - startTime;
        var currentTimingPoint = "";
        for (var i = 0; i < allTimingPoints.Count; i++)
        {
            //Debug.Log(allTimingPoints[i].Split(',')[0]);
            var timingPointMS = int.Parse(allTimingPoints[i].Split(',')[0]);
            if (msSinceSongStart > timingPointMS) currentTimingPoint = allTimingPoints[i];
        }

        this.currentTimingPoint = currentTimingPoint;
    }
}