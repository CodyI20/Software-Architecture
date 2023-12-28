using UnityEngine;

/// <summary>
/// This class holds the base settings for all towers.
/// </summary>
[CreateAssetMenu(fileName = "TowerSettings", menuName = "ScriptableObjects/TowerSettings/TowerSettings", order = 2)]
public class TowerSettingsSO : ScriptableObject
{
    //public TowerType towerType;
    [Min(0)] public int Damage;
    [Min(0.1f)] public float AttackSpeed;
    [Range(0,30f)] public float Range;
    [Min(0)] public int Cost;
}
