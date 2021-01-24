using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    void Update()
    {
        transform.position += transform.right * Time.deltaTime;
    }
}
