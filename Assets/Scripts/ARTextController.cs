using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARTextController : MonoBehaviour
{

    private Camera arCamera;

    // Start is called before the first frame update
    void Start()
    {
        arCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (arCamera != null)
        {
            // Rotate the text to face the ARCamera
            transform.LookAt(transform.position + arCamera.transform.rotation * Vector3.forward, arCamera.transform.rotation * Vector3.up);
        }
        else
        {
            // Log an error if ARCamera is not found
            Debug.LogError("ARCamera not found!");
        }
    }
}
