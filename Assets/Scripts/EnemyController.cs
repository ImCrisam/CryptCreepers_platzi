using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;
    [SerializeField] int health = 10;
    [SerializeField] float speed = 3;

    private void Start() {
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update() {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime*speed;
    }
    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage();
        }
    }
}
