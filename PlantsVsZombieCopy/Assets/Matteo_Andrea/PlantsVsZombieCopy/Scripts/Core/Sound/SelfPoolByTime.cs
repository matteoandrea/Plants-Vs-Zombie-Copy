using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelfPoolByTime : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private float _time;
    [SerializeField] private UnityEvent _deathEvent;

    IEnumerator PoolSelf()
    {
        yield return new WaitForSeconds(_time);

        _deathEvent.Invoke();
        _pool.ReturnPool(gameObject);
    }
}
