using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModelManager : MonoBehaviour
{

    // Set Object modles active or NOT active
    public GameObject sunSphere;
    public GameObject sunray;
    public GameObject nLayer;
    public GameObject pLayer;
    public GameObject contactLayerTop;
    public GameObject contactLayerBottom;

    public GameObject appliance;

    public GameObject nAtomlayer;

    public GameObject pAtomLayer;

    public GameObject holes;

    public GameObject electrons;

    public GameObject nLayerLabel;
    public GameObject pLayerLabel;
    public GameObject topContactLayerLabel;
    public GameObject bottomContactLayerLabel;

    public GameObject npLayer;
    public GameObject npLayerLabel;

    public GameObject cloud;

    public GameObject sunRay1;
    public GameObject sunRay2;
    public GameObject sunRay3;

    public GameObject electronHandsOn;

    public GameObject electronLabel;

    public GameObject holeLabel;

    //public GameObject electronLabel;
    //public GameObject holesLabel;



    


    // Start is called before the first frame update
    void Start()
    {
        setAllModelsInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1. Model Guide Mode
    public void setFirstModelinGuideMode(){
        //setAllModelsInvisible();
        nLayer.SetActive(true);
        pLayer.SetActive(true);
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
        //set Label visible
        nLayerLabel.SetActive(true);
        pLayerLabel.SetActive(true);
        topContactLayerLabel.SetActive(true);
        bottomContactLayerLabel.SetActive(true);
    }






    // 2. Model Guide Mode
    public void setNLayerModelinGuideMode(){
        //setAllModelsInvisible();
        nLayer.SetActive(true);
        nLayerLabel.SetActive(true);
    }

    // 3. Model Guide Mode
    public void setNAtomLayerModelinGuideMode(){
        //setAllModelsInvisible();
        nLayer.SetActive(true);
        nAtomlayer.SetActive(true);
    }

    // 4. Model Guide Mode
    public void setPLayerModelinGuideMode(){
        //setAllModelsInvisible();
        pLayer.SetActive(true);
        pLayerLabel.SetActive(true);
    }

    // 5. Model Guide Mode
    public void setPAtomLayerModelinGuideMode(){
        //setAllModelsInvisible();
        pLayer.SetActive(true);
        pAtomLayer.SetActive(true);
        pLayerLabel.SetActive(true);
        electronHandsOn.SetActive(false);
    }

    // 6. Model Guide Mode
    public void setContactLayerModelinGuideMode(){
        //setAllModelsInvisible();
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
        topContactLayerLabel.SetActive(true);
        bottomContactLayerLabel.SetActive(true);
        electronHandsOn.SetActive(false);
    }

    // 7. Model Guide Mode
    public void setElectronLayerModelinGuideMode(){
        //setAllModelsInvisible();
        nLayer.SetActive(true);
        electrons.SetActive(true);
        nLayerLabel.SetActive(true);
        electronHandsOn.SetActive(false);
        electronLabel.SetActive(true);
    }

    // 8. Model Guide Mode
    public void setHolesLayerModelinGuideMode(){
        //setAllModelsInvisible();
        pLayer.SetActive(true);
        holes.SetActive(true);
        pLayerLabel.SetActive(true);
        electronHandsOn.SetActive(false);
        holeLabel.SetActive(true);
    }

    // 1. Model Animation Mode
    public void setAnimationMode(){
        //setAllModelsInvisible();
        nLayer.SetActive(true);
        electrons.SetActive(true);
        pLayer.SetActive(true);
        holes.SetActive(true);
        sunRay1.SetActive(false);
        sunRay2.SetActive(false);
        sunRay3.SetActive(false);
        electronHandsOn.SetActive(false);
        electronLabel.SetActive(false);
        holeLabel.SetActive(false);
    }

    public void setAnimationModeWithContacts(){
        //setAllModelsInvisible();
        nLayer.SetActive(true);
        electrons.SetActive(true);
        pLayer.SetActive(true);
        holes.SetActive(true);
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
        //sunRay1.SetActive(true);
        //sunRay2.SetActive(true);
        //sunRay3.SetActive(true);
        electronHandsOn.SetActive(false);
    }

    public void setJunctionLayer(){
        //setAllModelsInvisible();
        npLayer.SetActive(true);
        npLayerLabel.SetActive(true);
        electrons.SetActive(true);
        holes.SetActive(true);
        electronHandsOn.SetActive(false);
    }

    //2. Model SunRay Animation mode
    public void setSunRayAnimationMode(){
        nLayer.SetActive(true);
        electrons.SetActive(true);
        pLayer.SetActive(true);
        holes.SetActive(true);
        sunRay1.SetActive(false);
        sunRay2.SetActive(false);
        sunRay3.SetActive(false);
        electronHandsOn.SetActive(false);
        //Wir haben noch keinen Sonnenstrahl für die Animation
    }

    //3. Model Contact layer Animation mode
    public void setContactlayerAnimationMode(){
        nLayer.SetActive(true);
        electrons.SetActive(true);
        pLayer.SetActive(true);
        holes.SetActive(true);
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
        electronHandsOn.SetActive(false);
    }

    //4. Model Appliance (propeller) Animation mode
    public void setApplianceAnimationMode(){
        nLayer.SetActive(true);
        electrons.SetActive(true);
        pLayer.SetActive(true);
        holes.SetActive(true);
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
        appliance.SetActive(true);
        sunRay1.SetActive(false);
        sunRay2.SetActive(false);
        sunRay3.SetActive(false);
        electronHandsOn.SetActive(false);
    }

    // Hands on mode!!!
    public void setModelsHandsOnMode(){
        //setAllModelsInvisible();
        sunSphere.SetActive(true);
        sunray.SetActive(true);
        cloud.SetActive(true);
        nLayer.SetActive(true);
        pLayer.SetActive(true);
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
        electronHandsOn.SetActive(true);
        sunRay1.SetActive(false);
        sunRay2.SetActive(false);
        sunRay3.SetActive(false);
    }

    //set Children of parent object Active
    private void setChildrenActive(Transform transform){
        foreach(Transform child in transform){
            child.gameObject.SetActive(true);
        }
    }

    //set Children of parent object NOT Active
    private void setChilderenDeactive(Transform transform){
        foreach(Transform child in transform){
            child.gameObject.SetActive(false);
        }
    }


    public void resetNandPLayer(){
        nLayer.transform.localPosition = new Vector3(0f, 0.6f, 0f);
        pLayer.transform.localPosition = new Vector3(0f, -0.6f, 0f);
    }

    // Se all objects NOT active!
    public void setAllModelsInvisible(){
        sunSphere.SetActive(false);
        sunray.SetActive(false);
        nLayer.SetActive(false);
        pLayer.SetActive(false);
        contactLayerTop.SetActive(false);
        contactLayerBottom.SetActive(false);
        appliance.SetActive(false);
        nAtomlayer.SetActive(false);
        pAtomLayer.SetActive(false);
        holes.SetActive(false);
        electrons.SetActive(false);
        nLayerLabel.SetActive(false);
        pLayerLabel.SetActive(false);
        topContactLayerLabel.SetActive(false);
        bottomContactLayerLabel.SetActive(false);
        npLayer.SetActive(false);
        npLayerLabel.SetActive(false);
        cloud.SetActive(false);
        sunRay1.SetActive(false);
        sunRay2.SetActive(false);
        sunRay3.SetActive(false);
        electronHandsOn.SetActive(false);
        electronLabel.SetActive(false);
        holeLabel.SetActive(false);
    }



}
