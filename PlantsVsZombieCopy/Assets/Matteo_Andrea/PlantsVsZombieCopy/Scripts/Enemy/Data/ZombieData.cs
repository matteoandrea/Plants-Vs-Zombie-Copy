using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zombie_Type", menuName = "Zombie/ Zombie Type", order = 1)]
public class ZombieData : ScriptableObject
{
    public Pool pool;
    public int maxHealth;
    public float range;
    public int AttackPower;
}
