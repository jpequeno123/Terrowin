using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlhoCombat : MonoBehaviour
{

    [SerializeField] public int attackDamage;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    float nextAttackTime = 0f;
    public float attackRate=1f;

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            if (Time.time >= nextAttackTime)
            {
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                nextAttackTime = Time.time + 0.75f / attackRate;
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
