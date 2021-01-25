using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class DamageZone: MonoBehaviour
{
    public Damageable damageable;

    public int damageScale = 1;

    protected int ScaleDamage(int damage)
    {
        return damage * damageScale;
    }
}
