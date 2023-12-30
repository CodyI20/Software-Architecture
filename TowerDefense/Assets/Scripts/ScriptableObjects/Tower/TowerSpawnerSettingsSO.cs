using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class holds the prefabs for a tower spawner.
/// This allows for easy swapping of which towers can be bought from a tower spawner. 
/// </summary>
[CreateAssetMenu(fileName = "TowerSpawnerSettingsSO", menuName = "ScriptableObjects/TowerSettings/TowerSpawnerSettings", order = 1)]
public class TowerSpawnerSettingsSO : ScriptableObject
{
    [Tooltip("Drag in the tower prefabs!")] public GameObject[] towerPrefabs;
    [Tooltip("Drag in the tower shop icons")] public GameObject[] towerIcons;
}
