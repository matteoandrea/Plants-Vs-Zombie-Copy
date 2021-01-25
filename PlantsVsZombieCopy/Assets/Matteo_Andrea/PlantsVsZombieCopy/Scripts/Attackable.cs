using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
    //public GameObject bulletPrefab;
    [SerializeField] protected bool canAttack = true;
    protected float attackRate;
    [SerializeField]protected LayerMask targetLayer;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;

    protected virtual void attack()
    {
        _source.PlayOneShot(_clip);
        StartCoroutine(NextAttack());
    }

    protected IEnumerator NextAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackRate);
        canAttack = true;
    }
}

