using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static bool retry = false;
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Retry");
        retry = true; 
    }
}
