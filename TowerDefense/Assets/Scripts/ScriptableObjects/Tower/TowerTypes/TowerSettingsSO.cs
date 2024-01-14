using UnityEngine;

/// <summary>
/// This class holds the base settings for all towers.
/// </summary>
[CreateAssetMenu(fileName = "TowerSettings", menuName = "ScriptableObjects/TowerSettings/TowerSettings", order = 2)]
public class TowerSettingsSO : ScriptableObject, ISerializationCallbackReceiver
{
    [Tooltip("Drag in the tower icon prefab here!")] public GameObject towerPrefab;
    //public TowerType towerType;
    [Min(0)] public int initialDamage;
    [Min(0f)] public float initialAttackSpeed;
    [Range(0, 30f)] public float initialRange;

    [Min(0)] public int Damage;
    [Min(0f)] public float AttackSpeed;
    [Range(0,30f)] public float Range;

    public virtual void OnAfterDeserialize()
    {
        AttackSpeed = initialAttackSpeed;
        Damage = initialDamage;
        Range = initialRange;
    }

    public void OnBeforeSerialize()
    {
    }
}
