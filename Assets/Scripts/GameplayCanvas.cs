using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] Text energyText;

    [SerializeField] Text reincarnationText;

    public void UpdateEnergyText(int energy)
    {
        energyText.text = energy.ToString();
    }

    public void UpdateReincarnationText(int reinc)
    {
        reincarnationText.text = reinc.ToString();
    }

}
