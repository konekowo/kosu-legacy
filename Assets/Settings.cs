using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;

public class Settings : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void showCSSCursor();

    [DllImport("__Internal")]
    private static extern void hideCSSCursor();

    public Animator animator;
    public bool isSettingsOpen = false;
    public GameObject cursorSizeSlider;
    public GameObject cursorToggle;
    public GameObject cursorObject;
    public GameObject CSSToggle;


    [Header("Default Settings")] public int CSSCursorToggle = 1;
    public int CursorTrailToggle = 1;
    public float CursorSizeSlider = 1.254f;


    public void onCursorSliderChange()
    {
        cursorObject.transform.localScale = new Vector3(cursorSizeSlider.GetComponent<Slider>().value,
            cursorSizeSlider.GetComponent<Slider>().value, cursorSizeSlider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("CursorSizeSlider", cursorSizeSlider.GetComponent<Slider>().value);
        PlayerPrefs.Save();
    }

    public void onCursorToggleChange()
    {
        if (cursorToggle.GetComponent<Toggle>().isOn)
        {
            var main = cursorObject.GetComponent<ParticleSystem>().main;
            main.startLifetime = 0.62f;
            PlayerPrefs.SetInt("CursorTrailToggle", 1);
            PlayerPrefs.Save();
        }
        else
        {
            var main = cursorObject.GetComponent<ParticleSystem>().main;
            main.startLifetime = 0.0f;
            PlayerPrefs.SetInt("CursorTrailToggle", 0);
            PlayerPrefs.Save();
        }
    }

    public void onCSSToggleChange()
    {
        if (CSSToggle.GetComponent<Toggle>().isOn)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
                showCSSCursor();
#endif
            cursorObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color =
                new Color(255, 255, 255, 0);
            PlayerPrefs.SetInt("CSSCursorToggle", 1);
            PlayerPrefs.Save();
        }
        else
        {
#if UNITY_WEBGL && !UNITY_EDITOR
                hideCSSCursor();
#endif
            cursorObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color =
                new Color(255, 255, 255, 255);
            PlayerPrefs.SetInt("CSSCursorToggle", 0);
            PlayerPrefs.Save();
        }
    }

    public void OpenSettings()
    {
        animator.SetBool("isSettingsOpen", true);
        isSettingsOpen = true;
    }

    // Start is called before the first frame update


    private void checkSavedSettings()
    {
        if (PlayerPrefs.GetInt("CSSCursorToggle") == 1)
            CSSToggle.GetComponent<Toggle>().isOn = true;
        else
            CSSToggle.GetComponent<Toggle>().isOn = false;

        if (PlayerPrefs.GetInt("CursorTrailToggle") == 1)
            cursorToggle.GetComponent<Toggle>().isOn = true;
        else
            cursorToggle.GetComponent<Toggle>().isOn = false;

        cursorSizeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("CursorSizeSlider");
    }

    private void makeDefaultSettings()
    {
        if (PlayerPrefs.HasKey("HasBeenRanMoreThanOnce"))
        {
            Debug.Log("There are already saved configurations! not setting to default settings.");
        }
        else
        {
            Debug.Log("Making Default Configs...");
            PlayerPrefs.SetInt("HasBeenRanMoreThanOnce", 1);
            PlayerPrefs.SetInt("CSSCursorToggle", CSSCursorToggle);
#if UNITY_EDITOR
            PlayerPrefs.SetInt("CSSCursorToggle", 0);
#endif
            PlayerPrefs.SetInt("CursorTrailToggle", CursorTrailToggle);
            PlayerPrefs.SetFloat("CursorSizeSlider", CursorSizeSlider);
            PlayerPrefs.Save();
        }
    }


    private void Start()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Songs/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Songs/");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/BGS/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/BGS/");
        }
        
        makeDefaultSettings();

        checkSavedSettings();

        onCSSToggleChange();
        onCursorToggleChange();
        onCursorSliderChange();
        if (!File.Exists(Application.persistentDataPath + "/beatmaps.kosudb"))
        {
            File.Create(Application.persistentDataPath + "/beatmaps.kosudb");
            UniTask.Delay(100);
            SongSelectCarousel.processAllBeatmaps();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true && isSettingsOpen == true)
        {
            animator.SetBool("isSettingsOpen", false);
            isSettingsOpen = false;
        }
    }
}