using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [Range(1,10)][SerializeField] float spawnRange =1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnNewEnemy()
    {
        while (!GameManager.instance.GameOver)
        {
            yield return new WaitForSeconds(1/spawnRange);
            var random = Random.Range(0.0f, 1f);
            if (random > GameManager.instance.difficulty * 0.1f)
            {
            Instantiate(enemyPrefabs[0]);
            }
            else
            {
            Instantiate(enemyPrefabs[1]);

            }
        }
    }
}
