using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    

    public void loadSongSelect()
    {
        Debug.Log("Switching...");
        transition.SetTrigger("Start");
        StartCoroutine(LoadLevel(2, transitionTime));
    }

    public void loadMainMenu()
    {
        Debug.Log("Switching...");
        transition.SetTrigger("Start");
        StartCoroutine(LoadLevel(0, transitionTime));
    }

    public static IEnumerator LoadLevel(int levelIndex, float transitionTime)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void loadWithIndex(int i)
    {
        Debug.Log("Switching...");
        transition.SetTrigger("Start");
        StartCoroutine(LoadLevel(i, transitionTime));
    }
}