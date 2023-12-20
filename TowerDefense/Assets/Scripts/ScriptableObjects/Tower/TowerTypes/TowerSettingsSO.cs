using UnityEngine;

/// <summary>
/// This class holds the base settings for all towers.
/// </summary>
[CreateAssetMenu(fileName = "TowerSettings", menuName = "ScriptableObjects/TowerSettings/TowerSettings", order = 2)]
public class TowerSettingsSO : ScriptableObject
{
    [HideInInspector] public TowerType towerType;
    public int Damage;
    public float AttackSpeed;
    public float Range;
}
