using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class DeathPlz : MonoBehaviour
{
    public GameObject bruh;
    public void dDie()
    {
        //olho = GameObject.Find("Enemy");

        Debug.Log("Enemy died!");

        bruh.SetActive(false);

        //SceneManager.LoadScene(1);
        

    }
}
