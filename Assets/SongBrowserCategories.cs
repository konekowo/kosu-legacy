using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongBrowserCategories : MonoBehaviour
{
    public TMP_InputField searchBar;
    public SongBrowserV2 songbrowser;
    public TMP_Text[] categoryTexts;
    public Color selectedColor = new(167, 125, 209, 255);
    public Color normalColor = new(255, 255, 255, 255);
    private int category = 1;

    public void Search()
    {
        songbrowser.clean();
        songbrowser.getBeatMaps(category: category, searchQuery: searchBar.text);
    }

    public void setCategory(int category)
    {
        this.category = category;
        for (var i = 0; i < categoryTexts.Length; i++)
            if (categoryTexts[i].gameObject.name.StartsWith(category.ToString()))
                categoryTexts[i].color = selectedColor;
            else
                categoryTexts[i].color = normalColor;
    }
}