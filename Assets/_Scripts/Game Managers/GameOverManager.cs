using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    
    private void OnEnable() { PlayerDeathComponent.playerDied += InitiateGameOver; }
    private void OnDisable() { PlayerDeathComponent.playerDied -= InitiateGameOver; }

    private void InitiateGameOver()
    {
        Debug.Log("Game Over :D");
    }
}
