using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int difficulty = 1;
    public int time = 30;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start() {
        StartCoroutine(CountDownTime());
    }


    IEnumerator CountDownTime()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }

}
