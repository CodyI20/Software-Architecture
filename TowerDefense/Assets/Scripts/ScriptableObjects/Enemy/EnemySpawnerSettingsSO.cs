using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerSettings", menuName = "ScriptableObjects/EnemySettings/Spawner/EnemySpawnerSettings")]
public class EnemySpawnerSettingsSO : ScriptableObject
{
    [Tooltip("Drag in the enemy prefabs in the order desired for spawning")] public GameObject[] enemiesInWave;
    [Tooltip("The interval of time after each enemy in the wave will spawn"), Min(1f)] public float spawnInterval = 1f;
    [Tooltip("The amount of time from the wave pop-up until it starts")] public float timeUntilWaveStarts = 10f;
}
