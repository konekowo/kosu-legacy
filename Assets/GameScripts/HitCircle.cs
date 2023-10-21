using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class HitCircle : MonoBehaviour
{
    public float ApproachRate = 0.0f;
    public float CircleSize = 2.0f;
    private float alpha = 0.0f;
    private float apprachCircleSize = 1.0f;
    public SongLoader songLoader;

    // Start is called before the first frame update
    private void Start()
    {
        //PlayerSettings.WebGL.threadsSupport = true;
        //Debug.Log("Hitcircle enabled");
        apprachCircleSize = gameObject.transform.GetChild(2).localScale.x;

        var calculatedCSPixels = (54.4f - 4.48f * CircleSize) / 60;

        gameObject.transform.localScale = new Vector3(calculatedCSPixels, calculatedCSPixels, calculatedCSPixels);

        gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        fadeIn();
        circleApproach();
    }

    private void fadeIn()
    {
        var increaseAlphaRate = 0.1f;
        if (ApproachRate < 5.0f)
            increaseAlphaRate = 800 + 400 * (5 - ApproachRate) / 5;
        else if (ApproachRate == 5.0f)
            increaseAlphaRate = 800;
        else
            increaseAlphaRate = 800 - 500 * (ApproachRate - 5) / 5;
        increaseAlphaRate /= 255;
        increaseAlphaRate /= 100;
        InvokeRepeating("fadeInAnimation", 0.0f, increaseAlphaRate);
    }

    private void fadeInAnimation()
    {
        alpha += 0.1f;
        gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
        if (alpha > 255) CancelInvoke("fadeInAnimation");
    }

    private void circleApproach()
    {
        var increaseApproachRate = 0.1f;
        if (ApproachRate < 5.0f)
            increaseApproachRate = 1200 + 600 * (5 - ApproachRate) / 5;
        else if (ApproachRate == 5.0f)
            increaseApproachRate = 1200;
        else
            increaseApproachRate = 1200 - 750 * (ApproachRate - 5) / 5;
        increaseApproachRate /= 100000;
        InvokeRepeating("circleApproachAnimation", 0.0f, increaseApproachRate);
    }

    private void circleApproachAnimation()
    {
        apprachCircleSize -= 0.02f;
        gameObject.transform.GetChild(2).localScale =
            new Vector3(apprachCircleSize, apprachCircleSize, apprachCircleSize);
        if (gameObject.transform.GetChild(2).localScale.x < 1.0f)
        {
            CancelInvoke("circleApproachAnimation");
            disableCircle();
        }
    }


    public async void unHideOsuObject(int ms)
    {
        songLoader = GameObject.Find("SongLoader").GetComponent<SongLoader>();
        while (!songLoader.startSongButtonHasBeenClicked) await UniTask.Delay(100);
        await UniTask.Delay(ms + songLoader.noteOffset);
        if (Application.isPlaying) gameObject.SetActive(true);
    }

    private async void disableCircle()
    {
        await UniTask.Delay(100);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}