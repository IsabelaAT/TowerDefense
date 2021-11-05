using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    public PayerStats ps;


    // Update is called once per frame
    void Update()
    {
        if (gameEnded) return;

            if (ps.ModifyLives() <= 0)
        {
            EndGame();
        }

        

    }

    void EndGame()
    {
        gameEnded = true; 
        Debug.Log("Game Over");
    }

}
