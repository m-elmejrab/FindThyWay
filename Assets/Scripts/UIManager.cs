using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> // Singleton class responsible for UI elements
{
    [SerializeField] GameObject easyLevelCanvas; //prefab for easy level
    [SerializeField] GameObject mediumLevelCanvas; //prefab for medium level
    [SerializeField] GameObject hardLevelCanvas; //prefab for hard level

    GameplayCanvas gPlayCanvas;

    public void UpdateEnergy(int energy)
    {
        gPlayCanvas.UpdateEnergyText(energy);
    }

    public void UpdateReincarnation(int reinca)
    {
        gPlayCanvas.UpdateReincarnationText(reinca);
    }

    /// <summary>
    /// Displays correct canvas based on selected difficulty
    /// </summary>
    public void DisplayGameplayCanvas(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                GameObject cObject = Instantiate(easyLevelCanvas);
                gPlayCanvas = cObject.GetComponent<GameplayCanvas>();
                break;

            case 2:
                GameObject cObject2 = Instantiate(mediumLevelCanvas);
                gPlayCanvas = cObject2.GetComponent<GameplayCanvas>();
                break;

            case 3:
                GameObject cObject3 = Instantiate(hardLevelCanvas);
                gPlayCanvas = cObject3.GetComponent<GameplayCanvas>();
                break;
            default:
                break;
        }

    }

    public void DisplayTutorial()
    {
        gPlayCanvas.DisplayTutorial();
    }

    public void DisplayWinMessage()
    {
        gPlayCanvas.ShowWinMessage();
    }

    public void DisplayLossMessage()
    {
        gPlayCanvas.ShowLossMessage();
    }

    public void DisplayPauseMenu()
    {
        gPlayCanvas.ShowPauseMenu();
    }

    public void HidePauseMenu()
    {
        gPlayCanvas.HidePauseMenu();
    }

}
