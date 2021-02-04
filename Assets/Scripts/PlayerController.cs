using System;
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
    [SerializeField] float speedCurrent = 5;
    [SerializeField] Transform aim;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
[SerializeField] AudioClip take;
    [SerializeField] Camera camera;
    [SerializeField] Transform[] bullet;
    [SerializeField] int typeBullet=0;
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

    [SerializeField] int health = 3;
    public int Health
    {
        get => health;
        set
        {
            if (value <= 3)
            {
                health = value;
                IUManager.instance.UpdateHeaderIU(health);
            }
        }
    } 
    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        IUManager.instance.UpdateHeaderIU(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver)
        {
            movePlayer();
            moveAim();

            if (Input.GetMouseButton(0) && gunLoaded)
            {
                shoot();

            }
            animatorPlayer();
        }


    }

    private void animatorPlayer()
    {
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

    private void shoot()
    {
            gunLoaded = false;
            angleBullet = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.AngleAxis(angleBullet, Vector3.forward);
            bulletClone = Instantiate(bullet[typeBullet], transform.position, targetRotation);
            bulletClone.GetComponent<BulletController>().setHeader(PowerShort);
            StartCoroutine(ReLoaderGun());
    }

    private void moveAim()
    {
        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;

    }

    private void movePlayer()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        transform.position += moveDirection * Time.deltaTime * speedCurrent;

    }

    public void TakeDamage()
    {
        if (isInvulnerable )
        {
            return;
        }
        else
        {
            isInvulnerable = true;
            Health--;
            cameraController.shake();
            StartCoroutine(invulnerableTime());
            if (Health <= 0)
            {
                GameManager.instance.GameOver = true;
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
                case PowerUp.TypePower.heal:
                    Health++;
                    break;

            }
            AudioSource.PlayClipAtPoint(take, transform.position);
            Destroy(other.gameObject, 0.1f);
        }

        if (other.CompareTag("TypeBullet")) {
            typeBullet = other.GetComponent<TypeShoot>().type;
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
