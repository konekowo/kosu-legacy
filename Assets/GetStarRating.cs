using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetStarRating : MonoBehaviour
{
    public string GetBeatmapStarRating(string SID, string DifficultyName)
    {
        var starRating = "0";

        var data = UnityWebRequest.Get("https://catboy.best/api/search?amount=1&query=" + SID);
        if (data.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log("Error While Fetching Beatmap Star Ratings: " + data.error);

        var onlyChildrenBeatmaps = data.downloadHandler.text;

        Debug.Log(onlyChildrenBeatmaps);


        /*
        JArray array = JArray.Parse(data.downloadHandler.text);
        foreach (JObject obj in array.Children<JObject>())
        {


            foreach (JProperty singleProp in obj.Properties())
            {
                string name = singleProp.Name;
                string value = singleProp.Value.ToString();



                if (name == "Title")
                {
                    //Debug.Log("Title: " + value);

                }
                else if (name == "SetID")
                {
                    // Debug.Log("Song ID: " + value);

                }
                else if (name == "Artist")
                {
                    // Debug.Log("Artist: " + value);
                    //currentSong.GetComponent<Song>().Author = value;
                }
                else if (name == "Creator")
                {
                    // Debug.Log("Mapper: " + value);
                    //currentSong.GetComponent<Song>().Mapper = value;
                }


            }
        }
        */

        return starRating;
    }


    private IEnumerator GetSID(string SID)
    {
        using (var data = UnityWebRequest.Get("https://catboy.best/api/search?amount=1&query=" + SID))
        {
            yield return data.SendWebRequest();

            if (data.result == UnityWebRequest.Result.ProtocolError)
                Debug.Log("Error While Fetching Latest Beatmaps: " + data.error);
            else
                Debug.Log("Recieved Latest Beatmaps: " + data.downloadHandler.text);
        }
    }


    private void Start()
    {
        //GetBeatmapStarRating("510731", "Normal");
    }
}