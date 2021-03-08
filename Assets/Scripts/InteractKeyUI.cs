using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractKeyUI : MonoBehaviour
{
    public Text popUpText;
    public PlayerController player;

    void Start()
    {
        popUpText = GetComponent<Text>();  // if you want to reference it by code - tag it if you have several texts
    }

    void Update()
    {
        if(player.enemyInRange)
        {
            popUpText.text = "Press F to fight";  // make it a string to output to the Text object
        }
        else
        {
            popUpText.text = "";
        }
        
    }
}
