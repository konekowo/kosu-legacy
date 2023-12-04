using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public float sensitivity = 0.2f;
    public GameObject colliding;
    
    // Start is called before the first frame update
    private void Start()
    {
        
        // if in gameplay, use raw cursor
        if (SongLoader.inGameplay)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        Cursor.visible = false;
        if (SongLoader.inGameplay)
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");


            Vector3 currentPosition = transform.position;
            currentPosition.x += mouseX * sensitivity;
            currentPosition.y += mouseY * sensitivity;



            currentPosition.x = Mathf.Clamp(currentPosition.x, Camera.main.ScreenToWorldPoint(Vector3.zero).x,
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x);

            currentPosition.y = Mathf.Clamp(currentPosition.y, Camera.main.ScreenToWorldPoint(Vector3.zero).y,
                Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);

            // Set the new position of the fake cursor
            transform.position = currentPosition;
        }
        else
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = -5;
            gameObject.transform.position = mousePosition;
        }


        if (Input.GetMouseButtonDown(0)) gameObject.GetComponent<Animator>().SetBool("Click", true);
        if (Input.GetMouseButtonUp(0)) gameObject.GetComponent<Animator>().SetBool("Click", false);

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit,  Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            colliding = hit.transform.gameObject;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            colliding = null;
        }

    }

    
}