using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] int energy;
    [SerializeField] int reincarnations;

    int originalEnergy;
    void Start()
    {
        GetComponent<PlayerMovement>().PlayerMoved += HandleMovement;
        UIManager.instance.UpdateEnergy(energy);
        originalEnergy = energy;
        UIManager.instance.UpdateReincarnation(reincarnations);
    }

    private void HandleMovement()
    {
        energy--;
        UIManager.instance.UpdateEnergy(energy);
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if(energy<=0)
        {
            if(reincarnations>0)
            {
                GameManager.instance.EnergyDepleted();
            }
            else
            {
                GameManager.instance.GameOver();
            }
        }
    }

    public void ResetEnergy()
    {
        reincarnations--;
        energy = originalEnergy;
        UIManager.instance.UpdateReincarnation(reincarnations);
        UIManager.instance.UpdateEnergy(energy);
    }
}
