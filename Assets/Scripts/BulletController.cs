using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] float timeDestroy = 2f;
    [SerializeField] int health = 0;
    
    private void Start()
    {
        Destroy(gameObject, timeDestroy);
    }
    void Update()
    {
        transform.position += transform.right * Time.deltaTime*speed;
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
