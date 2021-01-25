using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSimpleAttack : Attackable
{
    public Tower tower;
    public Transform firePoint;
    public Pool bulletPool;

    private void Start()
    {
        attackRate = tower.getFireRate;
    }

    protected override void attack()
    {
        bulletPool.GetPool(firePoint, firePoint.rotation);
        base.attack();

    }

    private void FixedUpdate()
    {
        if (!canAttack)
            return;

        RaycastHit hit;


        if (Physics.Raycast(firePoint.position, transform.TransformDirection(Vector3.forward), out hit,
            tower.getRange, targetLayer))
        {
            var e = hit.collider.GetComponent<Enemy>();

            if (e != null)
                attack();           
        }      


        Debug.DrawRay(firePoint.position, transform.TransformDirection(Vector3.forward) * tower.getRange, Color.yellow);
    }

}
