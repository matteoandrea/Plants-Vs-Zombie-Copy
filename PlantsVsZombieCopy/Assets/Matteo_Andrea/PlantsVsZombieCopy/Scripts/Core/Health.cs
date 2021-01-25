
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]private Pool pool;
    [SerializeField] private Tower tower;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clipHit;
    [SerializeField] private AudioClip _clipDeath;

    [SerializeField] private Pool vfxPool;

    [SerializeField] private UnityEvent _deathEvent;

    public void Damage(int damage)
    {
        _source.clip = _clipHit;
        _source.Play();
        tower.currentHealth -= damage;

        if (tower.isDead)
            Kill();
    }

    private void Kill()
    {
        _source.clip = _clipDeath;
        _source.Play();

        if (_deathEvent != null)
            _deathEvent.Invoke();

        vfxPool.GetPool(transform, transform.rotation);
        pool.ReturnPool(gameObject);
    }
}
