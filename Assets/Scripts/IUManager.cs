using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IUManager : MonoBehaviour
{
    public static IUManager instance;
    [SerializeField] AudioClip button;
    [SerializeField] GameObject canvasGameOver;

    [SerializeField] Text textScore;
    [SerializeField] Text textTime;

    [SerializeField] Image healt1;
    [SerializeField] Image healt2;
    [SerializeField] Image healt3;


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
        AudioSource.PlayClipAtPoint(button, Vector3.zero);
        
        Invoke("loaderGame", 0.5f);

    }
    private void loaderGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void back()
    {
        AudioSource.PlayClipAtPoint(button, Vector3.zero);
        new WaitForSeconds(1f);
        SceneManager.LoadScene("menu");
    }

    public void UpdateTimeIU(int value)
    {
        textTime.text = value + "";
    }
    public void UpdateScoreIU(int value)
    {
        textScore.text = value + "";
    }
    public void UpdateHeaderIU(int value)
    {
        switch (value)
        {
            case 3:
                healt1.enabled = true;
                healt2.enabled = true;
                healt3.enabled = true;
                break;
            case 0:
                healt1.enabled = false;
                healt2.enabled = false;
                healt3.enabled = false;
                break;
            case 1:
                healt1.enabled = true;
                healt2.enabled = false;
                healt3.enabled = false;
                break;
            case 2:
                healt1.enabled = true;
                healt2.enabled = true;
                healt3.enabled = false;
                break;
            
        }
    }


}
