using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Attributes")]
    private float health = 100.0f;
    public float damage = 10.0f;
    [Space]

    [Header("Movement")]
    public float moveSpeed = 1.0f;
    public float jumpHeight = 2.0f;
    private float vertical;     // For forwards/backwards movement
    private float horizontal;   // For left/right movement
    private bool canJump = true;
    private bool canMove = true;
    [Space]

    [Header("Abilities")]
    public bool air;
    public bool fire;
    public bool earth;
    public bool water;
    [Space]

    [Header("Components")]
    public Rigidbody body;
    public Collider collider;
    public Animator anim;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fixed update is better when working with physics
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Gets movement axis value from the input manager
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        // Adds force to make rigid body move
        body.AddForce(movement * moveSpeed);
    }

    void Jump()
    {

    }

    public void TakeDamage(float incomingDamage)
    {
        health += incomingDamage;
        if (health < 0.1f)
        {
            Die();
        }
    }

    private void Die()
    {
        canMove = false;
        // needs to play death animation
        // needs to play death sounds
        // needs to play UI death screen
    }

    public void GainAbility(string abilityName)
    {
        switch (abilityName.ToLower())
        {
            case "air":
                air = true;
                break;
            case "fire":
                fire = true;
                break;
            case "earth":
                earth = true;
                break;
            case "water":
                water = true;
                break;
        }

    }
}
