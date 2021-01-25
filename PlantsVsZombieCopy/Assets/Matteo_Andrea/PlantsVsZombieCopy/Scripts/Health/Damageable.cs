using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int currentHealth;
    public bool isDead
    {
        get { return currentHealth <= 0f; }
    } 
    
}
