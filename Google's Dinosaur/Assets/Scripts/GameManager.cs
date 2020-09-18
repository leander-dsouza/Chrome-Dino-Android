using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager instance; //static instance for easy access to other scripts
    public GameObject gameStartUI;
    public Button pauseButton;
    bool gameStarted = false;
    



    public GameObject gameRestartUI;



    private Vector2 fingerStart;
    private Vector2 fingerEnd;
    string Direction = "";







    public void Awake()
    {
        instance = this; //accessing the game's features
    }


    public void Restart()
    {
        
        SceneManager.LoadScene("Game"); 
    }

    public void GameOver()
    {
        
        Time.timeScale = 0f;
        pauseButton.gameObject.SetActive(false);
        gameRestartUI.SetActive(true);

    }



    public void GameStart()
    {
        gameStarted = true;
        gameStartUI.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }


    
    void TouchtoStart()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1f;
                GameStart();
            }
        }
    }
     
    
   
    public string Movement()
    {
        return Direction;
    }



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }
    void Update()
    {

        TouchtoStart(); // Touch to Start the Game

    }



}



