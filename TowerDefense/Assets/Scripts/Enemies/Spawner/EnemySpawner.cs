using System;
using UnityEngine;

/// <summary>
/// This class is used for spawning enemies into the scene.
/// It takes group of waves from the array assigned in the inspector and with adjustable values it spawns the enemies at different intervals.
/// </summary>

public class EnemySpawner : MonoBehaviour
{
    //PUBLIC VARIABLES:
    public event Action onWaveFinished;

    [SerializeField, Tooltip("Drag in the spawner settings scriptable object for this specific spawn point")] private EnemySpawnerSettingsSO[] Wave;


    //PRIVATE, NON-SERIALIZED VARIABLES:
    private float spawnIntervalAux = 0f;
    private int numberOfEnemyToSpawn = 0;
    private int waveNumber = 0;

    private void Awake()
    {
        if(Wave.Length == 0)
        {
            throw new Exception("The wave array cannot be empty!");
        }
    }

    /// Create a time stamp for when the enemy which is next in queue is spawned and instantiate it
    void SpawnEnemy()
    {
        spawnIntervalAux = Wave[waveNumber].spawnInterval;
        Instantiate(Wave[waveNumber].enemiesInWave[numberOfEnemyToSpawn], transform.position, transform.rotation);
        numberOfEnemyToSpawn += 1;
    }

    bool CurrentWaveFinished()
    {
        if (numberOfEnemyToSpawn >= Wave[waveNumber].enemiesInWave.Length)
        {
            return true;
        }
        return false;
    }

    bool CanAdvanceWave()
    {
        if (waveNumber + 1 >= Wave.Length)
            return false;
        return true;
    }

    void AdvanceWaveIfPossible()
    {
        if (Input.GetKeyDown(KeyCode.Y) && CanAdvanceWave() && CurrentWaveFinished())
        {
            Debug.Log($"SPAWNING NEXT WAVE...{waveNumber}");
            onWaveFinished?.Invoke();
            numberOfEnemyToSpawn = 0;
            waveNumber += 1;
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
    }



    // Update is called once per frame
    void Update()
    {
        AdvanceWaveIfPossible();
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