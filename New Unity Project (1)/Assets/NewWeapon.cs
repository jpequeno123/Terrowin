using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeapon : MonoBehaviour
{

    [SerializeField] private Collider2D m_Cirlcle0;


    void OntriggerEnter (Collider2D other)
    {
        Debug.Log("Object Entered the tigger");
    }
}
