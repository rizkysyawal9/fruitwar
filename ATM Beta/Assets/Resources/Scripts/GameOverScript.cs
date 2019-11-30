using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text gameOverText;
    // Start is called before the first frame update
    void Awake()
    {
        gameOverPanel.SetActive(false);
    }
    // Update is called once per frame
    void GameOver()
    {
        if (GameManager.gameover == true)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "You Lose";
        }
    }

    void Start()
    {
        Awake();
        GameOver();
    }

    void Update()
    {
        Awake();
        GameOver();
    }
}
