using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Attributes")]
    public int armySize;
    public float damage = 10.0f;
    [Space]

    [Header("Movement")]
    public float moveSpeed = 1.0f;
    public float jumpHeight = 2.0f;
    [Space]

    [Header("Army")]
    public int air;
    public int fire;
    public int earth;
    public int water;
    [Space]

    [Header("Components")]
    public Rigidbody body;
    public Animator anim;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoseUnits(int catsLost)
    {
        if (armySize - catsLost < 0)
        {
            armySize = 0;
        }
        else
        {
            armySize -= catsLost;
        }
    }


}
