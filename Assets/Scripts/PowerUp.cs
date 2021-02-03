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
