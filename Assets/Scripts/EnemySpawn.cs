using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }


    IEnumerator SpawnNewEnemy()
    {
        while (!GameManager.instance.GameOver)
        {
            yield return new WaitForSeconds(2.5f/GameManager.instance.difficulty);
            var random = Random.Range(0.0f, 1f);
            if (random > GameManager.instance.difficulty * 0.2f)
            {
                Instantiate(enemyPrefabs[0]);
            }
            else if (random > GameManager.instance.difficulty * 0.1f)
            {
                Instantiate(enemyPrefabs[1]);

            }
            else
            {
                Instantiate(enemyPrefabs[2]);
            }
        }
    }
}
