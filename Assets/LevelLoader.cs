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
        StartCoroutine(LoadLevel(1));
    }

    public void loadMainMenu()
    {
        Debug.Log("Switching...");
        StartCoroutine(LoadLevel(0));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void loadWithIndex(int i)
    {
        Debug.Log("Switching...");
        StartCoroutine(LoadLevel(i));
    }
}