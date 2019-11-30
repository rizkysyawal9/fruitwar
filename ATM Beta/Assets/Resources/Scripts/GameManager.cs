using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabSun;
    public Transform pointSun; 
    public static int cash;
    public static bool shovelenabled;
    public static GameObject currentPlant, currentSeed;
    public static bool gameover;
    public static int KecwaDie = 0;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private GameObject WinUI; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateSun", 10, 20);
        cash = 50;
        shovelenabled = false;
        gameover = false;
    }

    void Update()
    {
        if (cash >= 9999)
            cash = 9999;
        GameOver();
        Win();
    }

    void InstantiateSun()
    {
        Instantiate(prefabSun, pointSun.position, Quaternion.identity); 
    }

    void GameOver()
    {
        if(gameover == true)
        {
            cash = 0;
            Debug.Log("GAME OVER");
            gameOverUI.SetActive(true);

        }
        if(GameOverUI.retry == true)
        {
            gameOverUI.SetActive(false);
        }
    }

    void Win()
    {
        if(KecwaDie == 6)
        {
            WinUI.SetActive(true);
        }

        if (GameOverUI.retry == true)
        {
            WinUI.SetActive(false);
        }
    }


    void Awake()
    {
      // gameOverPanel.SetActive(true);   
    }

    
}
