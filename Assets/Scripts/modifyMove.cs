using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modifyMove : MonoBehaviour
{
   
    [SerializeField]float force=1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ModifyMoves(force);

        }
    }


   private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().resetMoves();

        }
   }

   
}
