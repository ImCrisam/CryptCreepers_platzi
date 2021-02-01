using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] int health = 0;
    
    private void Start()
    {
        Destroy(gameObject, 3);
    }
    void Update()
    {
        transform.position += transform.right * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage();

            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }


        }
    }
    public void setHeader(int value)
    {
        health = value;
    }
}
