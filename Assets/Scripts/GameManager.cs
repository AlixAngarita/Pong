using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject player1;
    public GameObject player2;

    public void OnGameOver(GameObject player)
    {
        gameOver = true;
        Debug.Log(player.tag + " wins");

        //hide and reset paddles
        player1.SetActive(false); 
        player2.SetActive(false);
    }

    public void ShinkPad(bool player1)
    {
        GameObject player;
        if(player1)
        {
            player = GameObject.FindWithTag("Pad1");
        }
        else
        {
            player = GameObject.FindWithTag("Pad2");
        }
        player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y*0.9f ,0f);
    }
}
