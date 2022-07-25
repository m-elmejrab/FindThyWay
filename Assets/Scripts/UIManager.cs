using UnityEngine;

public class UIManager : Singleton<UIManager> // Singleton class responsible for UI elements
{
    [SerializeField] GameObject easyLevelCanvas; //prefab for easy level
    [SerializeField] GameObject mediumLevelCanvas; //prefab for medium level
    [SerializeField] GameObject hardLevelCanvas; //prefab for hard level

    GameplayCanvas gamePlayCanvas;

    public void UpdateEnergy(int energy)
    {
        gamePlayCanvas.UpdateEnergyText(energy);
    }

    public void UpdateReincarnation(int reinca)
    {
        gamePlayCanvas.UpdateRemainingLivesText(reinca);
    }

    public void DisplayGameplayCanvas(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                GameObject cObject = Instantiate(easyLevelCanvas);
                gamePlayCanvas = cObject.GetComponent<GameplayCanvas>();
                break;

            case 2:
                GameObject cObject2 = Instantiate(mediumLevelCanvas);
                gamePlayCanvas = cObject2.GetComponent<GameplayCanvas>();
                break;

            case 3:
                GameObject cObject3 = Instantiate(hardLevelCanvas);
                gamePlayCanvas = cObject3.GetComponent<GameplayCanvas>();
                break;
            default:
                break;
        }

    }

    public void DisplayTutorial()
    {
        gamePlayCanvas.DisplayTutorial();
    }

    public void DisplayWinMessage()
    {
        gamePlayCanvas.ShowWinMessage();
    }

    public void DisplayLossMessage()
    {
        gamePlayCanvas.ShowLossMessage();
    }

    public void DisplayPauseMenu()
    {
        gamePlayCanvas.ShowPauseMenu();
    }

    public void HidePauseMenu()
    {
        gamePlayCanvas.HidePauseMenu();
    }
}
