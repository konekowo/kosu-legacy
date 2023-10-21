using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.EventSystems;

public class GameHandler : MonoBehaviour
{
    // ----------------------------------------------------------------------------

    [Header("Objects")] public GameObject Circle; // Circle Object

    [Header("Map")] public string MapFilePath; // Map file (.osu format), attach from editor
    public AudioClip MainMusic; // Music file, attach from editor
    public AudioClip HitSound; // Hit sound

    // ----------------------------------------------------------------------------

    private const int SPAWN = -100; // Spawn coordinates for objects

    public static double timer = 0; // Main song timer
    public static int ApprRate = 600; // Approach rate (in ms)
    private int DelayPos = 0; // Delay song position

    public static int ClickedCount = 0; // Clicked objects counter
    private static int ObjCount = 0; // Spawned objects counter

    private List<GameObject> CircleList; // Circles List
    private static string[] LineParams; // Object Parameters

    // Audio stuff
    private AudioSource Sounds;
    private AudioSource Music;
    public static AudioSource pSounds;
    public static AudioClip pHitSound;

    // Other stuff
    private Camera MainCamera;
    private GameObject CursorTrail;
    private Vector3 MousePosition;
    private Ray MainRay;
    private RaycastHit MainHit;

    private void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Music = GameObject.Find("Music Source").GetComponent<AudioSource>();
        Sounds = gameObject.GetComponent<AudioSource>();
        CursorTrail = GameObject.Find("Cursor Trail");
        Music.clip = MainMusic;
        pSounds = Sounds;
        pHitSound = HitSound;
        CircleList = new List<GameObject>();
        ReadCircles(MapFilePath);
    }

    // MAP READER

    private void ReadCircles(string path)
    {
        var reader = new StreamReader(path);
        string line;

        // Skip to [HitObjects] part
        while (true)
            if (reader.ReadLine() == "[HitObjects]")
                break;

        var TotalLines = 0;

        // Count all lines
        while (!reader.EndOfStream)
        {
            reader.ReadLine();
            TotalLines++;
        }

        reader.Close();

        reader = new StreamReader(path);

        // Skip to [HitObjects] part again
        while (true)
            if (reader.ReadLine() == "[HitObjects]")
                break;

        // Sort objects on load
        var ForeOrder = TotalLines + 2; // Sort foreground layer
        var BackOrder = TotalLines + 1; // Sort background layer
        var ApproachOrder = TotalLines; // Sort approach circles layer

        // Some crazy Z axis modifications for sorting
        var TotalLinesStr = "0.";
        for (var i = 3; i > TotalLines.ToString().Length; i--)
            TotalLinesStr += "0";
        TotalLinesStr += TotalLines.ToString();
        var Z_Index = -float.Parse(TotalLinesStr);

        while (!reader.EndOfStream)
        {
            // Uncomment to skip sliders
            /*while (true)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    if (!line.Contains("|"))
                        break;
                }
                else
                    break;
            }*/

            line = reader.ReadLine();
            if (line == null)
                break;

            LineParams = line.Split(','); // Line parameters (X&Y axis, time position)

            // Sorting configuration
            var CircleObject = Instantiate(Circle, new Vector2(SPAWN, SPAWN), Quaternion.identity);
            CircleObject.GetComponent<Circle>().Fore.sortingOrder = ForeOrder;
            CircleObject.GetComponent<Circle>().Back.sortingOrder = BackOrder;
            CircleObject.GetComponent<Circle>().Appr.sortingOrder = ApproachOrder;
            CircleObject.transform.localPosition += new Vector3((float)CircleObject.transform.localPosition.x,
                (float)CircleObject.transform.localPosition.y, (float)Z_Index);
            CircleObject.transform.SetAsFirstSibling();
            ForeOrder--;
            BackOrder--;
            ApproachOrder--;
            Z_Index += 0.01f;

            var FlipY = 384 - int.Parse(LineParams[1]); // Flip Y axis

            var AdjustedX = Mathf.RoundToInt(Screen.height * 1.333333f); // Aspect Ratio

            // Padding
            var Slices = 8f;
            var PaddingX = AdjustedX / Slices;
            var PaddingY = Screen.height / Slices;

            // Resolution set
            var NewRangeX = AdjustedX - PaddingX - PaddingX;
            var NewValueX = int.Parse(LineParams[0]) * NewRangeX / 512f + PaddingX + (Screen.width - AdjustedX) / 2f;
            float NewRangeY = Screen.height;
            var NewValueY = FlipY * NewRangeY / 512f + PaddingY;

            var MainPos =
                MainCamera.ScreenToWorldPoint(new Vector3(NewValueX, NewValueY,
                    0)); // Convert from screen position to world position
            var MainCircle = CircleObject.GetComponent<Circle>();

            MainCircle.Set(MainPos.x, MainPos.y, CircleObject.transform.position.z,
                int.Parse(LineParams[2]) - ApprRate);

            CircleList.Add(CircleObject);
        }

        GameStart();
    }

    // END MAP READER

    private void GameStart()
    {
        Application.targetFrameRate = -1; // Unlimited framerate
        Music.Play();
        StartCoroutine(UpdateRoutine()); // Using coroutine instead of Update()
    }

    private IEnumerator UpdateRoutine()
    {
        while (true)
        {
            timer = Music.time * 1000; // Convert timer
            DelayPos = CircleList[ObjCount].GetComponent<Circle>().PosA;
            MainRay = MainCamera.ScreenPointToRay(Input.mousePosition);

            // Spawn object
            if (timer >= DelayPos)
            {
                CircleList[ObjCount].GetComponent<Circle>().Spawn();
                ObjCount++;
            }

            // Check if cursor is over object
            if (Physics.Raycast(MainRay, out MainHit))
                if ((MainHit.collider.name == "Circle(Clone)" &&
                     timer >= MainHit.collider.gameObject.GetComponent<Circle>().PosA + ApprRate &&
                     Input.GetKeyDown("z")) || Input.GetKeyDown("x"))
                {
                    MainHit.collider.gameObject.GetComponent<Circle>().Got();
                    MainHit.collider.enabled = false;
                    ClickedCount++;
                }

            // Cursor trail movement
            MousePosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            CursorTrail.transform.position = new Vector3(MousePosition.x, MousePosition.y, -9);

            yield return null;
        }
    }
}