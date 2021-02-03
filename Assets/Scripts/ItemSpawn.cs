using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject checkPoint;
    [SerializeField] int delayCheckPoint = 5;


    [SerializeField] GameObject[] powerUp;
    [SerializeField] int delayPowerUp = 5;
    
    [SerializeField]float radius=5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckPoints());
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnCheckPoints()
    {
        Vector2 randonPoint;
        while (!GameManager.instance.GameOver)
        {
            yield return new WaitForSeconds(delayCheckPoint);
            randonPoint = Random.insideUnitCircle * radius;
            Instantiate(checkPoint, randonPoint, Quaternion.identity);
        }

    }
    IEnumerator SpawnPowerUp()
    {
        int random;
        Vector2 randonPoint;
        while (!GameManager.instance.GameOver)
        {
            yield return new WaitForSeconds(delayPowerUp);
            randonPoint = Random.insideUnitCircle * radius;
            random = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[random], randonPoint, Quaternion.identity);
        }

    }


}
