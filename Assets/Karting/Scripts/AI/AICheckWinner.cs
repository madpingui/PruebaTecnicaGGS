using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Check if the AI has done triggers against the finish line and in the second lap, he sends an event so the user lose.
public class AICheckWinner : MonoBehaviour
{
    private int i;
    private const int NUM_OF_COLLIDERS = 7;

    private GameFlowManager GM;
    private void Awake()
    {
        GM = FindObjectOfType<GameFlowManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lap")
        {
            i++;

            if(i / NUM_OF_COLLIDERS == 2 && GM.gameState == GameState.Play)
            {
                GM.EndGame(false);
            }
        }
    }
}
