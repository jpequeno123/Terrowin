using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlhoCombat : MonoBehaviour
{

    [SerializeField] public int attackDamage;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
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
