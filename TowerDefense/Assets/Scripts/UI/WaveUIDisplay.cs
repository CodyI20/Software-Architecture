using UnityEngine;

public class WaveUIDisplay : AbstractUIText
{
    EnemySpawner[] spawners;
    int maxWaves;
    private void Start()
    {
        // Find all EnemySpawners in the scene
        spawners = FindObjectsOfType<EnemySpawner>();
        foreach (var spawner in spawners)
        {
            maxWaves = Mathf.Max(maxWaves, spawner.NumberOfWaves);
        }
        UpdateWaveText(0);
    }
    private void OnEnable()
    {
        EnemySpawner.onWaveFinished += UpdateWaveText;
    }

    private void OnDisable()
    {
        EnemySpawner.onWaveFinished -= UpdateWaveText;
    }

    private void UpdateWaveText(int a)
    {
        ChangeText($"Wave {EnemySpawner.waveNumber} / {maxWaves}");
    }
}
