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

    private int guidedTourCounter = 0;
    private bool inGuidedView = false;
    public bool inHandsOnMode = false;

    public bool handsOnModeExplanationPart = true;
    private bool guidedTourIntroductionPart = true;


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
        guidedTourCounter = 0;
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
        guidedExplanationPanel.SetActive(true);
        guidedIntroductionPanel.SetActive(false);
        guidedFinishPanel.SetActive(false);
        if (guidedTourCounter == 0)
        {
            prevBtn.interactable = false;
        }
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

        if (increase && guidedTourCounter >= 0 && guidedTourCounter <= titles.Count)
        {
            guidedTourCounter++;
        } else guidedTourCounter--;


        if (guidedTourCounter == 0)
        {
            prevBtn.interactable = false;
        }
        else if (guidedTourCounter == (titles.Count - 1))
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
                break;
            default: 
                break;
        }
    }
}
