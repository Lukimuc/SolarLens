using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using TMPro;

public class PositionController : MonoBehaviour
{
    private ObserverBehaviour trackableBehaviour;

    public GameObject trackedObject;
    
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    public TextMeshProUGUI textPos;
    public TextMeshProUGUI textRot;

    void Start()
    {
        // Get the TrackableBehaviour component
        trackableBehaviour = this.GetComponent<ObserverBehaviour>();
        textPos.text = trackableBehaviour.TargetName;
    }

    
    void Update()
    {
        if(trackableBehaviour.TargetStatus.Status == Status.TRACKED){
            Debug.Log("targetPos: " + trackedObject.transform.position);
            Debug.Log("targetRot: " + trackedObject.transform.rotation);
            textPos.text = "Pos: " + trackedObject.transform.position;
            textRot.text = "Rot: " + trackedObject.transform.rotation;
        }
    }

    /*private void OnTargetStatusChanged(ObserverBehaviour observerbehavour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            // Get the world position and rotation of the tracked image target
            //targetPosition = trackableBehaviour.transform.position;
            //targetRotation = trackableBehaviour.transform.rotation;
            
            Debug.Log("targetPos: " + sphere.transform.position);
            Debug.Log("targetRot: " + sphere.transform.rotation);
            textPos.text = "targetPos: " + sphere.transform.position + ", targetRot: " + sphere.transform.rotation;
        }
        else
        {
            // The tracked image target is lost
        }
    }*/
}



