using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SongBrowserError : MonoBehaviour
{
    public TMP_Text contentText;
    public TMP_Text titleText;

    [SerializeField] private string title;
    [SerializeField] private string content;

    public void setContent(string content)
    {
        this.content = content;
        contentText.SetText(this.content);
    }

    public void setTitle(string title)
    {
        this.title = title;
        titleText.SetText(this.title);
    }

    public void show()
    {
        gameObject.SetActive(true);
    }

    public void deleteErrorMessageBox()
    {
        Destroy(gameObject);
    }

    public void copyContent()
    {
        GUIUtility.systemCopyBuffer = content;
    }
}