using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    [SerializeField] private List<String> texts = new List<String>();
    [SerializeField] private Canvas homeScreen;
    [SerializeField] private Canvas guidedTourCanvas;
    [SerializeField] private Canvas handsOnCanvas;

    [SerializeField] private GameObject handsOnTrackedIconsPanel;
    [SerializeField] private GameObject handsOnExplanationPanel;
    [SerializeField] private GameObject guidedMuteImageField;
    [SerializeField] private GameObject handsOnMuteImageField;

    [SerializeField] private GameObject guidedIntroductionPanel;
    [SerializeField] private GameObject guidedExplanationPanel;
    [SerializeField] private Sprite muteSprite;
    [SerializeField] private Sprite unmuteSprite;

    private int textCounter = 0;
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
        homeScreen.gameObject.SetActive(false);
        handsOnCanvas.gameObject.SetActive(false);
        guidedTourCanvas.gameObject.SetActive(true);
        inGuidedView = true;
        if(guidedTourIntroductionPart)
        {
            guidedIntroductionPanel.SetActive(true);
            guidedExplanationPanel.SetActive(false);
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
        handsOnCanvas.gameObject.SetActive(false);
        inGuidedView = false;
        inHandsOnMode = false;
    }


    public void changeToHandsOnModeHandsOnPart()
    {
        handsOnModeExplanationPart = false;
        handsOnTrackedIconsPanel.SetActive(true);
        handsOnExplanationPanel.SetActive(false);
    }

    public void changeToGuidedTourExplanationPart()
    {
        guidedTourIntroductionPart = false;
        guidedExplanationPanel.SetActive(true);
        guidedIntroductionPanel.SetActive(false);
    }

    public void changeMuteImage()
    {
        //Checks whether sound is muted. Checks after Sound should have been muted successfully.
        if(SoundManager.instance.soundMuted)
        {
            guidedMuteImageField.GetComponent<UnityEngine.UI.Image>().sprite = unmuteSprite;
            handsOnMuteImageField.GetComponent<UnityEngine.UI.Image>().sprite = muteSprite;
        } else
        {
            guidedMuteImageField.GetComponent<UnityEngine.UI.Image>().sprite = muteSprite;
            handsOnMuteImageField.GetComponent<UnityEngine.UI.Image>().sprite = muteSprite;
        }
    }
}
