using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArmyCountUI : MonoBehaviour
{

    public Text scoreText;
    public PlayerController player;

    void Start()
    {
        scoreText = GetComponent<Text>();  // if you want to reference it by code - tag it if you have several texts
    }

    void Update()
    {
        scoreText.text = player.armySize.ToString();  // make it a string to output to the Text object
    }
}
