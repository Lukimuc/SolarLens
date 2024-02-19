using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private List<String> texts = new List<String>();
    [SerializeField] private Canvas homeScreen;
    [SerializeField] private Canvas guidedTourCanvas;
    [SerializeField] private Canvas handsOnCanvas;

    [SerializeField] private GameObject handsOnTrackedIconsPanel;
    [SerializeField] private GameObject handsOnExplanationPanel;

    [SerializeField] private GameObject guidedIntroductionPanel;
    [SerializeField] private GameObject guidedExplanationPanel;

    private int textCounter = 0;
    private bool inGuidedView = false;
    private bool inHandsOnMode = false;

    private bool handsOnModeExplanationPart = true;
    private bool guidedTourIntroductionPart = true;


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
}
