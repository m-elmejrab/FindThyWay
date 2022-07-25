using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    GameObject player;
    PlayerMovement movementScript;
    PlayerEnergy energyScript;
    bool firstLoadEver = true;

    private void Start()
    {
        SoundManager.instance.PlayMainMenuMusic();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0) // checks if the player is on a maze scene i.e. not on main menu
        {
            if (Time.timeScale == 0) //game was paused, continue
            {
                UIManager.instance.HidePauseMenu();
                SoundManager.instance.PauseResumeMusic(true);

            }
            else //game was underway, show pause menu
            {
                UIManager.instance.DisplayPauseMenu();
                SoundManager.instance.PauseResumeMusic(false);
            }
        }
    }

    /// <summary>
    /// Player exhausted all energy, reset position/energy and lose one life
    /// </summary>
    public void EnergyDepleted()
    {
        movementScript.ResetPosition();
        energyScript.ResetEnergy();
    }

    /// <summary>
    /// Player lost all their lives
    /// </summary>
    public void GameOver()
    {
        UIManager.instance.DisplayLossMessage();
        SoundManager.instance.PlayWinOrLose(false);
    }

    /// <summary>
    /// Loads scene by index
    /// </summary>
    public void LoadLevel(int index)
    {
        if (Time.timeScale != 1) //ensure game is not still paused
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
        yield return new WaitForSeconds(0.02f); //Allows UI components to initialize in full

        //Link player object/scripts
        player = GameObject.FindGameObjectWithTag("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        energyScript = player.GetComponent<PlayerEnergy>();

        //Display UI elements
        UIManager.instance.DisplayGameplayCanvas(SceneManager.GetActiveScene().buildIndex);
        UIManager.instance.UpdateEnergy(energyScript.GetEnergyRemaining());
        UIManager.instance.UpdateReincarnation(energyScript.GetLivesRemaining());

        //Shows the tutorial when playing for the first time
        if (firstLoadEver)
        {
            firstLoadEver = false;
            UIManager.instance.DisplayTutorial();
        }
    }

    /// <summary>
    /// Show winning message
    /// </summary>
    public void GameWon()
    {
        UIManager.instance.DisplayWinMessage();
        SoundManager.instance.PlayWinOrLose(true);
    }

    /// <summary>
    /// Resets the level currently being played
    /// </summary>
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
