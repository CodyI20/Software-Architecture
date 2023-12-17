using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/EnemySettingsSO", order = 1)]
public class EnemySettingsSO : ScriptableObject
{
    public int MaxHealth;
    public int CoinsDropped;
    public float Speed;
}
