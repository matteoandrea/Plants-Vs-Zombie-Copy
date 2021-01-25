using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Tower/ Tower Level", order = 1)]
public class TowerLevelData : ScriptableObject
{
    public string description;
    public string upgradeDescription;

    public int cost;
    public int sell;

    public int maxHealth;
    public Sprite icon;    

    public int damage;
    public float fireRate;
    public float range;
}
