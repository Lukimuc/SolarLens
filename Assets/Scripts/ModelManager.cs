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



    


    // Start is called before the first frame update
    void Start()
    {
        //setAllModelsInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1. Model Guide Mode
    public void setFirstModelinGuideMode(){
        setAllModelsInvisible();
        nLayer.SetActive(true);
        pLayer.SetActive(true);
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
        //set Label invisible
        setChildrenActive(nLayer.transform);
        setChildrenActive(pLayer.transform);
        setChildrenActive(contactLayerTop.transform);
        setChildrenActive(contactLayerBottom.transform);
    }

    // 2. Model Guide Mode
    public void setNLayerModelinGuideMode(){
        setAllModelsInvisible();
        nLayer.SetActive(true);
    }

    // 3. Model Guide Mode
    public void setNAtomLayerModelinGuideMode(){
        setAllModelsInvisible();
        nLayer.SetActive(true);
        nAtomlayer.SetActive(true);
    }

    // 4. Model Guide Mode
    public void setPLayerModelinGuideMode(){
        setAllModelsInvisible();
        pLayer.SetActive(true);
    }

    // 5. Model Guide Mode
    public void setPAtomLayerModelinGuideMode(){
        setAllModelsInvisible();
        pLayer.SetActive(true);
        pAtomLayer.SetActive(true);
    }

    // 6. Model Guide Mode
    public void setContactLayerModelinGuideMode(){
        setAllModelsInvisible();
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
    }

    // 7. Model Guide Mode
    public void setElectronLayerModelinGuideMode(){
        setAllModelsInvisible();
        nLayer.SetActive(true);
        electrons.SetActive(true);
    }

    // 8. Model Guide Mode
    public void setHolesLayerModelinGuideMode(){
        setAllModelsInvisible();
        pLayer.SetActive(true);
        holes.SetActive(true);
    }

    // 1. Model Animation Mode
    public void setAnimationMode(){
        setAllModelsInvisible();
        nLayer.SetActive(true);
        electrons.SetActive(true);
        pLayer.SetActive(true);
        holes.SetActive(true);
    }

    //2. Model SunRay Animation mode
    public void setSunRayAnimationMode(){
        //Wir haben noch keinen Sonnenstrahl für die Animation
    }

    //3. Model Contact layer Animation mode
    public void setContactlayerAnimationMode(){
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
    }

    //4. Model Appliance (propeller) Animation mode
    public void setApplianceAnimationMode(){
        appliance.SetActive(true);
    }

    // Hands on mode!!!
    public void setModelsHandsOnMode(){
        setAllModelsInvisible();
        sunSphere.SetActive(true);
        sunray.SetActive(true);
        nLayer.SetActive(true);
        pLayer.SetActive(true);
        contactLayerTop.SetActive(true);
        contactLayerBottom.SetActive(true);
        //set Label invisible
        setChilderenDeactive(nLayer.transform);
        setChilderenDeactive(pLayer.transform);
        setChilderenDeactive(contactLayerTop.transform);
        setChilderenDeactive(contactLayerBottom.transform);

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
    }



}
