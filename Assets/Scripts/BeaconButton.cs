using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BeaconButton : MonoBehaviour
{
    public event Action<GameObject, string> Clicked;
    [SerializeField] GameObject beaconPrefab;

    private int smallSize = 25;
    private int bigSize = 50;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetBeacon);
    }

    void SetBeacon()
    {
        Debug.Log($"SET Beacon click in button => {gameObject.name}");
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

    public GameObject GetBeaconObject()
    {
        return beaconPrefab;
    }
}
