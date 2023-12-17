using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/EnemySettingsSO", order = 1)]
public class EnemySettingsSO : ScriptableObject
{
    //Base values
    public int MaxHealth;
    public int CoinsDropped;
    public float Speed;

    public EnemyType EnemyType;

    // For weak enemy
    public int startingHP;

    // For boss enemy
    public int attackDamage;
}
