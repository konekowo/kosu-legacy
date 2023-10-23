using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine.UI;

public class SongBrowserV2 : MonoBehaviour
{
    public GameObject beatMapPrefab;
    public GameObject beatMapsContainer;
    public GameObject mapsLoadScreen;
    public string minoServerURL = "https://catboy.best/";
    public int page = 0;
    public int currentCategory;
    public string currentSearchQuery;
    public int currentOffset;
    public TMP_Text pageText;
    public Button backPageButton;
    private bool isFirstTimeOpening = true;

    public void Start()
    {
        if (minoServerURL.EndsWith("/api/")) minoServerURL = minoServerURL.Substring(0, minoServerURL.Length - 4);
    }

    public void open()
    {
        gameObject.transform.parent.transform.parent.transform.parent.GetComponent<Animator>().SetTrigger("open");
        if (isFirstTimeOpening)
        {
            isFirstTimeOpening = false;

            if (beatMapsContainer.transform.childCount > 1) clean();
            getBeatMaps();
        }
    }

    public void close()
    {
        gameObject.transform.parent.transform.parent.transform.parent.GetComponent<Animator>().SetTrigger("close");
        //clean();
    }

    /* ---- Modes ----
     * Any = -1
     * Standard = 0
     * Taiko = 1
     * Catch the beat = 2
     * Mania = 3
     * ---------------
     * ---- Catagories ----
     * Any = -3
     * Graveyard = -2
     * WIP = -1
     * Pending = 0
     * Ranked = 1
     * (The guy who made the Mino API forgot to use 2 ig)
     * Qualified = 3
     * Loved = 4
     */
    public async void getBeatMaps(int mode = 0, int amount = 24, int offset = 0, int category = 1,
        string searchQuery = "")
    {
        currentSearchQuery = searchQuery;
        currentCategory = category;
        currentOffset = offset;
        page = offset / 12 + 1;
        pageText.SetText("Page " + page.ToString());
        if (page > 1)
            backPageButton.interactable = true;
        else
            backPageButton.interactable = false;
        mapsLoadScreen.SetActive(true);
        var data = UnityWebRequest.Get(minoServerURL + "api/v2/search?" + "amount=" + amount + "&" + "mode=" + mode + "&" +
                                       "offset=" + offset + "&" + "status=" + category + "&" + "query=" + searchQuery);
        await data.SendWebRequest();
        if (data.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(data.url);
            //Debug.Log(data.downloadHandler.text);
            var array = JArray.Parse(data.downloadHandler.text);
            // For each beatmap set
            foreach (var obj in array.Children<JObject>())
            {
                var beatmapOBJ = Instantiate(beatMapPrefab, beatMapsContainer.transform, false);

                var beatmap = beatmapOBJ.GetComponent<SongV2>();
                beatmap.minoServerURL = minoServerURL;
                //For each property in the beatmap set
                foreach (var singleProp in obj.Properties())
                {
                    switch (singleProp.Name)
                    {
                        case "title":
                            beatmap.Title = singleProp.Value.ToString();
                            break;
                        case "id":
                            beatmap.SID = singleProp.Value.ToString();
                            break;
                        case "artist":
                            beatmap.Artist = singleProp.Value.ToString();
                            break;
                        case "creator":
                            beatmap.Mapper = singleProp.Value.ToString();
                            break;
                    }

                    beatmapOBJ.SetActive(true);
                }
            }

            mapsLoadScreen.SetActive(false);
        }
        else
        {
            Debug.LogError(data.result + " Error: " + data.error);
            mapsLoadScreen.SetActive(false);
        }
    }


    public void getPopular()
    {
        clean();
        getBeatMaps(searchQuery: "Top%20Rated");
    }

    public void getLatest()
    {
        clean();
        getBeatMaps();
    }

    public void nextPage()
    {
        clean();
        getBeatMaps(category: currentCategory, searchQuery: currentSearchQuery, offset: currentOffset + 12);
        if (page > 1)
            backPageButton.interactable = true;
        else
            backPageButton.interactable = false;
        pageText.SetText("Page " + page.ToString());
    }

    public void backPage()
    {
        if (page > 1)
        {
            clean();
            var setOffset = currentOffset - 12;
            if (setOffset < 0) setOffset = 0;
            getBeatMaps(category: currentCategory, searchQuery: currentSearchQuery, offset: setOffset);
            if (page > 1)
                backPageButton.interactable = true;
            else
                backPageButton.interactable = false;
            pageText.SetText("Page " + page.ToString());
        }
    }

    public void clean()
    {
        for (var i = 1; i < beatMapsContainer.transform.childCount; i++)
            Destroy(beatMapsContainer.transform.GetChild(i).gameObject);
    }
}