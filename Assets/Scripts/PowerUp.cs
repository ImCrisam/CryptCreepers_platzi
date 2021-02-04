using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum TypePower
    {
        fireRate,
        PowerShort,
        heal,
    }

    public TypePower typePower;
    [SerializeField] SpriteRenderer spriteRenderer;


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
