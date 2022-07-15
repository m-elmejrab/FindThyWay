using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconCreator : MonoBehaviour
{
    public GameObject activeBeacon { get; private set; } //keeps a reference to the currently selected beacon type
    private PlayerEnergy pEnergyScript;

    void Start()
    {
        pEnergyScript = GetComponent<PlayerEnergy>(); //Get reference to player energy script to verify there is enough energy to create a beacon
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B) && Time.timeScale != 0)
        {
            if (pEnergyScript.BeaconCreated()) //If player has enough energy, this will return true
            {
                Instantiate(activeBeacon, transform.position, Quaternion.identity);
            }

        }
    }

    /// <summary>
    /// Set a new type of beacon as active/selected
    /// </summary>
    public void SetNewBeacon(GameObject beaconPrefab)
    {
        activeBeacon = beaconPrefab;
    }
}
