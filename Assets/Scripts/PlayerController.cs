using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float axiX;
    float axiY;
    float angleBullet;
    Quaternion targetRotation;
    [SerializeField] float speed = 5;
    [SerializeField] Transform aim;
    [SerializeField] Camera camera;
    [SerializeField] Transform bullet;
    bool gunLoaded = true;
    [SerializeField]float fireRate = 1;
    Vector3 moveDirection;
    Vector2 facingDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        transform.position += moveDirection * Time.deltaTime * speed;

        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;


        if (Input.GetMouseButton(0) && gunLoaded)
        {
            gunLoaded = false;
            angleBullet = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.AngleAxis(angleBullet, Vector3.forward);
            Instantiate(bullet, transform.position, targetRotation);
            StartCoroutine(ReLoaderGun());
        }

    }

    IEnumerator ReLoaderGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }

}
