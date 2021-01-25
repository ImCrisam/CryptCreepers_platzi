using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] float speed = 10f;

    private void Start() {
        Destroy(gameObject, 3);
    }
    void Update()
    {
        transform.position += transform.right * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemies"))
        {
        other.GetComponent<EnemyController>().TakeDamage();

        }
        Destroy(gameObject);
    }
}
