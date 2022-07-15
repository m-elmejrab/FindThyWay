using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconSelector : MonoBehaviour
{
    [SerializeField] List<BeaconButton> beaconButtons;
    BeaconCreator playerBeaconCreator;

    void Start()
    {
        playerBeaconCreator = GameObject.FindGameObjectWithTag("Player").GetComponent<BeaconCreator>();
        foreach (BeaconButton button in beaconButtons)
        {
            button.Clicked += UpdateBeacon; //subscribe to buttons that correspond to different beacon types
        }

        UpdateBeacon(beaconButtons[0].GetBeaconObject(), beaconButtons[0].gameObject.name);
    }

 

    /// <summary>
    /// Update the beacon type in the player script, resize beacon buttons accordingly
    /// </summary>
    void UpdateBeacon(GameObject beaconPrefab, string bName)
    {
        playerBeaconCreator.SetNewBeacon(beaconPrefab);

        foreach (BeaconButton button in beaconButtons)
        {
            if(button.gameObject.name == bName)
            {
                button.SetSize(true);
            }
            else
            {
                button.SetSize(false);

            }
        }
    }

}
