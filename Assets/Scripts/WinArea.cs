using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour //Gameobject script that checks if player reached the end of the maze
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player"))
        {
            GameManager.instance.GameWon();
        }
    }
}
