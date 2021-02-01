using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float axiX;
    float axiY;
    float angleBullet;
    [SerializeField] int health = 3;
    Quaternion targetRotation;
    [SerializeField] float speed = 5;
    [SerializeField] float speedCurrent = 5;
    [SerializeField] Transform aim;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Camera camera;
    [SerializeField] Transform bullet;
    bool gunLoaded = true;
    [SerializeField] float fireRate = 1;
    Vector3 moveDirection;
    Vector2 facingDirection;
    int PowerShort = 0;
    Transform bulletClone;
    bool isInvulnerable = false;
    private float timeInvulnerable;
    [SerializeField] float blinkTime = 0.02f;
    CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        transform.position += moveDirection * Time.deltaTime * speedCurrent;

        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;


        if (Input.GetMouseButton(0) && gunLoaded)
        {
            gunLoaded = false;
            angleBullet = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.AngleAxis(angleBullet, Vector3.forward);
            bulletClone = Instantiate(bullet, transform.position, targetRotation);
            bulletClone.GetComponent<BulletController>().setHeader(PowerShort);
            StartCoroutine(ReLoaderGun());
        }
        animator.SetFloat("Speed", moveDirection.magnitude);
        if (aim.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (aim.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }


    }
    public void TakeDamage()
    {
        if (isInvulnerable)
        {
            return;
        }
        else
        {
            isInvulnerable = true;
            health--;
            cameraController.shake();
            StartCoroutine(invulnerableTime());
            if (health <= 0)
            {
                //GameOver
            }

        }

    }


    IEnumerator invulnerableTime()
    {
        StartCoroutine(blinkForDamager());
        yield return new WaitForSeconds(timeInvulnerable);
        isInvulnerable = false;
    }
    IEnumerator blinkForDamager()
    {
        int t = 10;
        spriteRenderer.color = Color.red;
        while (t > 0)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(t * blinkTime);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(t * blinkTime);
            t--;
        }
        spriteRenderer.color = Color.white;

    }
    IEnumerator ReLoaderGun()
    {
        yield return new WaitForSeconds(1 / fireRate);
        gunLoaded = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            switch (other.GetComponent<PowerUp>().typePower)
            {
                case PowerUp.TypePower.fireRate:
                    fireRate++;
                    break;

                case PowerUp.TypePower.PowerShort:
                    PowerShort++;
                    break;

            }
            Destroy(other.gameObject, 0.1f);
        }
    }

    public void ModifyMoves(float force)
    {
        speedCurrent *= force;
    }
    public void resetMoves()
    {
        speedCurrent = speed;
    }

}
