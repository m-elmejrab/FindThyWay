using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject player;
    PlayerMovement movementScript;
    PlayerEnergy energyScript;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = player.GetComponent<PlayerMovement>();
        energyScript = player.GetComponent<PlayerEnergy>();
    }

    public void EnergyDepleted()
    {
        movementScript.ResetPosition();
        energyScript.ResetEnergy();
    }

    public void GameOver()
    {

        Debug.Log("YOUUUUU LOOOOOOST");
    }
}
