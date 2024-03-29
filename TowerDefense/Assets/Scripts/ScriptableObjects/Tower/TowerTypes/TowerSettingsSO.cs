using UnityEngine;

/// <summary>
/// This class holds the base settings for all towers.
/// </summary>
[CreateAssetMenu(fileName = "TowerSettings", menuName = "ScriptableObjects/TowerSettings/TowerSettings", order = 2)]
public class TowerSettingsSO : ScriptableObject, ISerializationCallbackReceiver
{
    [Tooltip("Drag in the tower icon prefab here!")] public GameObject towerPrefab;
    [Tooltip("Drag in the visuals for the tower here!")] public GameObject towerVisuals;
    [Tooltip("Adjust the time it takes until the visuals disappear")] public float visualsDuration = 0.4f;
    //public TowerType towerType;
    [Min(0)] public int initialDamage;
    [Min(0f)] public float initialAttackDelay;
    [Range(0, 30f)] public float initialRange;

    [Min(0)] public int Damage;
    [Min(0f)] public float AttackDelay;
    [Range(0,30f)] public float Range;

    public virtual void OnAfterDeserialize()
    {
        AttackDelay = initialAttackDelay;
        Damage = initialDamage;
        Range = initialRange;
    }

    public void OnBeforeSerialize()
    {
    }
}
