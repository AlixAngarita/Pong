using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject player1;
    public GameObject player2;

    public void OnGameOver(GameObject player){
        gameOver = true;
        Debug.Log(player.tag + " wins");

        //hide and reset paddles
        player1.SetActive(false); 
        player2.SetActive(false);
    }
}
