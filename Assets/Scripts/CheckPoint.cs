using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int value = 10;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioClip take;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(take, transform.position);
            GameManager.instance.time += value;
            Destroy(gameObject, 0.1f);
        }
    }

    [SerializeField] float timeDestroy = 25f;
    private void Start()
    {
        StartCoroutine(blinkForDamager());
    }

     IEnumerator blinkForDamager()
    {

        yield return new WaitForSeconds(timeDestroy - 6f);
        
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = true;
         yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = false;
         yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = true;
         yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = false;
         yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = true;
         yield return new WaitForSeconds(1f);
         Destroy(gameObject, 0.1f);
    }
}
