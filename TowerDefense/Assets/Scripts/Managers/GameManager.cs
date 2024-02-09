using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Paused = 0,
    Playing = 1,
    Interrupted = 2
}

public class GameManager : Singleton<GameManager>
{
    public event System.Action OnGamePaused;

    //Public variables
    public static GameState gameState { get; private set; }

    //Private variables
    [SerializeField, Tooltip("The key to press in order to pause the game")] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField, Tooltip("Whether or not to also disable the Audio while the game is paused")] private bool muteAudioOnPause = true;

    private static float _gameSpeed = 1.0f;

    protected override void Awake()
    {
        base.Awake();
        ResetGameState();
    }

    void ResetGameState()
    {
        gameState = GameState.Playing; //Could add functionality for when the game starts while Paused (weird concept)
        _gameSpeed = 1.0f;
        Time.timeScale = _gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Handle the game pause state
        if (Input.GetKeyDown(pauseKey))
        {
            SwitchGamePause();
        }
    }

    public void SwitchGamePause()
    {
        if (gameState == GameState.Paused)
        {
            gameState = GameState.Playing;
        }
        else
        {
            gameState = GameState.Paused;
            OnGamePaused?.Invoke();
        }
        if (muteAudioOnPause)
            AudioListener.pause = !AudioListener.pause;
        Time.timeScale = _gameSpeed - Time.timeScale;
    }

    public void SetGameSpeed()
    {
        if (gameState == GameState.Paused)
            return;
        _gameSpeed = (_gameSpeed == 1.0f) ? 2.0f : 1.0f;
        Time.timeScale = _gameSpeed;
    }

    public void ReloadCurrentScene()
    {
        ResetGameState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitAppication()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
