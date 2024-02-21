using UnityEngine;
using UnityEngine.UI;

public class TrackerManager : MonoBehaviour
{
    [SerializeField] private Sprite solarTrackedSprite;
    [SerializeField] private Sprite sunTrackedSprite;

    public Image solarTrackedImageFieldTop;
    public Image solarTrackedImageFieldMid;
    public Image sunTrackedImageFieldTop;
    public Image sunTrackedImageFieldMid;

    private Sprite solarNotTrackedImage;
    private Sprite sunNotTrackedImage;

    private bool solarCellTracked = false;
    private bool sunTracked = false;


    // Start is called before the first frame update
    void Start()
    {
        solarNotTrackedImage = solarTrackedImageFieldTop.sprite;
        sunNotTrackedImage = sunTrackedImageFieldTop.sprite;
    }


    public void solarCellTracking()
    {
        if (!solarCellTracked)
        {
            solarTrackedImageFieldTop.sprite = solarTrackedSprite;
            solarTrackedImageFieldMid.sprite = solarTrackedSprite;
            solarCellTracked = true;
        }
        if(solarCellTracked && sunTracked)
        {
            GUIManager.instance.handsOnEnableNextButtonAfterTracked();
        }
    }

    public void solarCellLostTracking()
    {
        solarCellTracked = false;
        solarTrackedImageFieldTop.sprite = solarNotTrackedImage;
        solarTrackedImageFieldMid.sprite = solarNotTrackedImage;
    }

    public void sunTracking()
    {
        //Debug.Log("Sun Tracking: " + sunTracked);
        if(!sunTracked)
        {
            sunTrackedImageFieldTop.sprite = sunTrackedSprite;
            sunTrackedImageFieldMid.sprite = sunTrackedSprite;
            sunTracked = true;
        }
        if (solarCellTracked && sunTracked)
        {
            GUIManager.instance.handsOnEnableNextButtonAfterTracked();
        }
    }

    public void sunNotTracking()
    {
        sunTracked = false;
        sunTrackedImageFieldTop.sprite = sunNotTrackedImage;
        sunTrackedImageFieldMid.sprite = sunNotTrackedImage;
    }
}
