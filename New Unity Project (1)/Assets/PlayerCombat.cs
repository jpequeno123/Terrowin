using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public float attackrange = 0.5f;
    public Transform attackPoint;

    public LayerMask enemyLayers;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    void Attack()
    {
        // play attack animation
        animator.SetTrigger("Attack");
        // Detect eneies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, enemyLayers);
        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackrange);
    }
}
