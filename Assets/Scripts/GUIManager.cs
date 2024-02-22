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

    [SerializeField] private GameObject handsOnTrackedIconsPanelTop;
    [SerializeField] private UnityEngine.UI.Button handsOnTrackedNextButton;
    [SerializeField] private GameObject handsOnAngleDistancePanel;
    [SerializeField] private GameObject handsOnInfoPanel;
    [SerializeField] private GameObject handsOnIntroPanel1;
    [SerializeField] private GameObject handsOnIntroPanel2;
    [SerializeField] private GameObject handsOnIntroPanel3;
    [SerializeField] private GameObject handsOnIntroDetailPanel1;
    [SerializeField] private GameObject handsOnIntroDetailPanel2;
    [SerializeField] private GameObject handsOnIntroDetailPanel3;
    [SerializeField] private GameObject guidedMuteImageField;

    [SerializeField] private GameObject guidedIntroductionPanel;
    [SerializeField] private GameObject guidedExplanationPanel;
    [SerializeField] private GameObject guidedQRCode;
    [SerializeField] private GameObject guidedFinishPanel;
    [SerializeField] private Sprite muteSprite;
    [SerializeField] private Sprite unmuteSprite;

    private int guidedTourCounter = -1;
    private bool inGuidedView = false;
    public bool inHandsOnMode = false;
    private bool handsOnNextButtonActivated = false;

    public bool handsOnModeIntroPart = true;
    private bool guidedTourIntroductionPart = true;

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
        if(guidedTourIntroductionPart)
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
        guidedTourIntroductionPart = true;
        Hue.instance.StopHueCoroutine();
        guidedTourCounter = -1;
    }

    public void showHandsOnIntro()
    {
        Hue.instance.StopHueCoroutine();
        handsOnAngleDistancePanel.SetActive(false);
        handsOnTrackedIconsPanelTop.SetActive(false);
        disableAllHandsOnIntroUIs();
        handsOnIntroPanel1.SetActive(true);
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
        handsOnModeIntroPart = false;
        handsOnTrackedIconsPanelTop.SetActive(true);
        handsOnAngleDistancePanel.SetActive(true);
        disableAllHandsOnIntroUIs();
        Hue.instance.StartHueCoroutine();
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
        else if (guidedTourCounter == (titles.Count))
        {
            // Activate new UI
            Hue.instance.changeBrightness(0);
            guidedTourIntroductionPart = false;
            guidedExplanationPanel.SetActive(false);
            guidedIntroductionPanel.SetActive(false);
            guidedFinishPanel.SetActive(true);
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
                break;
            case 16:
                modelManager.setAllModelsInvisible();
                modelManager.setAnimationMode();
                break;
            case 17:
                modelManager.setAllModelsInvisible();
                //PNJunction
                modelManager.setJunctionLayer();
                break;
            case 18:
                modelManager.setAllModelsInvisible();
                // + and - model for changed poles
                modelManager.setAnimationMode();
                break;
            case 19:
                modelManager.setAllModelsInvisible();
                modelManager.setAnimationModeWithContacts();
                break;
            case 20:
                Hue.instance.changeBrightness(200);
                modelManager.setAllModelsInvisible();
                // new wire for house
                modelManager.setApplianceAnimationMode();
                break;
            case 21:
                modelManager.setAllModelsInvisible();
                modelManager.setApplianceAnimationMode();
                break;
            default: 
                break;
        }
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
