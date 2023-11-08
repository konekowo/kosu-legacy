using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreMainToMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LevelLoader.LoadLevel(1, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
