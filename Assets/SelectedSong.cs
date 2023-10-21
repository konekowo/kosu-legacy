using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedSong : MonoBehaviour
{
    public string songName;
    public string SID;
    public string DiffName;
    public string Artist;
    public string mapDir;
    public string songBackroundFile = "";
    public float numImages;
    public string Season;


    public void setStringBackground(string str)
    {
        songBackroundFile = str;
    }

    private void Awake()
    {
        var objs = GameObject.FindGameObjectsWithTag("SelectedSong");

        if (objs.Length > 1) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update


    // Update is called once per frame
    private void Update()
    {
    }
}