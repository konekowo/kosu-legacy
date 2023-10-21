using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectSong : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnBecameVisible()
    {
        gameObject.SetActive(true);
    }
}