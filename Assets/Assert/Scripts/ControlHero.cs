using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHero : MonoBehaviour
{
    GameObject player;
    Transform playerTrans;
    Rigidbody2D playerR;
    MoveState ms;
    enum MoveState { 
        idle,
        running,
        jumping,
        falling,
    }

    public float velocity;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ms = MoveState.idle;
        playerTrans = player.GetComponent<Transform>();
        playerR = player.GetComponent<Rigidbody2D>();

        velocity = 1;
        jumpForce = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // control
        switch (ms)
        {
            case MoveState.idle:
                // idle to moving
                if (Input.GetKey("a"))
                {
                    playerR.velocity = new Vector2(-velocity, 0);
                    ms = MoveState.running;
                }
                if (Input.GetKey("d"))
                {
                    playerR.velocity = new Vector2(velocity, 0);
                    ms = MoveState.running;
                }
                // idle to jumping
                if (Input.GetKey(KeyCode.Space))
                {
                    playerR.velocity = new Vector2(0, jumpForce);
                    ms = MoveState.jumping;
                }
                break;
            case MoveState.running:
                // moving to moving
                if (Input.GetKey("a"))
                {
                    playerR.velocity = new Vector2(-velocity, 0);
                }
                if (Input.GetKey("d"))
                {
                    playerR.velocity = new Vector2(velocity, 0);
                }
                // moving to idle
                if (playerR.velocity.x == 0)
                {
                    ms = MoveState.idle;
                }
                // moving to jumping
                if (Input.GetKey(KeyCode.Space))
                {
                    playerR.velocity += new Vector2(0, jumpForce);
                    ms = MoveState.jumping;
                }
                // moving to falling
                if (playerR.velocity.y < 0)
                {
                    Debug.Log("I'm falling");
                    ms = MoveState.falling;
                }
                break;
            case MoveState.jumping:
                // jumping to falling
                if (playerR.velocity.y < 0)
                {
                    Debug.Log("I'm falling");
                    ms = MoveState.falling;
                }
                // turn around while jumping
                break;
            case MoveState.falling:
                // falling to idle
                if (playerR.velocity.y == 0)
                {
                    ms = MoveState.idle;
                }
                break;
        }
    }

    
}
