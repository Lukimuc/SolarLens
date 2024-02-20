using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class electricityGenerationFormula : MonoBehaviour
{

    // TODO!: check if you are in hands on mode, dont do anything in guide mode!
    public bool handsOnMode = true;



    public Transform sun; 
    public Transform solarCell; 




    private float sliderValue = 100;
    public float electricityValue = 0;

    private float angle = 90;

    private float distance = 0.1f;

    public TextMeshProUGUI angleText;
    public TextMeshProUGUI eText;
    public TextMeshProUGUI dText;

    public Slider brightnessSlider;
    // Start is called before the first frame update
    void Start()
    {
        brightnessSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GUIManager.instance.inHandsOnMode && !GUIManager.instance.handsOnModeExplanationPart){
            float intensity = sliderValue;
            angle = calculateAngle();
            distance = calculateDistance();
            dText.text = "Distance: " + distance;


            electricityValue = intensity * ((Mathf.Sin(angle)) / (Mathf.Pow(distance, 2)));
            eText.text = "Electricity: " + electricityValue;
        }
    }

    public float calculateDistance(){
        float distance = 0.1f;
        if(sun != null && solarCell != null){
            distance =  Vector3.Distance (sun.transform.position, solarCell.transform.position);
            if(distance == 0){
                distance = 0.1f;
            }
        }

        return distance;
    }

    public float calculateAngle(){
        angle = 90;
        if(sun != null && solarCell != null){
            Vector3 sunPos = sun.position;
            Vector3 solarcellPos = solarCell.position;

            Vector3 sunshineDirection = solarcellPos - sunPos;

            Vector3 topPlaneNormal = solarCell.up;

            float angle = Vector3.Angle(sunshineDirection, topPlaneNormal);

            //adapt values to real world
            angle = angle - 90;
            if(angle < 0){
                angle = 0;
            }
            angleText.text = "Angle: " + angle;
        }
        return angle;
    }


    public void ValueChangeCheck()
	{
		sliderValue = brightnessSlider.value;
	}
}
