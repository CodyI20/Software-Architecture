using UnityEngine;

/// <summary>
/// This class is used for spawning enemies into the scene.
/// It takes a random enemy from the array assigned in the inspector and with adjustable values it spawns the enemies at different intervals.
/// </summary>

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float spawnInterval = 1f;
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
        Instantiate(getRandomEnemy(), transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
