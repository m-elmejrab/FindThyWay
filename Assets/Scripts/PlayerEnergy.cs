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

    public void ResetEnergy()
    {
        reincarnations--;
        energy = originalEnergy;
        UIManager.instance.UpdateReincarnation(reincarnations);
        UIManager.instance.UpdateEnergy(energy);
    }

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

    public int GetEnergyRemaining()
    {
        return energy;
    }

    public int GetLivesRemaining()
    {
        return reincarnations;
    }
}
