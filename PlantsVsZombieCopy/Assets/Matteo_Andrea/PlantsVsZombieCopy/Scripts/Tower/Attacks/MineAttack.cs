using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAttack : Attackable
{

    public Tower tower;
    public Health life;

   

    protected override void attack()
    {
        MineDestroy();
    }


    public void MineDestroy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, tower.getRange, targetLayer);
        foreach (var hit in hitColliders)
        {
            var e = hit.gameObject.GetComponent<Enemy>();

            if (e != null)
                e.Damage(tower.getDamage);
        }

        life.Damage(1);
    }


    private void OnTriggerEnter(Collider hit)
    {
        var e = hit.gameObject.GetComponent<Enemy>();

        if (e != null)
            attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, tower.getRange);
    }
}
