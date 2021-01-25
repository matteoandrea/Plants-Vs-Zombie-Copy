using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComumAttack : Attackable
{
    [SerializeField]private ZombieData data;
    [SerializeField] private Collider col;
    [SerializeField] private Animator anim;

    private int attackAnim = Animator.StringToHash("Attack");
    private int viewAnim = Animator.StringToHash("View");

    private Health target;

    protected override void attack()
    {
        if (target == null || !target.isActiveAndEnabled)
        {
            anim.SetBool(viewAnim, false);
            target = null;

            return;
        }

        target.Damage(data.AttackPower);
        target = null;
        anim.SetBool(viewAnim, false);
        base.attack();

    }
  
   

    private void FixedUpdate()
    {
        if (!canAttack)
            return;


        RaycastHit hit;


        if (Physics.Raycast(col.bounds.center, transform.TransformDirection(Vector3.forward), out hit,
            data.range, targetLayer))
        {
            target = hit.collider.GetComponent<Health>();

            if (target != null && target.isActiveAndEnabled)
            {
                anim.SetBool(viewAnim, true);
                anim.SetTrigger(attackAnim);
            }
            else
            {
                anim.SetBool(viewAnim, false);
            }
        }


        Debug.DrawRay(col.bounds.center, transform.TransformDirection(Vector3.forward) * data.range, Color.red);
    }
}

