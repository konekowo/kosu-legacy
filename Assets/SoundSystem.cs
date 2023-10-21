using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine.Audio;
using UnityEngine.Networking;
using Unity.SharpZipLib.Utils;
using Cysharp.Threading.Tasks;

public class SoundSystem : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void JSAlert(string message);


    public void DownloadSong(string args)
    {
        var blobURL = args.Split("kosu!seperateArgsHere📂📂📂📂")[0];
        var fileName = args.Split("kosu!seperateArgsHere📂📂📂📂")[1];
        StartCoroutine(sendRequest(blobURL, fileName));
    }


    private IEnumerator sendRequest(string blobURL, string fileName)
    {
        var www = UnityWebRequest.Get(blobURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Or retrieve results as binary data

            var results = www.downloadHandler.data;
            unZipSong(results, fileName);
        }
    }

    private void unZipSong(byte[] results, string fileName)
    {
        var SID = fileName.Split(' ')[0];
        var Title = fileName.Split('-')[1];
        Title = Title.Substring(1, Title.Length - 5);
        var path = Application.persistentDataPath + "/Songs/" + SID + " - " + Title + ".zip";
        File.WriteAllBytes(path, results);
        Debug.Log("Downloaded Beatmap, uncompressing...");
        ZipUtility.UncompressFromZip(path, null, Application.persistentDataPath + "/Songs/" + SID + " - " + Title);
        File.Delete(path);
        Debug.Log("Uncompress done, original zip file deleted.");
        JSAlert("Beatmap Imported!");
    }


    private void Awake()
    {
        var objs = GameObject.FindGameObjectsWithTag("SoundSystem");

        if (objs.Length > 1) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}