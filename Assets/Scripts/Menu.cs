using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] AudioClip button;
    // Start is called before the first frame update
    public void PlayAgain()
    {
        AudioSource.PlayClipAtPoint(button, transform.position);
        new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Game");
    }
    
    public void ExitGame()
    {
         AudioSource.PlayClipAtPoint(button, transform.position);
        new WaitForSeconds(0.4f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
