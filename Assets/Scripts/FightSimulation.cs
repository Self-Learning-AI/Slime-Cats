using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSimulation : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy;
    public SoundManager sounds;
    public float difficulty = 50.0f;
    public bool startBattle = false;

    private bool victory;
    private float fightScore;
    private int unitLoss = 5;

    // Start is called before the first frame update
    void Start()
    {
        //SimulateBattle();
    }

    // Update is called once per frame
    void Update()
    {
        if (startBattle)
        {
            SimulateBattle();
        }
    }

    public void SimulateBattle()
    {
        //Generate base fight score
        fightScore = Random.Range(0.0f, 100.0f);
        if(player.armySize > enemy.armySize)
        {
            Debug.Log("Army size bonus +5");
            fightScore += 5.0f;
        }
        else if(player.armySize < enemy.armySize)
        {
            Debug.Log("Army size penalty -5");
            fightScore -= 5.0f;
        }

        
        if(fightScore > difficulty)
        {
            // PLAYER WINS
            //player gains cats by losing a negative amount
            //enemy loses cats
            player.LoseUnits(-unitLoss);
            enemy.LoseUnits(unitLoss);
            Debug.Log("Player wins");

            // Play victory sounds
            sounds.PlaySound("victory");
        }
        else
        {
            //PLAYER LOSES
            player.LoseUnits(unitLoss);
            Debug.Log("Enemy wins");
            sounds.PlaySound("loss");
        }
        Debug.Log("Fightscore: " + fightScore);
    }
}
