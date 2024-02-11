using UnityEngine;

/// <summary>
/// This script is used to disable the spanwer UI pop-up after being clicked
/// </summary>
public class SpawnerUIDisabler : MonoBehaviour
{
    private void OnEnable()
    {
        AdvanceWave.onWaveAdvance += DisableObject;
        EnemySpawner.onWaveFinished += DisableObject;
    }

    private void OnDisable()
    {
        AdvanceWave.onWaveAdvance -= DisableObject;
        EnemySpawner.onWaveFinished -= DisableObject;
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }

    void DisableObject(int a)
    {
        gameObject.SetActive(false);
    }
}
