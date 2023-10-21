using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -5;
        //mousePosition.x = mousePosition.x + (0.58f/2);
        //mousePosition.y = mousePosition.y - (0.58f / 2);
        gameObject.transform.position = mousePosition;
        if (Input.GetMouseButtonDown(0)) gameObject.GetComponent<Animator>().SetBool("Click", true);
        if (Input.GetMouseButtonUp(0)) gameObject.GetComponent<Animator>().SetBool("Click", false);
    }
}