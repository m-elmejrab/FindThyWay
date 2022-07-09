using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconCreator : MonoBehaviour
{
    public GameObject activeBeacon {get; private set;}
    private PlayerEnergy pEnergyScript;

    // Start is called before the first frame update
    void Start()
    {
        pEnergyScript = GetComponent<PlayerEnergy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.B)&& Time.timeScale !=0)
        {
            if(pEnergyScript.BeaconCreated())
            {
                Instantiate(activeBeacon, transform.position, Quaternion.identity);

            }
            
        }
    }

    public void SetNewBeacon(GameObject beaconPrefab)
    {
        activeBeacon = beaconPrefab;
    }
}
