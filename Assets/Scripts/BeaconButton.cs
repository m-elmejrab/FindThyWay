using UnityEngine;
using UnityEngine.UI;
using System;

public class BeaconButton : MonoBehaviour
{
    public event Action<GameObject, string> Clicked;
    [SerializeField] GameObject beaconPrefab;

    private int notSelectedIconSize = 25; 
    private int selectedIconSize = 50; 

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetBeacon);
    }

    void SetBeacon()
    {
        SoundManager.instance.PlayClickSound();
        Clicked?.Invoke(beaconPrefab, gameObject.name);
    }

    public void SetSize(bool isActive)
    {
        if(isActive)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(selectedIconSize, selectedIconSize);
        }
        else
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(notSelectedIconSize, notSelectedIconSize);
        }
    }

    public GameObject GetBeaconObject() //returns the beacon object that should be created 
    {
        return beaconPrefab;
    }
}
