using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public Pool pool;

    public LayerMask hitLayer;

    public int DamagePower;
    public int velocity;

    [SerializeField] private List<Pool> effect;

    private void DamageEnemy(Enemy enemy)
    {        

        enemy.Damage(DamagePower);

        if(effect!= null)
        {
            foreach (var item in effect)
            {
                item.GetPool(transform, transform.rotation);
            }
        }

        pool.ReturnPool(this.gameObject);
    }

    private void OnTriggerEnter(Collider hit)
    {
        var e = hit.gameObject.GetComponent<Enemy>();       
        
        if(e != null)
            DamageEnemy(e);

        if (hit.CompareTag("Wall"))
        {
            if (effect != null)
            {
                foreach (var item in effect)
                {
                    item.GetPool(transform, transform.rotation);
                }
            }

            pool.ReturnPool(this.gameObject);
        }
           


    }


    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * velocity;
    }
}
