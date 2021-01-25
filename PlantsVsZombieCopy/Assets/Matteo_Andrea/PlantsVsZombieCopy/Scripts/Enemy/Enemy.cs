using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable
{
    public Pool pool;
    public ZombieData data;

    [SerializeField] private Collider _col;

    [SerializeField] private Animator _anim;

    private int deathAnim = Animator.StringToHash("Death");


    private void OnEnable()
    {
        _col.enabled = true;
        currentHealth = data.maxHealth;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;

        if (isDead)
            StartCoroutine(Kill());
    }

    private IEnumerator Kill()
    {
        _col.enabled = false;
        _anim.SetTrigger(deathAnim);
        yield return new WaitForSeconds(5);        
        pool.ReturnPool(gameObject);
        _anim.SetTrigger(deathAnim);
    }   
}
