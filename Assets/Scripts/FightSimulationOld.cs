using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSimulationOld : MonoBehaviour
{
    /*
    public PlayerController player;
    public EnemyController enemy;

    private int[] air = new int[2];
    private int[] fire = new int[2];
    private int[] earth = new int[2];
    private int[] water = new int[2];

    public float playerAdvantage;

    private int playerArmySize;
    private int enemyArmySize;

    private float battleOutcome;

    void Start()
    {
        air[0] = player.air;
        air[1] = enemy.air;
        fire[0] = player.fire;
        fire[1] = enemy.fire;
        earth[0] = player.earth;
        earth[1] = enemy.earth;
        water[0] = player.water;
        water[1] = enemy.water;

        playerArmySize = player.armySize;
        enemyArmySize = enemy.armySize;
        Debug.Log("Starting player army : " + playerArmySize);
        Debug.Log("Starting enemy army : " + enemyArmySize);

        Debug.Log("Winner is : " + SimulateFight());
        Debug.Log("BattleOutcome : " + battleOutcome);
        Debug.Log("player army : " + playerArmySize);
        Debug.Log("enemy army : " + enemyArmySize);
    }

    
    void Update()
    {
        
    }

    public string SimulateFight()
    {
        while(playerArmySize != 0 || enemyArmySize != 0)
        {
            // Get a random player unit
            string playerCat = getCat(air[0], fire[0], earth[0], water[0]);
            // Get a random enemy unit
            string enemyCat = getCat(air[1], fire[1], earth[1], water[1]);
            
            // Do advantage calculation
            if (playerCat == "fire" && enemyCat == "earth")
            {
                playerAdvantage = 1.0f;
            }
            else if (playerCat == "earth" && enemyCat == "fire")
            {
                playerAdvantage = -1.0f;
            }
            else if (playerCat == "water" && enemyCat == "fire")
            {
                playerAdvantage = 1.0f;
            }
            else if (playerCat == "fire" && enemyCat == "water")
            {
                playerAdvantage = -1.0f;
            }
            else if (playerCat == "air" && enemyCat == "water")
            {
                playerAdvantage = 1.0f;
            }
            else if (playerCat == "water" && enemyCat == "air")
            {
                playerAdvantage = -1.0f;
            }
            else if (playerCat == "earth" && enemyCat == "air")
            {
                playerAdvantage = 1.0f;
            }
            else if (playerCat == "air" && enemyCat == "earth")
            {
                playerAdvantage = -1.0f;
            }
            else
            {
                playerAdvantage = 0.0f;
            }

            // Calculate a random number between 0 and 4
            // This gives a 50% chance of victory +/- 25% chance from advantage
            battleOutcome = Random.Range(0, 4) + playerAdvantage;
            Debug.Log("BattleOutcome : " + battleOutcome);

            // if player wins, remove an enemy from the enemy army
            if (battleOutcome >= 2.0f)
            {
                enemyArmySize -= 1;
                if (enemyCat == "air")
                {
                    air[1] -= 1;
                }
                else if (enemyCat == "fire")
                {
                    fire[1] -= 1;
                }
                else if (enemyCat == "earth")
                {
                    earth[1] -= 1;
                }
                else if (enemyCat == "water")
                {
                    water[1] -= 1;
                }
            }
            else // if player loses, remove an enemy from the player army
            {
                playerArmySize -= 1;
                if (playerCat == "air")
                {
                    air[0] -= 1;
                }
                else if (playerCat == "fire")
                {
                    fire[0] -= 1;
                }
                else if (playerCat == "earth")
                {
                    earth[0] -= 1;
                }
                else if (playerCat == "water")
                {
                    water[0] -= 1;
                }
            }

        }

        if (playerArmySize > enemyArmySize)
        {
            return "player";
        }
        else
        {
            return "enemy";
        }

    }

    public string getCat(int air, int fire, int earth, int water)
    {
        string[] catType = { "air", "fire", "earth", "water" };
        if(air > fire && air > earth && air > water)
        {
            return catType[0];
        }
        else if (fire > air && fire > earth && fire > water)
        {
            return catType[1];
        }
        else if (earth > air && earth > fire && earth > water)
        {
            return catType[2];
        }
        else if (water > air && water > earth && water > fire)
        {
            return catType[3];
        }
        else if ((air + fire + water + earth) == 0)
        {
            return "none";
        }
        else
        {
            // If they're all the same quantity, return a random cat
            return catType[Random.Range(0, 3)];
        }
    }

    */
}
