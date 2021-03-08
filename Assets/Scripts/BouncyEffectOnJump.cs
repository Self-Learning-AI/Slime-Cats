using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyEffectOnJump : MonoBehaviour
{
    public float maxSize;
    public float scaleSpeed;
    public float delay;

    private bool jumping;

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.canJump && jumping == false)
        {
            jumping = true;
            Morph();
        }
        else if (player.canJump)
        {
            jumping = false;
        }
    }

    void Morph()
    {
        while (maxSize > transform.localScale.y)
        {
            transform.localScale += new Vector3(0, 1, 0) * Time.deltaTime * scaleSpeed;
        }
        // wait

        while (1 < transform.localScale.y)
        {
            transform.localScale -= new Vector3(0, 1, 0) * Time.deltaTime * scaleSpeed;
        }
    }
}
