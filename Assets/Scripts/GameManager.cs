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

    private void Start() {
        SoundManager.instance.PlayMainMenuMusic();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Time.timeScale == 0)
            {
                UIManager.instance.HidePauseMenu();
                SoundManager.instance.PauseResumeMusic(true);

            }
            else
            {
                UIManager.instance.DisplayPauseMenu();
                SoundManager.instance.PauseResumeMusic(false);
            }
        }
    }

    public void EnergyDepleted()
    {
        movementScript.ResetPosition();
        energyScript.ResetEnergy();
    }

    public void GameOver()
    {

        UIManager.instance.DisplayLossMessage();
        SoundManager.instance.PlayWinOrLose(false);
    }

    public void LoadLevel(int index)
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1f;
        }

        SceneManager.LoadScene(index);

        if (index != 0)
        {
            StartCoroutine(LinkObjectAfterLoad());
            SoundManager.instance.PlayLevelMusic();
        }
        else
        {
            SoundManager.instance.PlayMainMenuMusic();
        }
    }

    IEnumerator LinkObjectAfterLoad()
    {
        yield return new WaitForSeconds(0.02f);
        //yield return new WaitForEndOfFrame();
        player = GameObject.FindGameObjectWithTag("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        energyScript = player.GetComponent<PlayerEnergy>();
        UIManager.instance.DisplayGameplayCanvas(SceneManager.GetActiveScene().buildIndex);
        UIManager.instance.UpdateEnergy(energyScript.GetEnergy());
        UIManager.instance.UpdateReincarnation(energyScript.GetReincarnations());
        if (firstLoadEver)
        {
            firstLoadEver = false;
            UIManager.instance.DisplayTutorial();
        }

    }

    public void GameWon()
    {
        UIManager.instance.DisplayWinMessage();
        SoundManager.instance.PlayWinOrLose(true);

    }

    public void RestartLevel()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1f;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        StartCoroutine(LinkObjectAfterLoad());
        SoundManager.instance.PlayLevelMusic();
    }
}
