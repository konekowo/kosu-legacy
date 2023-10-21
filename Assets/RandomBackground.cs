using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    public float numImages;
    public string Season;
    public Image image;
    public float divideAmmount = 10f;
    public bool makeBackgroundMoveWithCursor = true;

    // Start is called before the first frame update
    public void GenerateRandomBackground()
    {
        var randomInt = Mathf.RoundToInt(Random.Range(0f, numImages - 1f));
        image.sprite = Resources.Load<Sprite>("Seasonal-Backgrounds/" + Season + "/" + randomInt);
    }

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("SelectedSong") != null && GameObject.FindGameObjectWithTag("SelectedSong")
                .GetComponent<SelectedSong>().songBackroundFile != "")
        {
            var imgDir = GameObject.FindGameObjectWithTag("SelectedSong").GetComponent<SelectedSong>()
                .songBackroundFile;


            if (File.Exists(imgDir))
            {
                var imgData = File.ReadAllBytes(imgDir);
                var imageTexture = new Texture2D(2, 2);
                imageTexture.LoadImage(imgData);
                var sprite = Sprite.Create(imageTexture, new Rect(0f, 0f, imageTexture.width, imageTexture.height),
                    new Vector2(0.5f, 0.5f));
                image.sprite = sprite;
            }
        }
        else
        {
            GenerateRandomBackground();
        }
    }


    // Update is called once per frame
    private void Update()
    {
        if (makeBackgroundMoveWithCursor)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mousePositionDivided = new Vector3(mousePosition.x / divideAmmount, mousePosition.y / divideAmmount,
                mousePosition.z / divideAmmount);
            gameObject.GetComponent<RectTransform>().anchoredPosition = mousePositionDivided;
        }
    }
}