using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float limitY = 4.3f;
    private float limitX = 6.1f;
    public GameManager gameManager;

    //sounds
    public AudioSource hitSound;
    public AudioSource scoreSound;

    [SerializeField] 
    float velocity = 6;
    float radius;
    Vector2 direction;

    GameObject player;
    Score script;
    

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; //direction is 1,1
        radius = transform.localScale.x /2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * velocity * Time.deltaTime);

        //Bounce off and bottom
        if(transform.position.y < -limitY && direction.y < 0){
            direction.y = -direction.y;
        }

        if(transform.position.y > limitY && direction.y > 0){
            direction.y = -direction.y;
        }

        //Points
        if(transform.position.x < -limitX && direction.x < 0){
            //Debug.Log("Point for Player2");
            OnGoal(false);
        }

        if(transform.position.x > limitX && direction.x > 0){
            //Debug.Log("Point for Player1");
            OnGoal(true);
        }
    }

    private void OnGoal(bool player1)
    {
        Debug.Log(gameManager.gameOver);
        if(!gameManager.gameOver){
            scoreSound.Play();
            if(player1)
            {
                player = GameObject.FindWithTag("Player1");
            }
            else
            {
                player = GameObject.FindWithTag("Player2");
            }
            script = player.GetComponent<Score>();
            script.scoreValue ++;
            transform.position = new Vector2(0,0);
            if(script.scoreValue >= script.MaxScore)
            {
                gameManager.OnGameOver(player);
            }
        }
        direction.x = -direction.x;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Pad")
        {
            hitSound.Play();
            direction.x = -direction.x;
        }
    }
}
