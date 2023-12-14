using UnityEngine;

/// <summary>
/// This class is used for spawning enemies into the scene.
/// It takes a random enemy from the array assigned in the inspector and with adjustable values it spawns the enemies at different intervals.
/// </summary>

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;


    [SerializeField, Min(0)] private float spawnInterval = 1f;
    private float spawnIntervalAux = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    GameObject getRandomEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
    }

    void SpawnEnemy()
    {
        spawnIntervalAux = spawnInterval;
        Instantiate(getRandomEnemy(), transform.position, transform.rotation);
    }

    void CalculateEnemySpawn()
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

    // Update is called once per frame
    void Update()
    {
        CalculateEnemySpawn();
    }
}
