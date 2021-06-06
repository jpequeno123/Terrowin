using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public GameObject bananus0;

    public Animator animator;

    public int health = 200;

    public int curhealth;

    public HealthBarp healthBarp;                                                         //HEalth

    public GameObject deathEffect;

    [SerializeField] private LayerMask bananaLayer0;

    [SerializeField] float Circleradius;

    [SerializeField] Transform bananaCheck;

    private bool banana0;



    int fc;

    void Start()
    {
        curhealth = health;
        healthBarp.Sethealth(health);
        fc = 0;


    }
    void Update()
    {
        banana0 = Physics2D.OverlapCircle(bananaCheck.position, Circleradius, bananaLayer0);
        if(banana0 && fc==0)
        {
            fc = 1;
            curhealth=200;
            bananus0.SetActive(false);
            healthBarp.SetHealth(curhealth);
        }
    }


    public void TakeDamage(int damage)
    {
        curhealth -= damage;

        animator.SetTrigger("Hurt");
        // Se quiseres por o inimigo a piscar em vez de levar dano

        //StartCoroutine(DamageAnimation());

        if (curhealth <= 0)
        {
            Die();
        }

        healthBarp.SetHealth(curhealth);
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(bananaCheck.position, Circleradius);
    }





        // Se quiseres por o inimigo a piscar em vez de levar dano



        //	IEnumerator DamageAnimation()
        //	{
        //		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
        //
        //		for (int i = 0; i < 3; i++)
        //		{
        //			foreach (SpriteRenderer sr in srs)
        //			{
        //				Color c = sr.color;
        //				c.a = 0;
        //				sr.color = c;
        //			}
        //
        //			yield return new WaitForSeconds(.1f);
        //
        //			foreach (SpriteRenderer sr in srs)
        //			{
        //				Color c = sr.color;
        //				c.a = 1;
        //				sr.color = c;
        //			}
        //
        //			yield return new WaitForSeconds(.1f);
        //		    }
        //	  }

    }
