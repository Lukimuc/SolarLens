using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    public bool handsOnMode = true;
    public Transform sun; 
    public Transform solarCell; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(sun != null && solarCell != null){
            
            UnityEngine.Vector3 midpoint = (sun.position + solarCell.position) / 2;
            UnityEngine.Vector3 midmidpoint = (sun.position + midpoint) / 2;
            transform.position = midmidpoint;




        }



    }
}
