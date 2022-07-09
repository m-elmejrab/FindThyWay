using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameplayCanvas canvas;

    public void UpdateEnergy(int energy)
    {
        canvas.UpdateEnergyText(energy);
    }

    public void UpdateReincarnation(int reinca)
    {
        canvas.UpdateReincarnationText(reinca);
    }
    
}
