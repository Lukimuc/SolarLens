using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IpAdress : MonoBehaviour
{
    [SerializeField] private TMP_Text ipAdressField;
    private string ipAdress = "-";

    // Start is called before the first frame update
    void Start()
    {
        ipAdress = Hue.instance.getIpAdress();
        ipAdressField.text = ipAdress;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
