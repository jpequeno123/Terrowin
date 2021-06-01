using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBakWeapon : MonoBehaviour
{
    [SerializeField] public int attackDamage;

    public Animator animator;
    public Vector3 attackOffset;
    public float attackRange = 0.74f;
    public LayerMask attackMask;
    float nextAttackTime = 0f;
    public float attackRate = 1f;
    private bool Hedied = false;

    void FixedUpdate()
    {
        Hedied = animator.GetBool("IsDead");
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            if (Time.time >= nextAttackTime)
            {
                if (Hedied =! true)
                {
                    colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                    nextAttackTime = Time.time + 0.75f / attackRate;
                }
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

}
