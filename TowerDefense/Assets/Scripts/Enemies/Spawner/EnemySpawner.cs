using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used for spawning enemies into the scene.
/// It takes group of waves from the array assigned in the inspector and with adjustable values it spawns the enemies at different intervals.
/// </summary>

public class EnemySpawner : MonoBehaviour
{
    //PUBLIC VARIABLES:
    public static event Action<int> onWaveFinishedSpawning;
    public static event Action<int> onWaveFinished;
    public static int waveNumber = 1;

    //Calculate the number of waves in the array
    public int NumberOfWaves
    {
        get { return Wave.Length; }
    }

    public int MaxNumberOfWaves { get; private set; }

    //PRIVATE, SERIALIZED VARIABLES:
    [SerializeField, Tooltip("Drag in the spawner settings scriptable object for this specific spawn point")] private EnemySpawnerSettingsSO[] Wave;


    //PRIVATE, NON-SERIALIZED VARIABLES:
    private float spawnIntervalAux = 0f;
    private int numberOfEnemyToSpawn = 0;
    private float timeSinceWaveFinished = 0f;

    private GameObject canvas;
    private Slider waveSlider;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>().gameObject;
        waveSlider = GetComponentInChildren<Slider>();
        if (Wave.Length == 0)
        {
            throw new Exception("The wave array cannot be empty!");
        }
        if (canvas == null)
        {
            throw new Exception("The mandatory canvas related to this object is not present in the scene!");
        }
        else
            canvas.SetActive(false);
        if (waveSlider == null)
        {
            throw new Exception("The slider was not found as a component of this object's children");
        }
        waveNumber = 1;
    }

    private void OnEnable()
    {
        AdvanceWave.onWaveAdvance += CallNextWave;
    }

    private void OnDisable()
    {
        AdvanceWave.onWaveAdvance -= CallNextWave;
    }

    /// Create a time stamp for when the enemy which is next in queue is spawned and instantiate it
    void SpawnEnemy()
    {
        spawnIntervalAux = Wave[waveNumber - 1].spawnInterval;
        Instantiate(Wave[waveNumber - 1].enemiesInWave[numberOfEnemyToSpawn], transform.position, transform.rotation);
        numberOfEnemyToSpawn += 1;
    }

    bool CurrentWaveFinished()
    {
        if (numberOfEnemyToSpawn >= Wave[waveNumber - 1].enemiesInWave.Length)
        {
            onWaveFinishedSpawning?.Invoke(MaxNumberOfWaves);
            return true;
        }
        return false;
    }

    bool CanAdvanceWave()
    {
        if (waveNumber >= Wave.Length)
            return false;
        return true;
    }

    void CallNextWave(int a)
    {
        numberOfEnemyToSpawn = 0;
        waveNumber += 1;
        timeSinceWaveFinished = 0f;
        waveSlider.value = 0f;
        onWaveFinished?.Invoke(MaxNumberOfWaves);
        Debug.Log($"SPAWNING NEXT WAVE...{waveNumber}");
    }

    void WaveFinishedActions()
    {
        if (CanAdvanceWave() && CurrentWaveFinished())
        {
            canvas.SetActive(true);
            timeSinceWaveFinished += Time.deltaTime;
            waveSlider.value = timeSinceWaveFinished / Wave[waveNumber].timeUntilWaveStarts;
            if (timeSinceWaveFinished >= Wave[waveNumber].timeUntilWaveStarts)
            {
                CallNextWave(0);
            }
        }
    }


    //Calculate whether or not it can be spawned regarding the spawning interval
    void CalculateEnemySpawn()
    {
        if (!CurrentWaveFinished())
        {
            if (spawnIntervalAux <= 0)
            {
                SpawnEnemy();
            }
            else
            {
                spawnIntervalAux -= Time.deltaTime;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        MaxNumberOfWaves = 0;
        foreach (var spawner in FindObjectsOfType<EnemySpawner>())
        {
            MaxNumberOfWaves = Mathf.Max(MaxNumberOfWaves, spawner.NumberOfWaves);
        }
        onWaveFinished?.Invoke(MaxNumberOfWaves);
    }



    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == GameState.Paused)
            return;
        WaveFinishedActions();
        CalculateEnemySpawn();
    }
}

#region Legacy
//[SerializeField] private GameObject[] enemies;

///Get a random Enemy from the enemies array
//GameObject getRandomEnemy()
//{
//    return enemies[Random.Range(0, enemies.Length)];
//}

/// Create a time stamp for when the random enemy is spawned and instantiate it
//void SpawnEnemy()
//{
//    spawnIntervalAux = settings.spawnInterval;
//    Instantiate(getRandomEnemy(), transform.position, transform.rotation);
//}
#endregion