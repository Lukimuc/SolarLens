using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrightnessCalculator : MonoBehaviour
{
    public Transform sun; // Assign your sun object in the Inspector
    public Transform solarCell; // Assign your second object in the Inspector

    public TextMeshProUGUI angleText;

    void Update()
    {
        // 1. Get the direction of the sunshine from the sun object
        Vector3 sunPos = sun.position;
        Vector3 solarcellPos = solarCell.position;

        Vector3 sunshineDirection = solarcellPos - sunPos;

        // 2. Get the normal vector of the top plane of the second object
        Vector3 topPlaneNormal = solarCell.up;

        // 3. Calculate the angle between the two vectors
        float angle = Vector3.Angle(sunshineDirection, topPlaneNormal);

        angleText.text = "Angle: " + angle;

        // Now 'angle' contains the angle between the sunshine direction and the top plane normal of the second object
        Debug.Log("Angle: " + angle);
    }
}
