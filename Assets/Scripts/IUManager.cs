using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IUManager : MonoBehaviour
{
    public static IUManager instance;
    [SerializeField] GameObject canvasGameOver;


    // Update is called once per frame


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        canvasGameOver.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }


}
