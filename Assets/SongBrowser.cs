using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using TMPro;

public class SongBrowser : MonoBehaviour
{
    public GameObject song;
    public GameObject newSongsPanel;
    public GameObject popularSongsPanel;
    public GameObject searchSongsPanel;
    public TMP_Text panelTitle;
    public GameObject searchBar;

    public string MapStorageURL;

    public string[] songTitles;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Songs directory is: " + Application.persistentDataPath);
    }


    public void OpenBrowser()
    {
        deleteChildSongsOfAllPanels();

        newSongsPanel.SetActive(true);
        popularSongsPanel.SetActive(false);
        searchSongsPanel.SetActive(false);

        panelTitle.SetText("New Songs");

        gameObject.GetComponent<Animator>().SetBool("SongBrowserIsOpen", true);
        StartCoroutine(GetLatest());
    }


    public void OpenNewestSongs()
    {
        panelTitle.SetText("New Songs");
        deleteChildSongsOfAllPanels();


        newSongsPanel.SetActive(true);
        popularSongsPanel.SetActive(false);
        searchSongsPanel.SetActive(false);


        StartCoroutine(GetLatest());
    }


    public void OpenPopularSongs()
    {
        panelTitle.SetText("Popular Songs");
        deleteChildSongsOfAllPanels();


        newSongsPanel.SetActive(false);
        popularSongsPanel.SetActive(true);
        searchSongsPanel.SetActive(false);


        StartCoroutine(GetPopular());
    }

    public void SearchSongs()
    {
        var searchQuery = searchBar.gameObject.GetComponent<TMP_InputField>().text;

        panelTitle.SetText("Searching: " + searchQuery);

        deleteChildSongsOfAllPanels();


        newSongsPanel.SetActive(false);
        popularSongsPanel.SetActive(false);
        searchSongsPanel.SetActive(true);


        StartCoroutine(GetSearch(searchQuery));
    }


    private void deleteChildSongsOfAllPanels()
    {
        foreach (Transform child in newSongsPanel.transform) Destroy(child.gameObject);
        foreach (Transform child in popularSongsPanel.transform) Destroy(child.gameObject);
        foreach (Transform child in searchSongsPanel.transform) Destroy(child.gameObject);
    }

    private IEnumerator GetLatest()
    {
        using (var data = UnityWebRequest.Get(MapStorageURL + "search?amount=8&mode=0"))
        {
            yield return data.SendWebRequest();

            if (data.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error While Fetching Latest Beatmaps: " + data.error);
            }
            else
            {
                Debug.Log("Recieved Latest Beatmaps: " + data.downloadHandler.text);
                afterDownload(data.downloadHandler.text, newSongsPanel);
            }
        }
    }

    private IEnumerator GetPopular()
    {
        using (var data = UnityWebRequest.Get(MapStorageURL + "search?amount=8&mode=0&query=Top%20Rated"))
        {
            yield return data.SendWebRequest();

            if (data.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error While Fetching Latest Beatmaps: " + data.error);
            }
            else
            {
                Debug.Log("Recieved Latest Beatmaps: " + data.downloadHandler.text);
                afterDownload(data.downloadHandler.text, popularSongsPanel);
            }
        }
    }

    private IEnumerator GetSearch(string searchQuery)
    {
        using (var data = UnityWebRequest.Get(MapStorageURL + "search?amount=8&mode=0&query=" + searchQuery))
        {
            yield return data.SendWebRequest();

            if (data.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error While Fetching Latest Beatmaps: " + data.error);
            }
            else
            {
                Debug.Log("Recieved Latest Beatmaps: " + data.downloadHandler.text);
                afterDownload(data.downloadHandler.text, searchSongsPanel);
            }
        }
    }


    private void afterDownload(string data, GameObject panelToUse)
    {
        var array = JArray.Parse(data);
        var songcount = 0;
        var ycount = 0;
        foreach (var obj in array.Children<JObject>())
        {
            songcount++;
            var currentSong = Instantiate(song);
            currentSong.GetComponent<RectTransform>().SetParent(panelToUse.transform);
            currentSong.SetActive(true);

            currentSong.GetComponent<RectTransform>().anchoredPosition = new Vector3(103.5f, -158.1f, 0.0f);
            currentSong.GetComponent<RectTransform>().localScale = new Vector3(0.1379956f, 0.1561836f, 0.1276473f);
            if (songcount > 4)
            {
                currentSong.GetComponent<RectTransform>().anchoredPosition = new Vector3(103.5f, -303f, 0.0f);
                songcount = 1;
                ycount++;
            }
            else if (ycount > 0)
            {
                currentSong.GetComponent<RectTransform>().anchoredPosition = new Vector3(103.5f, -303f, 0.0f);
            }

            if (songcount == 1)
                currentSong.GetComponent<RectTransform>().anchoredPosition = new Vector3(103.5f,
                    currentSong.GetComponent<RectTransform>().anchoredPosition.y, 0.0f);
            else if (songcount == 2)
                currentSong.GetComponent<RectTransform>().anchoredPosition = new Vector3(308f,
                    currentSong.GetComponent<RectTransform>().anchoredPosition.y, 0.0f);
            else if (songcount == 3)
                currentSong.GetComponent<RectTransform>().anchoredPosition = new Vector3(516f,
                    currentSong.GetComponent<RectTransform>().anchoredPosition.y, 0.0f);
            else if (songcount == 4)
                currentSong.GetComponent<RectTransform>().anchoredPosition = new Vector3(721.3f,
                    currentSong.GetComponent<RectTransform>().anchoredPosition.y, 0.0f);


            foreach (var singleProp in obj.Properties())
            {
                var name = singleProp.Name;
                var value = singleProp.Value.ToString();


                if (name == "Title")
                    //Debug.Log("Title: " + value);
                    currentSong.GetComponent<Song>().Title = value;
                else if (name == "SetID")
                    // Debug.Log("Song ID: " + value);
                    currentSong.GetComponent<Song>().SID = value;
                else if (name == "Artist")
                    // Debug.Log("Artist: " + value);
                    currentSong.GetComponent<Song>().Author = value;
                else if (name == "Creator")
                    // Debug.Log("Mapper: " + value);
                    currentSong.GetComponent<Song>().Mapper = value;
            }
        }
    }


    private string readTitle(string data)
    {
        //Debug.Log(data.IndexOf("\"Title\":"));
        //Debug.Log(data[data.IndexOf("\"Title\":") + 9]);
        var endIndexOfTitle = 999;
        for (var i = data.IndexOf("\"Title\":") + 9; i < data.Length; i++)
            if (data[i] == ',')
            {
                endIndexOfTitle = i - 1;
                break;
            }

        var titleIndexLength = endIndexOfTitle - data.IndexOf("\"Title\":") + 9 - 18;

        return data.Substring(data.IndexOf("\"Title\":") + 9, titleIndexLength);
    }

    private string readSID(string data)
    {
        //Debug.Log(data.IndexOf("\"Title\":"));
        //Debug.Log(data[data.IndexOf("\"Title\":") + 9]);
        var endIndexOfSID = 999;
        for (var i = data.IndexOf("\"SetID\":") + 9; i < data.Length; i++)
            if (data[i] == ',')
            {
                endIndexOfSID = i - 1;
                break;
            }

        var titleIndexLength = endIndexOfSID - data.IndexOf("\"SetID\":") + 9 - 16;

        return data.Substring(data.IndexOf("\"SetID\":") + 8, titleIndexLength);
    }


    public void CloseBrowser()
    {
        gameObject.GetComponent<Animator>().SetBool("SongBrowserIsOpen", false);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}