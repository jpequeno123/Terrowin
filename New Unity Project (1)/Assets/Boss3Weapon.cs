using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Weapon : MonoBehaviour
{
	[SerializeField] Transform attackcheck;

	[SerializeField] public int attackDamage;
	[SerializeField] public int attackRange;

	public Animator animator;
	public LayerMask attackMask;

	public void Attack()
	{

		Collider2D colInfo = Physics2D.OverlapCircle(attackcheck.position, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
		}

	}
	public void wDie()
	{
		//Debug.Log("Enemy died!");

		animator.SetBool("IsDead", true);

		this.enabled = false;
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = attackcheck.position;
//		pos += transform.right * attackOffset.x;
//		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
