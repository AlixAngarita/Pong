using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadMovement : MonoBehaviour
{
    //Moves the player alongside the y axis

    //movement velocity
    [Tooltip("Velocity in Unity units")]
    [SerializeField] private float velocity = 0.01f; //visible to editor

    [Header("Controles para el game pad")]
    [SerializeField] private KeyCode upControl;
    [SerializeField] private KeyCode downControl;

    private Rigidbody2D _rigidbody2D;
    private float xOff;
    private float padLimit = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        xOff = gameObject.GetComponent<SpriteRenderer>().size.x / 2;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //read control and apply movement
        if(Input.GetKey(upControl))
        {
            transform.Translate(0f,velocity,0f);
        }
        else if(Input.GetKey(downControl))
        {
            transform.Translate(0f,-velocity,0f);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -padLimit, padLimit), transform.position.z);
    }
}