using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSlider : MonoBehaviour
{
    private SongLoader songLoader;
    public float xPos;
    public float yPos;
    public float zPos;
    public string pos;

    private void Start()
    {
        //inner slider
        //Debug.Log(xPos + ", " + yPos + ", " + pos);
        gameObject.GetComponent<LineRenderer>().positionCount = 2;
        Vector3[] positions =
            { new(transform.position.x, transform.position.y, transform.position.z + 2), new(xPos, yPos, zPos + 2) };
        gameObject.GetComponent<LineRenderer>().SetPositions(positions);
        gameObject.GetComponent<LineRenderer>().startWidth = gameObject.transform.localScale.x * 2.1f;
        gameObject.GetComponent<LineRenderer>().endWidth = gameObject.transform.localScale.x * 2.1f;
        //slider outline
        Vector3[] positions2 =
        {
            new(transform.position.x, transform.position.y, transform.position.z + 3), new(xPos + 0.01f, yPos, zPos + 3)
        };
        gameObject.transform.GetChild(10).GetComponent<LineRenderer>().SetPositions(positions2);
        gameObject.transform.GetChild(10).GetComponent<LineRenderer>().startWidth =
            gameObject.transform.localScale.x * 2.3f;
        gameObject.transform.GetChild(10).GetComponent<LineRenderer>().endWidth =
            gameObject.transform.localScale.x * 2.3f;
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(xPos, yPos, zPos), 0.3f);
        Gizmos.DrawLine(transform.position, new Vector3(xPos, yPos, zPos));
    }
    */

    private void Update()
    {
    }
}