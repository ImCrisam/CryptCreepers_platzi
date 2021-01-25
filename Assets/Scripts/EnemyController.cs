using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   [SerializeField]float health =1;

    public void TakeDamage()
    {
        health--;
    }
}
