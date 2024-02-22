using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class electricityGenerationFormula : MonoBehaviour
{
    public static electricityGenerationFormula instance;
    // TODO!: check if you are in hands on mode, dont do anything in guide mode!
    public bool handsOnMode = true;



    public Transform sun; 
    public Transform solarCell; 

    public Transform cloud;
    
    public GameObject sunray;



    private float sliderValue = 100;
    public float electricityValue = 0;

    private float angle = 90;

    private float distance = 0.1f;

    public TextMeshProUGUI angleText;
  
    public TextMeshProUGUI eText;
    public TextMeshProUGUI dText;

    //public TextMeshProUGUI sliderText;
    //public TextMeshProUGUI cloudText;

    public Slider brightnessSlider;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        brightnessSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GUIManager.instance.inHandsOnMode && !GUIManager.instance.handsOnModeIntroPart)
        {
            float intensity = sliderValue;
            angle = calculateAngle();
            distance = calculateDistance();
            


            electricityValue = Mathf.Abs( intensity * ((Mathf.Sin(angle)) / (Mathf.Pow(distance, 2))));

            eText.text = "Electricity: " + electricityValue;
            
            dText.text = "" + Mathf.Floor(distance);
            angleText.text = "" + Mathf.Floor(angle) + "°";
            //sliderText.text = "Slider: " + intensity;
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

            angle = Vector3.Angle(sunshineDirection, topPlaneNormal);

            //adapt values to real world
            angle = angle - 90;
            if(angle < 0){
                angle = 0;
            }
            
        }
        return angle;
    }


    public void ValueChangeCheck()
	{
		sliderValue = brightnessSlider.value;


        float newAlpha = 1 - (sliderValue/100);
        //cloudText.text = "Cloudvalue: " + newAlpha;
        if(cloud != null){
            foreach(Transform child in cloud){
                if (child.gameObject.GetComponent<Renderer>() != null){
                    // Access the material of the object
                    Material mat = child.gameObject.GetComponent<Renderer>().material;

                    // Get the current color of the material
                    Color currentColor = mat.color;

                    // Change the alpha value of the current color
                    currentColor.a = newAlpha;

                    // Assign the new color back to the material
                    mat.color = currentColor;
                }
            }
        }

        float newAlphaSunray = sliderValue/100;

        if(sunray != null){
            // Access the material of the object
            Material mat = sunray.gameObject.GetComponent<Renderer>().material;

            // Get the current color of the material
            Color currentColor = mat.color;

            // Change the alpha value of the current color
            currentColor.a = newAlphaSunray;

            // Assign the new color back to the material
            mat.color = currentColor;
    
        }
	}
}
