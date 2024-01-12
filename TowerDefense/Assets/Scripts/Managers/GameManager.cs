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
    //Public variables
    public GameState gameState { get; private set; }

    //Private variables
    [SerializeField, Tooltip("The key to press in order to pause the game")] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField, Tooltip("Whether or not to also disable the Audio while the game is paused")] private bool muteAudioOnPause = true;

    protected override void Awake()
    {
        base.Awake();
        gameState = GameState.Playing; //Could add functionality for when the game starts while Paused (weird concept)
    }

    // Start is called before the first frame update
    void Start()
    {

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
        gameState = (gameState == GameState.Paused) ? GameState.Playing : GameState.Paused;

        if (muteAudioOnPause)
            AudioListener.pause = !AudioListener.pause;
        Time.timeScale = 1.0f - Time.timeScale;
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
