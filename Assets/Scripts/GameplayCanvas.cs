using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameplayCanvas : MonoBehaviour //Class controlling UI elements during gameplay
{
    [SerializeField] Text energyText;

    [SerializeField] Text reincarnationText;

    [SerializeField] GameObject tutorialPrefab;

    [SerializeField] GameObject winMessage;

    [SerializeField] GameObject lossMessage;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject helpButton;


    /// <summary>
    /// Display current level of energy
    /// </summary>
    public void UpdateEnergyText(int energy)
    {
        energyText.text = energy.ToString();
    }

    /// <summary>
    /// Display remaining lives
    /// </summary>
    public void UpdateReincarnationText(int reinc)
    {
        reincarnationText.text = reinc.ToString();
    }

    /// <summary>
    /// Display Tutorial on first playthrough or when help is pressed
    /// </summary>
    public void DisplayTutorial()
    {
        SoundManager.instance.PlayClickSound();
        tutorialPrefab.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Hide tutorial screen
    /// </summary>
    public void HideTutorial()
    {
        SoundManager.instance.PlayClickSound();

        tutorialPrefab.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Display win message when level is completed
    /// </summary>
    public void ShowWinMessage()
    {
        winMessage.SetActive(true);
        helpButton.SetActive(false);
        Time.timeScale = 0f;


    }

    /// <summary>
    /// Display loss message when player runs out of lives
    /// </summary>
    public void ShowLossMessage()
    {
        lossMessage.SetActive(true);
        helpButton.SetActive(false);

        Time.timeScale = 0f;
    }

    /// <summary>
    /// Display the pause menu
    /// </summary>
    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        helpButton.SetActive(false);
        Time.timeScale = 0f;


    }

    /// <summary>
    /// Hides the pause menu
    /// </summary>
    public void HidePauseMenu()
    {
        SoundManager.instance.PlayClickSound();

        pauseMenu.SetActive(false);
        helpButton.SetActive(true);
        Time.timeScale = 1f;


    }
}
