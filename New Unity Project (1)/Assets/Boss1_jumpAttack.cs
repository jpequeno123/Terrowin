using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_jumpAttack : MonoBehaviour
{

	[SerializeField] public int attackDamage;
	[SerializeField] Vector2 boxSize;
	public Vector3 attackOffset;
	public LayerMask attackMask;
	private int nat;
	public Animator animator;
	private bool run;
	void start()
	{
		nat = 0;
	}
	public void jAttack()
	{

		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D[] colInfo = Physics2D.OverlapBoxAll(pos, boxSize, 0, attackMask);

		foreach (Collider2D Simps in colInfo)
		{
			nat = nat + 1;
		}
		if (nat <= 1)
		{
			foreach (Collider2D Simps in colInfo)
			{
				Simps.GetComponent<PlayerHealth>().TakeDamage(attackDamage); ;
			}
		}
		else
		{
		}
	}
	void Update()
	{
		run = animator.GetBool("IsRunning");
		if (run == true && nat >= 0)
		{
			nat = 0;
		}
	}
	private void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;


		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(pos, boxSize);
	}
}
