using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    GameObject player;
    PlayerMovement movementScript;
    PlayerEnergy energyScript;
    bool firstLoadEver = true;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);

        if(index == 1)
        {
            StartCoroutine(LinkObjectAfterLoad());
        }
    }

    IEnumerator LinkObjectAfterLoad()
    {
        yield return new WaitForSeconds(0.02f);
        //yield return new WaitForEndOfFrame();
        player = GameObject.FindGameObjectWithTag("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        energyScript = player.GetComponent<PlayerEnergy>();
        UIManager.instance.DisplayGameplayCanvas();
        UIManager.instance.UpdateEnergy(energyScript.GetEnergy());
        UIManager.instance.UpdateReincarnation(energyScript.GetReincarnations());
        if(firstLoadEver)
        {
            firstLoadEver = false;
            UIManager.instance.DisplayTutorial();
        }

    }

}
