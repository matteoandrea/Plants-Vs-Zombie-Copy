using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Damageable
{
    //public string towerName;
    [Space(10)]
    public TowerLevel[] levels;
    //public Pool[] pools;

    public int currentLevel { get; protected set; }
    public TowerLevel currentTowerLevel { get; protected set; }

    public bool isAtMaxLevel
    {
        get { return currentLevel == levels.Length - 1; }
    }

    public int purchaseCost
    {
        get { return levels[0].cost; }
    }


    public int GetCostForNextLevel()
    {
        if (isAtMaxLevel)
        {
            return -1;
        }
        return levels[currentLevel + 1].cost;
    }

    public int getDamage
    {
        get { return levels[currentLevel].damage; }
    }

    public float getFireRate
    {
        get { return levels[currentLevel].fireRate; }
    }

    public float getRange
    {
        get { return levels[currentLevel].range; }
    }

    
    private void OnEnable()
    {
        currentHealth = levels[0].maxHealth;
        currentTowerLevel = levels[0];
    }
   
}
