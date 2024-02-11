using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Paused = 0,
    Playing = 1,
    Interrupted = 2
}


/// <summary>
/// This class is used to manage the game state and handle the game pause functionality. It also contains the game speed functionality.
/// And it also contains the functionality to check the win and loss states of the game.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    public static event System.Action OnGameStateSwitch;

    //Public variables
    public static GameState gameState { get; private set; }

    //Private variables
    [SerializeField, Tooltip("The key to press in order to pause the game")] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField, Tooltip("Whether or not to also disable the Audio while the game is paused")] private bool muteAudioOnPause = true;

    private static float _gameSpeed = 1.0f;
    private Queue<GameObject> currentEnemiesOnField = new Queue<GameObject>();
    private bool canCheckFinalWave = false;

    protected override void Awake()
    {
        base.Awake();
        ResetGameState();
    }

    private void OnEnable()
    {
        EnemySpawner.onWaveFinishedSpawning += CheckLastWave;
        Player.OnPlayerDeath += LossState;
        AbstractEnemy.onEnemyDeath += RemoveDeadEnemies;
    }
    private void OnDisable()
    {
        EnemySpawner.onWaveFinishedSpawning -= CheckLastWave;
        Player.OnPlayerDeath -= LossState;
        AbstractEnemy.onEnemyDeath -= RemoveDeadEnemies;
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
        if (canCheckFinalWave)
            CheckWinState();
    }

    public void SwitchGamePause()
    {
        gameState = (gameState == GameState.Paused) ? GameState.Playing : GameState.Paused;
        if (muteAudioOnPause)
            AudioListener.pause = !AudioListener.pause;
        Time.timeScale = _gameSpeed - Time.timeScale;
        OnGameStateSwitch?.Invoke();
    }

    public void SetGameSpeed()
    {
        if (gameState == GameState.Paused)
            return;
        _gameSpeed = (_gameSpeed == 1.0f) ? 2.0f : 1.0f;
        Time.timeScale = _gameSpeed;
    }

    GameObject[] EnemiesOnTheField() { return GameObject.FindGameObjectsWithTag("Enemy"); }

    void CheckLastWave(int MaxWaves)
    {
        if (EnemySpawner.waveNumber >= MaxWaves)
        {
            canCheckFinalWave = true;
            currentEnemiesOnField = new Queue<GameObject>(EnemiesOnTheField());
        }
    }

    void RemoveDeadEnemies(int a)
    {
        if (canCheckFinalWave && currentEnemiesOnField.Count > 0)
            currentEnemiesOnField.Dequeue();
    }

    void CheckWinState() { if (currentEnemiesOnField.Count == 0) WinState(); }

    void WinState()
    {
        canCheckFinalWave = false;
        SceneManager.LoadScene(2);
    }

    void LossState()
    {
        SceneManager.LoadScene(3); //Defeat Scene
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
