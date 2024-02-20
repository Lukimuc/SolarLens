using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class sunray : MonoBehaviour
{

    public bool handsOnMode = true;
    public Transform sun; 
    public Transform solarCell; 

    public float originalLength = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(sun != null && solarCell != null){
            
            UnityEngine.Vector3 midpoint = (sun.position + solarCell.position) / 2;
            transform.position = midpoint;

            float distance = UnityEngine.Vector3.Distance(sun.position, solarCell.position);
            float scaleFactor = distance / originalLength;
            transform.localScale = new UnityEngine.Vector3(transform.localScale.x, scaleFactor, transform.localScale.z);
            
            UnityEngine.Vector3 relpos = sun.position - transform.position;
            UnityEngine.Quaternion toRotation = UnityEngine.Quaternion.LookRotation(relpos);
            UnityEngine.Quaternion corrRot = toRotation * UnityEngine.Quaternion.Euler(90, 0, 0);
            transform.rotation = corrRot;


        }



    }
}
