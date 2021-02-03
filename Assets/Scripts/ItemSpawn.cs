using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] moreTime;
    [SerializeField] int delaytime = 5;


    [SerializeField] GameObject[] powerUp;
    [SerializeField] int delayPowerUp = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckPoints());
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnCheckPoints()
    {
        int random;
        Vector2 randonPoint;
        while (!GameManager.instance.GameOver)
        {
            yield return new WaitForSeconds(delaytime);
            random = Random.Range(0, powerUp.Length);
            
            randonPoint = new Vector2(Random.Range(-41, 23), Random.Range(-19, 17));
            Instantiate(moreTime[random], randonPoint, Quaternion.identity);
        }

    }
    IEnumerator SpawnPowerUp()
    {
        int random;
        Vector2 randonPoint;
        while (!GameManager.instance.GameOver)
        {
            yield return new WaitForSeconds(delayPowerUp);
            randonPoint = new Vector2(Random.Range(-41, 23), Random.Range(-19, 17));
            random = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[random], randonPoint, Quaternion.identity);
        }

    }


}
