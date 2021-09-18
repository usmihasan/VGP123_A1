using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public int maxLives = 3;

    int _score = 0;

    public int score
    {
        get { return _score; }
        set 
        {
            _score = value;
            Debug.Log("Score changed. New score is: " + _score);
        }
    }

    public Transform spawnPoint;

    int _lives = 3;
    public int lives
    {
        get { return _lives; }
        set
        {
            if (!currentCanvas)
                currentCanvas = FindObjectOfType<CanvasManager>();

            if (_lives > value && value >= 0)
            {
                //respawn code here
                //GameManager.instance.SpawnPlayer(spawnPoint);
            }
            _lives = value;

            if (_lives > maxLives)
            {
                _lives = maxLives;
            }
            else if (lives < 0)
            {
                //game over code here
                SceneManager.LoadScene("GameOverScreen");
            }

            if (currentCanvas)
                currentCanvas.SetLivesText();

            Debug.Log("Lives changed. New lives value is: " + _lives);
        }
    }

    public GameObject playerInstance;
    public GameObject playerPrefab;
    public LevelManager currentLevel;

    CanvasManager currentCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        if (!currentCanvas)
            currentCanvas = FindObjectOfType<CanvasManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "TMNT")
                SceneManager.LoadScene("TitleScreen");
            else if (SceneManager.GetActiveScene().name == "TitleScreen")
                SceneManager.LoadScene("TMNT");
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            QuitGame();
        }

    }

    //PLATFORM SPECIFIC CODE EXAMPLE
    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TMNT");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}
