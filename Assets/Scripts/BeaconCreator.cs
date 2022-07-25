using UnityEngine;

public class BeaconCreator : MonoBehaviour
{
    public GameObject activeBeacon { get; private set; } //keeps a reference to the currently selected beacon type
    private PlayerEnergy playerEnergyScript;

    void Start()
    {
        playerEnergyScript = GetComponent<PlayerEnergy>(); 
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B) && Time.timeScale != 0)
        {
            if (playerEnergyScript.BeaconCreated()) //If player has enough energy, this will return true
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
