using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevel : MonoBehaviour
{
    public TowerLevelData levelData;
    //public GameObject buildEffectPrefab;    


    public int cost
    {
        get { return levelData.cost; }
    }

    public int sell
    {
        get { return levelData.sell; }
    }


    public int maxHealth
    {
        get { return levelData.maxHealth; }
    }


    public string description
    {
        get { return levelData.description; }
    }

    public string upgradeDescription
    {
        get { return levelData.upgradeDescription; }
    }

    public int damage
    {
        get { return levelData.damage; }
    }

    public float fireRate
    {
        get { return levelData.fireRate; }
    }

    public float range
    {
        get { return levelData.range; }
    }
}
