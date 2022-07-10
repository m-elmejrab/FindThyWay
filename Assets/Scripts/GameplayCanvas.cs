using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] Text energyText;

    [SerializeField] Text reincarnationText;

    [SerializeField] GameObject tutorialPrefab;

    [SerializeField] GameObject winMessage;

    [SerializeField] GameObject lossMessage;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject helpButton;


    public void UpdateEnergyText(int energy)
    {
        energyText.text = energy.ToString();
    }

    public void UpdateReincarnationText(int reinc)
    {
        reincarnationText.text = reinc.ToString();
    }

    public void DisplayTutorial()
    {
        SoundManager.instance.PlayClickSound();
        tutorialPrefab.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideTutorial()
    {
        SoundManager.instance.PlayClickSound();

        tutorialPrefab.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ShowWinMessage()
    {
        winMessage.SetActive(true);
        helpButton.SetActive(false);
        Time.timeScale = 0f;


    }
    public void ShowLossMessage()
    {
        lossMessage.SetActive(true);
        helpButton.SetActive(false);

        Time.timeScale = 0f;
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        helpButton.SetActive(false);
        Time.timeScale = 0f;


    }

    public void HidePauseMenu()
    {
        SoundManager.instance.PlayClickSound();

        pauseMenu.SetActive(false);
        helpButton.SetActive(true);
        Time.timeScale = 1f;


    }
}
