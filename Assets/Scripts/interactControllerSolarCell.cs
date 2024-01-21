using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Vuforia;
using UnityEngine.UI;

//Vgl. https://www.youtube.com/watch?v=hi_KDpC1nzk

public class interactControllerSolarCell : MonoBehaviour
{
    public TextMeshProUGUI textButtonClicked;
    string btnName;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit)){
                btnName = Hit.transform.name;
                switch (btnName){
                    case "n-layer":
                        Debug.Log("hit button");
                        counter ++;
                        textButtonClicked.text = "button clicked n-layer: " + counter;
                        break;
                    case "p-layer":
                        Debug.Log("hit button");
                        counter ++;
                        textButtonClicked.text = "button clicked p-layer: " + counter;
                        break;
                    default:
                        break;

                }
            }
        }
    }
}
