using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField]GameObject checkPoint;
    [SerializeField] int delay = 5;
    Vector2 randonPoint;
    [SerializeField]float radius=5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            randonPoint = Random.insideUnitCircle * radius;
            Instantiate(checkPoint, randonPoint, Quaternion.identity);
        }

    }


}
