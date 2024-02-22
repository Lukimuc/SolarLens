using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    [SerializeField] private List<String> titles = new List<String>();
    [SerializeField] private List<String> texts = new List<String>();
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text text;
    [SerializeField] private UnityEngine.UI.Button nextBtn;
    [SerializeField] private UnityEngine.UI.Button prevBtn;

    [SerializeField] private Canvas homeScreen;
    [SerializeField] private Canvas guidedTourCanvas;
    [SerializeField] private Canvas handsOnCanvas;

    [Space]
    [SerializeField] private GameObject handsOnTrackedIconsPanelTop;
    [SerializeField] private UnityEngine.UI.Button handsOnTrackedNextButton;
    [SerializeField] private GameObject handsOnAngleDistancePanel;
    [SerializeField] private GameObject handsOnInfoPanel;
    [SerializeField] private GameObject handsOnSlider;
    [SerializeField] private GameObject handsOnIntroPanel1;
    [SerializeField] private GameObject handsOnIntroPanel2;
    [SerializeField] private GameObject handsOnIntroPanel3;
    [SerializeField] private GameObject handsOnIntroDetailPanel1;
    [SerializeField] private GameObject handsOnIntroDetailPanel2;
    [SerializeField] private GameObject handsOnIntroDetailPanel3;

    [Space]
    [SerializeField] private GameObject guidedMuteImageField;
    [SerializeField] private GameObject guidedIntroductionPanel;
    [SerializeField] private GameObject guidedExplanationPanel;
    [SerializeField] private GameObject guidedQRCode;
    [SerializeField] private GameObject guidedFinishPanel;
    [SerializeField] private GameObject solarCellObject;
    [SerializeField] private Sprite muteSprite;
    [SerializeField] private Sprite unmuteSprite;

    private int guidedTourCounter = -1;
    private bool inGuidedView = false;
    public bool inHandsOnMode = false;
    private bool handsOnNextButtonActivated = false;

    public bool handsOnModeIntroPart = true;
    private bool guidedTourIntroductionPart = true;
    private Animator solarCellAnimator;

    public ModelManager modelManager;


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
        homeScreen.gameObject.SetActive(true);
        handsOnCanvas.gameObject.SetActive(false);
        guidedTourCanvas.gameObject.SetActive(false);
        solarCellAnimator = solarCellObject.GetComponent<Animator>();
        solarCellAnimator.enabled = false;
        solarCellAnimator.SetBool("No_Anim", true);
        solarCellAnimator.SetBool("01_Elektrode", false);
        solarCellAnimator.SetBool("02_Schicht", false);
        solarCellAnimator.SetBool("03_Sonne", false);
        solarCellAnimator.SetBool("04_Strom", false);
        solarCellAnimator.SetBool("hands_on", false);
    }


    public void changeToGuidedMode()
    {
        Debug.Log("guidedIntro: " + guidedTourIntroductionPart);
        Debug.Log("counter: " + guidedTourCounter);
        homeScreen.gameObject.SetActive(false);
        handsOnCanvas.gameObject.SetActive(false);
        guidedTourCanvas.gameObject.SetActive(true);
        guidedQRCode.SetActive(false);
        inGuidedView = true;
        SoundManager.instance.playSound("Guided-Einfuehrung");

        modelManager.setAllModelsInvisible();
        //Debug.Log(solarCellAnimator);
        //solarCellAnimator.SetTrigger("No_Animation");
        solarCellAnimator.enabled = true;
        solarCellAnimator.SetBool("No_Anim", true);
        solarCellAnimator.SetBool("01_Elektrode", false);
        solarCellAnimator.SetBool("02_Schicht", false);
        solarCellAnimator.SetBool("03_Sonne", false);
        solarCellAnimator.SetBool("04_Strom", false);
        solarCellAnimator.SetBool("hands_on", false);
        solarCellAnimator.enabled = false;
        if (guidedTourIntroductionPart)
        {
            guidedIntroductionPanel.SetActive(true);
            guidedExplanationPanel.SetActive(false);
            guidedFinishPanel.SetActive(false);
        }
    }

    public void changeToHandsOnMode()
    {
        homeScreen.gameObject.SetActive(false);
        guidedTourCanvas.gameObject.SetActive(false);
        handsOnCanvas.gameObject.SetActive(true);
        // Checking whether the next button can be pressed
        if(handsOnNextButtonActivated)
        {
            handsOnTrackedNextButton.interactable = true;
        } else
        {
            //handsOnTrackedNextButton.interactable= false;
        }

        disableAllHandsOnIntroUIs();
        inHandsOnMode = true;
        if(handsOnModeIntroPart)
        {
            showHandsOnIntro();
        }
        solarCellAnimator.SetBool("No_Anim", true);
        solarCellAnimator.SetBool("01_Elektrode", false);
        solarCellAnimator.SetBool("02_Schicht", false);
        solarCellAnimator.SetBool("03_Sonne", false);
        solarCellAnimator.SetBool("04_Strom", false);
        solarCellAnimator.SetBool("hands_on", false);
        solarCellAnimator.enabled = false;
        modelManager.setAllModelsInvisible();
        modelManager.setModelsHandsOnMode();
    }

    public void changeToHomeScreen()
    {
        homeScreen.gameObject.SetActive(true);
        guidedTourCanvas.gameObject.SetActive(false);
        guidedIntroductionPanel.SetActive(false);
        guidedFinishPanel.SetActive(false);
        handsOnCanvas.gameObject.SetActive(false);
        inGuidedView = false;
        inHandsOnMode = false;
        handsOnModeIntroPart = true;
        guidedTourIntroductionPart = true;
        SoundManager.instance.stopSound();
        Hue.instance.changeBrightness(0);
        Hue.instance.StopHueCoroutine();
        //solarCellAnimator.SetTrigger("No_Animation");
        guidedTourCounter = -1;
        solarCellAnimator.SetBool("No_Anim", true);
        solarCellAnimator.SetBool("01_Elektrode", false);
        solarCellAnimator.SetBool("02_Schicht", false);
        solarCellAnimator.SetBool("03_Sonne", false);
        solarCellAnimator.SetBool("04_Strom", false);
        solarCellAnimator.SetBool("hands_on", false);
        solarCellAnimator.enabled = false;
        modelManager.setAllModelsInvisible();
    }

    public void showHandsOnIntro()
    {
        Hue.instance.StopHueCoroutine();
        handsOnAngleDistancePanel.SetActive(false);
        handsOnTrackedIconsPanelTop.SetActive(false);
        handsOnInfoPanel.SetActive(false);
        handsOnSlider.SetActive(false);

        disableAllHandsOnIntroUIs();
        handsOnIntroPanel1.SetActive(true);
        solarCellAnimator.SetBool("No_Anim", true);
        solarCellAnimator.SetBool("01_Elektrode", false);
        solarCellAnimator.SetBool("02_Schicht", false);
        solarCellAnimator.SetBool("03_Sonne", false);
        solarCellAnimator.SetBool("04_Strom", false);
        solarCellAnimator.SetBool("hands_on", false);
        solarCellAnimator.enabled = false;
        modelManager.setAllModelsInvisible();
        modelManager.setModelsHandsOnMode();
    }

    public void increaseHandsOnIntroPart()
    {
        if(handsOnIntroPanel1.activeSelf)
        {
            disableAllHandsOnIntroUIs();
            handsOnIntroPanel2.SetActive(true);
        } else if (handsOnIntroPanel2.activeSelf)
        {
            disableAllHandsOnIntroUIs();
            handsOnIntroPanel3.SetActive(true);
        }
    }

    public void increaseHandsOnIntroDetailPart()
    {
        Debug.Log("Showing handsOn Intro Detail");
        Hue.instance.StopHueCoroutine();
        if (handsOnIntroDetailPanel1.activeSelf)
        {

            Debug.Log("First");
            disableAllHandsOnIntroUIs();
            handsOnIntroDetailPanel2.SetActive(true);
        } else if(handsOnIntroDetailPanel2.activeSelf)
        {

            Debug.Log("Second");
            disableAllHandsOnIntroUIs();
            handsOnIntroDetailPanel3.SetActive(true);
        } else
        {

            Debug.Log("Third");
            disableAllHandsOnIntroUIs();
            handsOnIntroDetailPanel1.SetActive(true);
        }
    }

    public void changeToHandsOnModeHandsOnPart()
    {
        handsOnTrackedIconsPanelTop.SetActive(true);
        handsOnAngleDistancePanel.SetActive(true);
        handsOnInfoPanel.SetActive(true);
        handsOnSlider.SetActive(true);
        disableAllHandsOnIntroUIs();
        Hue.instance.StartHueCoroutine();

        solarCellAnimator.enabled = true;
        solarCellAnimator.SetBool("No_Anim", false);
        solarCellAnimator.SetBool("01_Elektrode", false);
        solarCellAnimator.SetBool("02_Schicht", false);
        solarCellAnimator.SetBool("03_Sonne", false);
        solarCellAnimator.SetBool("04_Strom", false);
        solarCellAnimator.SetBool("hands_on", true);
    }

    public void changeToGuidedTourExplanationPart()
    {
        guidedTourIntroductionPart = false;
        guidedIntroductionPanel.SetActive(false);
        guidedExplanationPanel.SetActive(true);
        guidedFinishPanel.SetActive(false);
        guidedTourChange(true);
    }

    public void changeMuteImage()
    {
        //Checks whether sound is muted. Checks after Sound should have been muted successfully.
        if(SoundManager.instance.soundMuted)
        {
            guidedMuteImageField.GetComponent<UnityEngine.UI.Image>().sprite = unmuteSprite;
        } else
        {
            guidedMuteImageField.GetComponent<UnityEngine.UI.Image>().sprite = muteSprite;
        }
    }

    public void handsOnEnableNextButtonAfterTracked()
    {
        //handsOnTrackedNextButton.GetComponent<UnityEngine.UI.Image>().sprite = unmuteSprite;
        handsOnTrackedNextButton.interactable = true;
    }

    public void guidedTourChange(bool increase)
    {
        //Debug.Log(guidedTourCounter);

        if (increase && guidedTourCounter <= titles.Count)
        {
            guidedTourCounter++;
        } else if (guidedTourCounter >= 0)
        {
            guidedTourCounter--;
        }


        if (guidedTourCounter == 0)
        {
            prevBtn.interactable = false;
        }
        else if (guidedTourCounter == titles.Count)
        {
            // Activate new UI
            Hue.instance.changeBrightness(0);
            guidedTourIntroductionPart = false;
            guidedExplanationPanel.SetActive(false);
            guidedIntroductionPanel.SetActive(false);
            SoundManager.instance.playSound("Guided-End");
            //solarCellAnimator.SetTrigger("No_Animation");
            solarCellAnimator.enabled = false;
            guidedFinishPanel.SetActive(true);
            modelManager.setAllModelsInvisible();
            return;
        }
        else
        {
            prevBtn.interactable = true;
            nextBtn.interactable = true;
        }

        title.text = titles[guidedTourCounter];
        text.text = texts[guidedTourCounter];
        string audioFileIndex = guidedTourCounter.ToString();
        string audioFileName = "Guided" + audioFileIndex;
        SoundManager.instance.playSound(audioFileName);

        switch(guidedTourCounter)
        {
            case 0:
                guidedQRCode.SetActive(true);
                modelManager.setAllModelsInvisible();
                modelManager.setFirstModelinGuideMode();
                break;
            case 1:
                guidedQRCode.SetActive(false);
                modelManager.setAllModelsInvisible();
                modelManager.setFirstModelinGuideMode();
                break;
            case 2:
                modelManager.setAllModelsInvisible();
                modelManager.setFirstModelinGuideMode();
                break;
            case 3:
                modelManager.setAllModelsInvisible();
                modelManager.setNLayerModelinGuideMode();
                break;
            case 4:
                modelManager.setAllModelsInvisible();
                modelManager.setNAtomLayerModelinGuideMode();
                break;
            case 5:
                modelManager.setAllModelsInvisible();
                modelManager.setPLayerModelinGuideMode();
                break;
            case 6:
                modelManager.setAllModelsInvisible();
                modelManager.setPAtomLayerModelinGuideMode();

                break;
            case 7:
                modelManager.setAllModelsInvisible();
                modelManager.setContactLayerModelinGuideMode();
                break;
            case 8:
                modelManager.setAllModelsInvisible();
                modelManager.setContactLayerModelinGuideMode();
                break;
            case 9:
                modelManager.setAllModelsInvisible();
                modelManager.setContactLayerModelinGuideMode();
                break;
            case 10:
                modelManager.setAllModelsInvisible();
                modelManager.setAnimationMode();
                break;
            case 11:
                modelManager.setAllModelsInvisible();
                modelManager.setAnimationMode();
                break;
            case 12:
                modelManager.setAllModelsInvisible();
                modelManager.setElectronLayerModelinGuideMode();
                break;
            case 13:
                modelManager.setAllModelsInvisible();
                modelManager.setElectronLayerModelinGuideMode();
                break;
            case 14:
                modelManager.setAllModelsInvisible();
                modelManager.setHolesLayerModelinGuideMode();
                break;
            case 15:
                modelManager.setAllModelsInvisible();
                modelManager.setHolesLayerModelinGuideMode();
                solarCellAnimator.enabled = false;
                solarCellAnimator.SetBool("hands_on", false);
                solarCellAnimator.SetBool("No_Anim", true);
                solarCellAnimator.SetBool("01_Elektrode", false);
                break;
            case 16:
                solarCellAnimator.enabled = true;
                modelManager.setAllModelsInvisible();
                modelManager.setAnimationMode();
                solarCellAnimator.SetBool("01_Elektrode", true);
                solarCellAnimator.SetBool("No_Anim", false);
                solarCellAnimator.SetBool("02_Schicht", false);
                Debug.Log("Play 1 Animation!!!");
                //solarCellAnimator.SetTrigger("01_Elektroden");
                break;
            case 17:
                modelManager.setAllModelsInvisible();
                //PNJunction
                modelManager.setJunctionLayer();
                //solarCellAnimator.SetTrigger("No_Animation");
                solarCellAnimator.enabled = false;
                break;
            case 18:
                modelManager.setAllModelsInvisible();
                // + and - model for changed poles
                modelManager.setAnimationMode();
                solarCellAnimator.enabled = true;
                solarCellAnimator.SetBool("01_Elektrode", false);
                solarCellAnimator.SetBool("02_Schicht", true);
                solarCellAnimator.SetBool("03_Sonne", false);
                //solarCellAnimator.SetTrigger("02_Schichten");
                break;
            case 19:
                Hue.instance.changeBrightness(0);
                modelManager.setAllModelsInvisible();
                modelManager.setAnimationModeWithContacts();
                solarCellAnimator.enabled = true;
                //solarCellAnimator.SetTrigger("03_Sonnenstrahl");
                solarCellAnimator.SetBool("03_Sonne", true);
                solarCellAnimator.SetBool("02_Schicht", false);
                 solarCellAnimator.SetBool("04_Strom", false);
                break;
            case 20:
                modelManager.setAllModelsInvisible();
                // new wire for house
                modelManager.setApplianceAnimationMode();
                solarCellAnimator.enabled = true;
                //solarCellAnimator.SetTrigger("04_Stromkreis");
                // Anim 04
                solarCellAnimator.SetBool("03_Sonne", false);
                solarCellAnimator.SetBool("04_Strom", true);
                break;
            case 21:
                modelManager.setAllModelsInvisible();
                modelManager.setApplianceAnimationMode();
                // Anim 04 weiter
                break;
            default: 
                break;
        }
    }

    public void turnLampOnGuidedMode()
    {
        Hue.instance.changeBrightness(200);
    }

    private void disableAllHandsOnIntroUIs()
    {
        handsOnIntroPanel1.SetActive(false);
        handsOnIntroPanel2.SetActive(false);
        handsOnIntroPanel3.SetActive(false);
        handsOnIntroDetailPanel1.SetActive(false);
        handsOnIntroDetailPanel2.SetActive(false);
        handsOnIntroDetailPanel3.SetActive(false);
    }
}
