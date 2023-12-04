using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BeatmapParser.HitObjData;
using UnityEditor;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.XR;

public class HitCircle : MonoBehaviour
{
    public float ApproachRate = 0.0f;
    public float CircleSize = 2.0f;
    public float OverallDifficulty = 0.0f;
    private float alpha = 0.0f;
    private float alpha2 = 1f;
    private float apprachCircleSize = 1.0f;
    public SongLoader songLoader;
    public HitCircleData hitData;
    private float increaseAlphaRate = 0.1f;
    private float calculatedCSPixels;
    public GameObject Cursor;

    public float hitwindow300;
    public float hitwindow100;
    public float hitwindow50;

    public bool clicked = false;
    public long hitError;
    public bool missed = false;
    
    private Animator hitScore;

    // Start is called before the first frame update
    private void Start()
    {
        hitScore = gameObject.transform.GetChild(11).gameObject.GetComponent<Animator>();
        hitwindow300 = 80 - 6 * OverallDifficulty;
        hitwindow100 = 140 - 8 * OverallDifficulty;
        hitwindow50 = 200 - 10 * OverallDifficulty;
        
        
        apprachCircleSize = gameObject.transform.GetChild(2).localScale.x;

        calculatedCSPixels = (54.4f - 4.48f * CircleSize) / 60;

        gameObject.transform.localScale = new Vector3(calculatedCSPixels, calculatedCSPixels, calculatedCSPixels);

        gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        
        
        if (ApproachRate < 5.0f)
            increaseAlphaRate = 800 + 400 * (5 - ApproachRate) / 5;
        else if (ApproachRate == 5.0f)
            increaseAlphaRate = 800;
        else
            increaseAlphaRate = 800 - 500 * (ApproachRate - 5) / 5;
        increaseAlphaRate /= 255;
        increaseAlphaRate /= 100;
        
        
        fadeIn();
        circleApproach();
    }

    private void fadeIn()
    {
        
        
        InvokeRepeating("fadeInAnimation", 0.0f, increaseAlphaRate);
    }

    private void fadeInAnimation()
    {
        alpha += 0.05f;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (i != 10 && i != 11)
            {
                if (i != 9)
                {
                    gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.r,
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.g,
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.b, alpha);
                }
                else
                {
                    gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.r,
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.g,
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.b, 
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.a + 0.013f);
                }
            }
            
        }
        if (alpha > 1f) CancelInvoke("fadeInAnimation");
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

    private async void circleApproachAnimation()
    {
        apprachCircleSize -= 0.02f;
        gameObject.transform.GetChild(2).localScale =
            new Vector3(apprachCircleSize, apprachCircleSize, apprachCircleSize);
        if (gameObject.transform.GetChild(2).localScale.x < 1.0f)
        {
            CancelInvoke("circleApproachAnimation");
            
            
            await UniTask.Delay(Mathf.RoundToInt(hitwindow50));
            if (!clicked)
            {
                missed = true;
                hitScore.SetTrigger("miss");
                disableCircle();
            }
            
        }
    }


    public async void unHideOsuObject(int ms)
    {
        songLoader = GameObject.Find("SongLoader").GetComponent<SongLoader>();
        while (!songLoader.startSongButtonHasBeenClicked) await UniTask.Delay(100);
        await UniTask.Delay(ms + songLoader.noteOffset);
        if (Application.isPlaying) gameObject.SetActive(true);
    }

    private void disableCircle()
    {
        gameObject.transform.GetChild(11).transform.parent = null;
        InvokeRepeating("disableAnim", 0.0f, 0.01f);
        
    }

    private void disableAnim()
    {
        alpha2 -= 0.07f;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (i != 10 && i != 11)
            {
                if (i != 9)
                {
                    gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.r,
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.g,
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.b, alpha2);
                }
                else
                {
                    gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.r,
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.g,
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.b,
                        gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color.a - 0.04f);
                }
            }
        }

        if (!missed)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.02f,
                gameObject.transform.localScale.y + 0.02f, gameObject.transform.localScale.z + 0.02f);
        }
        
        
        if (alpha2 < 0)
        {
            CancelInvoke("disableAnim");
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) &&
            Cursor.GetComponent<CursorScript>().colliding.transform.parent.gameObject.Equals(gameObject) && !clicked && !missed)
        {
          

            clicked = true;

            long hitms = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - songLoader.startTime;
            if (hitms > hitData.time)
            {
                hitError = hitms - hitData.time;
            }
            else
            {
                hitError = hitData.time - hitms;
            }

            missed = false;

            disableCircle();

            
            
            if (hitError <= hitwindow300)
            {
                Debug.Log("300");
            }
            if (hitError > hitwindow300 && hitError <= hitwindow100)
            {
                hitScore.SetTrigger("100");
            }
            if (hitError > hitwindow100 && hitError <= hitwindow50)
            {
                hitScore.SetTrigger("50");
            }

            try
            {
                gameObject.transform.GetChild(11).transform.parent = null;
            }
            catch
            {
                
            }






        }
        
    }
}