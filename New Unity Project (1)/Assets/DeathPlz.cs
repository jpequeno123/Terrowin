using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlz : MonoBehaviour
{
    public GameObject bruh;
    public void dDie()
    {
        //olho = GameObject.Find("Enemy");

        Debug.Log("Enemy died!");

        bruh.SetActive(false);  
    }
}
