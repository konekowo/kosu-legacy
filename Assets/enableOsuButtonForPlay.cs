using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enableOsuButtonForPlay : MonoBehaviour
{
    public void switchToPlay()
    {
        if (GameObject.Find("SongSelectCarousel").GetComponent<SongSelectCarousel>().selectedSong != null)
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().loadWithIndex(3);
    }

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameObject.Find("SongSelectCarousel").GetComponent<SongSelectCarousel>().selectedSong != null)
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
}