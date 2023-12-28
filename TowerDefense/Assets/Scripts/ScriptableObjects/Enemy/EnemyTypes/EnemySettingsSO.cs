using UnityEngine;

/// <summary>
/// This class is used for easily setting the settings for each enemy.
/// It is marked as abstract and it also doesn't have a CreateAssetMenu attribute; The reason for that is simple:
/// This is the base settings class for all the enemy types.
/// Even if an enemy has the same settings as this one, it will just inherit from it, with the added CreateAssetMenu attribute
/// </summary>
public abstract class EnemySettingsSO : ScriptableObject
{
    [Min(1)] public int MaxHealth;
    [Min(0)] public int CoinsDropped;
    [Min(0)] public int DamageToBase;
    [Min(0)] public float Speed;
}
