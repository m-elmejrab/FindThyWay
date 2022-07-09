using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject gPlayCanvasPrefab;
    GameplayCanvas gPlayCanvas;

    public void UpdateEnergy(int energy)
    {
        gPlayCanvas.UpdateEnergyText(energy);
    }

    public void UpdateReincarnation(int reinca)
    {
        gPlayCanvas.UpdateReincarnationText(reinca);
    }

    public void DisplayGameplayCanvas()
    {
        GameObject cObject = Instantiate(gPlayCanvasPrefab);
        gPlayCanvas = cObject.GetComponent<GameplayCanvas>();
    }

    public void DisplayTutorial()
    {
        gPlayCanvas.DisplayTutorial();
    }
    
}
