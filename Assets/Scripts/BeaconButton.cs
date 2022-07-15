using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BeaconButton : MonoBehaviour
{
    public event Action<GameObject, string> Clicked;
    [SerializeField] GameObject beaconPrefab;

    private int smallSize = 25; //size of icon when not selected
    private int bigSize = 50; //size of icon when  selected to use

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
            GetComponent<RectTransform>().sizeDelta = new Vector2(bigSize, bigSize);
        }
        else
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(smallSize, smallSize);
        }
    }

    public GameObject GetBeaconObject() //returns the beacon object that should be created 
    {
        return beaconPrefab;
    }
}
