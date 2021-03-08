// Written by Igor Barbosa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Attributes")]
    public int armySize;
    public float damage = 10.0f;
    [Space]

    [Header("Movement")]
    public float moveSpeed = 2.0f;
    public float jumpHeight = 60.0f;
    private float vertical;     // For forwards/backwards movement
    private float horizontal;   // For left/right movement
    private float jump;         // For jump input
    public bool canJump = true;
    private bool canMove = true;
    public bool enemyInRange;
    [Space]

    [Header("Army")]
    public int air;
    public int fire;
    public int earth;
    public int water;
    [Space]

    [Header("Components")]
    public Rigidbody body;
    public Collider collider;
    //public Collider colliderOuter;
    public Animator anim;
    public FightSimulation fightSimulation;
    public BouncyEffect bouncyEffect;
    public SoundManager sounds;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent("Animator") as Animator;
    }

    // Fixed update is better when working with physics
    // Called a set number of times per frame
    private void FixedUpdate()
    {
        //armySize = air + fire + earth + water;
        Move();
        Jump();
        if (Input.GetKeyDown(KeyCode.F) && enemyInRange)
        {
            sounds.PlaySound("fight");
            fightSimulation.SimulateBattle();
        }
    }

    void Move()
    {
        // Check if movement is allowed
        if (canMove)
        {
            // Gets movement axis value from the input manager
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

            // Adds force to x and z axis to make rigid body move
            body.AddRelativeForce(movement * moveSpeed);

            // If there is movement, hop
            if(vertical != 0.0f || horizontal != 0.0f)
            {
                Hop();
            }

            Vector3 newRotation = gameObject.transform.eulerAngles;
            newRotation.y = Camera.main.transform.eulerAngles.y;
            gameObject.transform.eulerAngles = newRotation;

            // Rotate to camera view
            // Vector3 cameraDirection = camera.transform.forward;
            //                   Quaternion.LookRotation(Vector3.Cross(upAxis,  Vector3.Cross(upAxis, Camera.main.transform.forward)), upAxis);
            //transform.rotation = Quaternion.LookRotation(Vector3.Cross(Vector3.up, Vector3.Cross(Vector3.up, cameraDirection)), Vector3.up);
        }
        
    }

    void Hop()
    {
        if(canJump)
        {
            Vector3 hopVector = new Vector3(0.0f, 1.0f, 0.0f);
            body.AddForce(hopVector * (jumpHeight/3));
        }
    }

    void Jump()
    {
        // Check if allowed to jump first
        if (canJump)
        {
            jump = Input.GetAxis("Jump");
            Vector3 jumpVector = new Vector3(0.0f, jump, 0.0f);

            // Adds force to x and z axis to make rigid body move
            body.AddForce(jumpVector * jumpHeight);
        }
    }

    public void LoseUnits(int catsLost)
    {
        if(armySize - catsLost < 0)
        {
            armySize = 0;
        }
        else
        {
            armySize -= catsLost;
        }
    }


    private void Die()
    {
        canMove = false;
        // needs to play death animation
        // needs to play death sounds
        // needs to play UI death screen
    }

    // Called when an object collider collides with this objects collider.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            canJump = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Press F to fight");
            enemyInRange = true;

            sounds.PlaySound("curious");
        }
    }

    // Called when an object collider is no longer colliding with this objects collider.
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            canJump = false;
            // Add bouncy effect
            //if (bouncyEffect)
            //{
            //   StartCoroutine(bouncyEffect.Scale());
            //}
            //sounds.PlaySound
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = false;
        }
    }
}
