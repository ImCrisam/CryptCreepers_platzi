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

        yield return new WaitForSeconds(timeDestroy - 3f);
        
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.enabled = true;
         yield return new WaitForSeconds(0.5f);
        spriteRenderer.enabled = false;
         yield return new WaitForSeconds(0.4f);
        spriteRenderer.enabled = true;
         yield return new WaitForSeconds(0.4f);
        spriteRenderer.enabled = false;
         yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = true;
         yield return new WaitForSeconds(0.3f);
         Destroy(gameObject, 0.1f);
    }
}
