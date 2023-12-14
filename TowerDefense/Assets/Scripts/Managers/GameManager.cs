using UnityEngine;
/// <summary>
/// This class is the manager of the entire game.
/// It holds information about the general stuff such as runtime playback speed, pause, scene load and reload.
/// </summary>

public enum GameState
{
    Paused = 0,
    Playing = 1,
    Interrupted = 2
}
public class GameManager : MonoBehaviour
{
    //Singleton pattern for quick and easy access to the GameManager class
    public static GameManager gameManagerInstance { get; private set; }
    //Public variables
    public GameState gameState { get; private set; }

    //Private variables
    [SerializeField, Tooltip("The key to press in order to pause the game")] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField, Tooltip("Whether or not to also disable the Audio while the game is paused")] private bool muteAudioOnPause = true;

    private void Awake()
    {
        gameState = GameState.Playing; //Could add functionality for when the game starts while Paused (weird concept)
        if (gameManagerInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

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

    void SwitchGamePause()
    {
        gameState = (gameState==GameState.Paused) ? GameState.Playing : GameState.Paused;

        if (muteAudioOnPause)
            AudioListener.pause = !AudioListener.pause;
        Time.timeScale = 1.0f - Time.timeScale;
    }

    private void OnDestroy()
    {
        if(gameManagerInstance == this)
            gameManagerInstance = null;
    }
}
