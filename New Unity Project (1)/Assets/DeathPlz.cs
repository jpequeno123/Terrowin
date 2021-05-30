using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlz : MonoBehaviour
{
    public GameObject bruh;
    public void Die()
    {
        //olho = GameObject.Find("Enemy");

        Debug.Log("Enemy died!");

        bruh.SetActive(false);  
    }
}
