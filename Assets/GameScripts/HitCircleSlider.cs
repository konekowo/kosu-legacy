using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class HitCircleSlider : MonoBehaviour
{
    public float ApproachRate = 0.0f;
    public float CircleSize = 2.0f;
    private float alpha = 0.0f;
    private float apprachCircleSize = 1.0f;
    public SongLoader songLoader;
    public string hitObjectLine;
    public GameObject sliderFollow;
    private Vector3 endpos;
    private float distance;
    private float speed;
    private float t;
    private Vector3 startpos;

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
        for (var i = 0; i < 10; i++) gameObject.transform.GetChild(i).gameObject.SetActive(false);


        var slides = int.Parse(hitObjectLine.Split(',')[6]);
        var sliderTime = 0f;
        if (songLoader.currentTimingPoint != "")
        {
            var timingPoint = songLoader.currentTimingPoint.Split(',');
            var splitHitObjectLine = hitObjectLine.Split(',');
            var beatLength = float.Parse(timingPoint[1]);
            var pixelLength = float.Parse(splitHitObjectLine[7]);
            // i have no idea if this is correct, i copied this formula from the javascript pixi.js webosu.
            sliderTime = Mathf.Abs(beatLength * (pixelLength / songLoader.sliderMultiplier) / 100) * 10 * slides;
        }
        else
        {
            var splitHitObjectLine = hitObjectLine.Split(',');
            var pixelLength = float.Parse(splitHitObjectLine[7]);
            // i have no idea if this is correct, i copied this formula from the javascript pixi.js webosu, 
            // and the osu website told me to plug in 1 for SV if there is no inherited timing point but since SV isnt in this formula, I just plugged it into beatLength.
            sliderTime = Mathf.Abs(1 * (pixelLength / songLoader.sliderMultiplier) / 100) * 10 * slides;
        }

        sliderFollow.SetActive(true);
        endpos = new Vector3(gameObject.GetComponent<HitSlider>().xPos, gameObject.GetComponent<HitSlider>().yPos,
            gameObject.GetComponent<HitSlider>().zPos);
        distance = Vector2.Distance(gameObject.transform.position, endpos);
        speed = distance / sliderTime;
        startpos = gameObject.transform.position;
        Debug.Log("Distance: " + distance + ", Speed: " + speed + ", Time: " + sliderTime);
        InvokeRepeating("moveSliderFollow", 0f, 0.001f);
        await UniTask.Delay(Mathf.RoundToInt(sliderTime));
        CancelInvoke("moveSliderFollow");
        gameObject.SetActive(false);
    }

    private void moveSliderFollow()
    {
        t += Time.deltaTime * (speed * 1000); // Increment t based on time and speed.

        // Use Mathf.Clamp01 to ensure t stays between 0 and 1.
        t = Mathf.Clamp01(t);

        // Calculate the new position using Lerp (linear interpolation) between startPoint and endPoint based on t.
        var newPosition = Vector3.Lerp(startpos, endpos, t);
        //Debug.Log(newPosition.x + ", " + newPosition.y + ", " + newPosition.z);

        // Update the GameObject's position to the new position.
        transform.position = newPosition;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}