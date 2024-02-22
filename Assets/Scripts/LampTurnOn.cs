using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTurnOn : MonoBehaviour
{
    public void lampTurnOn()
    {
        GUIManager.instance.turnLampOnGuidedMode();
    }
}
