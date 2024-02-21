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

    [SerializeField] private GameObject handsOnTrackedIconsPanel;
    [SerializeField] private GameObject handsOnExplanationPanel;
    [SerializeField] private GameObject guidedMuteImageField;
    [SerializeField] private GameObject handsOnMuteImageField;

    [SerializeField] private GameObject guidedIntroductionPanel;
    [SerializeField] private GameObject guidedExplanationPanel;
    [SerializeField] private GameObject guidedFinishPanel;
    [SerializeField] private Sprite muteSprite;
    [SerializeField] private Sprite unmuteSprite;

    private int guidedTourCounter = -1;
    private bool inGuidedView = false;
    public bool inHandsOnMode = false;

    public bool handsOnModeExplanationPart = true;
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
        inHandsOnMode = true;
        if(handsOnModeExplanationPart)
        {
            handsOnTrackedIconsPanel.SetActive(false);
            handsOnExplanationPanel.SetActive(true);
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
        handsOnModeExplanationPart = true;
        guidedTourIntroductionPart = true;
        Hue.instance.StopHueCoroutine();
        guidedTourCounter = -1;
    }


    public void changeToHandsOnModeHandsOnPart()
    {
        handsOnModeExplanationPart = false;
        handsOnTrackedIconsPanel.SetActive(true);
        handsOnExplanationPanel.SetActive(false);
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
            handsOnMuteImageField.GetComponent<UnityEngine.UI.Image>().sprite = unmuteSprite;
        } else
        {
            guidedMuteImageField.GetComponent<UnityEngine.UI.Image>().sprite = muteSprite;
            handsOnMuteImageField.GetComponent<UnityEngine.UI.Image>().sprite = muteSprite;
        }
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
            //nextBtn.interactable = false;
            // Activate new UI
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

        switch(guidedTourCounter)
        {
            case 0:
                modelManager.setAllModelsInvisible();
                modelManager.setFirstModelinGuideMode();
                break;
            case 1:
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
                modelManager.setAnimationMode();
                break;
            case 18:
                modelManager.setAllModelsInvisible();
                // + and - model for changed poles
                modelManager.setAnimationMode();
                break;
            case 19:
                modelManager.setAllModelsInvisible();
                modelManager.setAnimationMode();
                break;
            case 20:
                modelManager.setAllModelsInvisible();
                // new wire for house
                modelManager.setApplianceAnimationMode();
                break;
            case 21:
                modelManager.setAllModelsInvisible();
                modelManager.setApplianceAnimationMode();
                break;
            case 22:
                modelManager.setAllModelsInvisible();
                break;
            default: 
                break;
        }
    }
}
