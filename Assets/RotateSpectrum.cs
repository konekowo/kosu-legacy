using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpectrum : MonoBehaviour
{
    public float Rotation = 0f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Rotation -= 0.001f;
        gameObject.transform.Rotate(0.0f, 0.0f, Rotation, Space.Self);
    }
}