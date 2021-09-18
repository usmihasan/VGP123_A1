using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CanvasManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip pauseSound;
    public AudioMixerGroup soundFXMixer;
    public AudioClip startGame;
    AudioSource pauseSoundAudio;
    AudioSource startGameAudio;

    [Header("Images")]
    public Image[] hearts;
    
    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button settingsButton;
    public Button backButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;

    [Header("Text")]
    public Text livesText;
    public Text volSliderText;

    [Header("Slider")]
    public Slider volSlider;


    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
        {
            startButton.onClick.AddListener(() => GameManager.instance.StartGame());
            
            if (!startGameAudio)
            {
                startGameAudio = gameObject.AddComponent<AudioSource>();
                startGameAudio.outputAudioMixerGroup = soundFXMixer;
                startGameAudio.clip = startGame;
                startGameAudio.loop = false;
            }
            else
                startGameAudio.Play();
        }

        if (quitButton)
            quitButton.onClick.AddListener(() => GameManager.instance.QuitGame());

        if (settingsButton)
            settingsButton.onClick.AddListener(() => ShowSettingsMenu());

        if (backButton)
            backButton.onClick.AddListener(() => ShowMainMenu());

        if (returnToGameButton)
            returnToGameButton.onClick.AddListener(() => ReturnToGame());

        if (returnToMenuButton)
            returnToMenuButton.onClick.AddListener(() => GameManager.instance.ReturnToTitle());

        if (livesText)
            SetLivesText();
    }

    public void SetLivesText()
    {
        if (GameManager.instance)
        {
            //livesText.text = GameManager.instance.lives.ToString();
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < GameManager.instance.lives)
                    hearts[i].enabled = true;
                else
                    hearts[i].enabled = false;
            }
        }
        else
            SetLivesText();
    }

    void ReturnToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    void ShowMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);

                if (!pauseSoundAudio)
                {
                    pauseSoundAudio = pauseMenu.gameObject.AddComponent<AudioSource>();
                    pauseSoundAudio.clip = pauseSound;
                    pauseSoundAudio.loop = false;
                }

                if (pauseMenu.activeSelf)
                {
                    pauseSoundAudio.Play();
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
        }

        if (settingsMenu)
        {
            if (settingsMenu.activeSelf)
            {
                volSliderText.text = volSlider.value.ToString();
            }
        }

    }
}
