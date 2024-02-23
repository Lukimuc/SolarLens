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

    public TextMeshProUGUI sliderText;
    public TextMeshProUGUI sinText;

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
    void Update()
    {
        if(GUIManager.instance.inHandsOnMode)
        {
            float intensity = sliderValue;
            angle = calculateAngle();
            distance = calculateDistance();

            //distance = Mathf.Floor(distance);
            //angle = Mathf.Floor(angle);

            distance = (int) distance;
            angle = (int) angle;

            float angleDistance = angle / distance;
            if(angleDistance <= 0)
            {
                angleDistance *= -1;
            }
            electricityValue = angleDistance * intensity;
            if(angle <= 15 || intensity <= 2)
            {
                electricityValue = 0;
            }

            //electricityValue = Mathf.Abs( intensity * Mathf.Sin(angle) / (distance));

            eText.text = "Electricity: " + electricityValue;

            //sinText.text = "" + Mathf.Sin(angle);
            dText.text = "" + distance;
            angleText.text = "" + angle + "°";
            sliderText.text = "Slider: " + getDifferentBrightnessFromElectricity(electricityValue).ToString();
        }
    }

    private int getBrightnessFromElectricity(float electricity)
    {
        //Debug.Log("Check electricity: " + electricity);
        if (electricity < 0.01f)
        {
            //Debug.Log("Too small");
            return 0;
        }
        else if (electricity > 1.4f)
        {
            //Debug.Log("Too big");
            return 254;
        }
        else
        {
            //Debug.Log("Just enough");
            int output = (int)(electricity * 300f);

            return output;
        }
    }

    private int getDifferentBrightnessFromElectricity(float electricity)
    {
        int elec = (int)(electricity);
        if (elec < 20)
        {
            //Debug.Log("Too small");
            return 0;
        }
        else if (elec > 400)
        {
            //Debug.Log("Too big");
            return 254;
        }
        else if (elec >= 20 && elec <= 150)
        {
            int output = (int)(elec * .7f);
            return output;
        }
        else
        {
            //Debug.Log("Just enough");
            int output = (int)(elec * .57f);

            return output;
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
