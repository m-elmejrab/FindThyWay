using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] Text energyText;

    [SerializeField] Text reincarnationText;

    [SerializeField] GameObject tutorialPrefab;

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
        tutorialPrefab.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideTutorial()
    {
        tutorialPrefab.SetActive(false);
        Time.timeScale = 1f;

    }

}
