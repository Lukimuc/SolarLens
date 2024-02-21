using UnityEngine;
using UnityEngine.UI;

public class TrackerManager : MonoBehaviour
{
    [SerializeField] private Sprite solarTrackedSprite;
    [SerializeField] private Sprite sunTrackedSprite;

    public Image solarTrackedImageField;
    public Image sunTrackedImageField;

    private Sprite solarNotTrackedImage;
    private Sprite sunNotTrackedImage;

    private bool solarCellTracked = false;
    private bool sunTracked = false;


    // Start is called before the first frame update
    void Start()
    {
        solarNotTrackedImage = solarTrackedImageField.sprite;
        sunNotTrackedImage = sunTrackedImageField.sprite;
    }


    public void solarCellTracking()
    {
        if (!solarCellTracked)
        {
            solarTrackedImageField.sprite = solarTrackedSprite;
            solarCellTracked = true;
        }
    }

    public void solarCellLostTracking()
    {
        solarCellTracked = false;
        solarTrackedImageField.sprite = solarNotTrackedImage;
    }

    public void sunTracking()
    {
        if(!sunTracked)
        {
            sunTrackedImageField.sprite = sunTrackedSprite;
            sunTracked = true;
        }
    }

    public void sunNotTracking()
    {
        sunTracked = false;
        sunTrackedImageField.sprite = sunNotTrackedImage;
    }
}
