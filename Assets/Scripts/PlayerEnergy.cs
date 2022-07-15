using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] int energy;
    [SerializeField] int reincarnations;
    [SerializeField] int beaconEnergyConsumption;

    int originalEnergy;
    void Start()
    {
        GetComponent<PlayerMovement>().PlayerMoved += HandleMovement;
        originalEnergy = energy;
    }

    private void HandleMovement()
    {
        //Reduce energy when walking, check for game over
        energy--;
        UIManager.instance.UpdateEnergy(energy);
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (energy <= 0)
        {
            if (reincarnations > 0)
            {
                GameManager.instance.EnergyDepleted();
            }
            else
            {
                GameManager.instance.GameOver();
            }
        }
    }

    /// <summary>
    /// Resets energy to initial value after respawning
    /// </summary>
    public void ResetEnergy()
    {
        reincarnations--;
        energy = originalEnergy;
        UIManager.instance.UpdateReincarnation(reincarnations);
        UIManager.instance.UpdateEnergy(energy);
    }

    /// <summary>
    /// Returns true if enough energy available to create beacon
    /// </summary>
    public bool BeaconCreated()
    {
        if (energy > beaconEnergyConsumption)
        {
            energy -= beaconEnergyConsumption;
            UIManager.instance.UpdateEnergy(energy);
            SoundManager.instance.PlayOrbCreationSound();
            return true;
        }
        else
        {
            return false;
        }


    }

    public int GetEnergy()
    {
        return energy;
    }

    public int GetReincarnations()
    {
        return reincarnations;
    }
}
