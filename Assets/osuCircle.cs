using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osuCircle : MonoBehaviour
{
    public float CS = 2;

    public float multiplyFloat = 0.2f;

    // Start is called before the first frame update
    private void Start()
    {
        //float desiredWidthPixels = Screen.width * 0.2f;
    }

    // Update is called once per frame
    private void Update()
    {
        var cameraHeight = Camera.main.orthographicSize * 2;
        var circlePixelHeight = cameraHeight * multiplyFloat;

        gameObject.transform.localScale = new Vector2(circlePixelHeight, circlePixelHeight);
    }
}