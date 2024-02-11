using UnityEngine;

/// <summary>
/// This class represents a type of enemy (Namely the weak enemy).
/// It derives from the main AbstractEnemy class.
/// It also uses a different version of the EnemySettings scriptable object.
/// </summary>
public class WeakEnemy : AbstractEnemy
{
    protected override void Awake()
    {
        base.Awake();
        if (!(settings is WeakEnemySettingsSO))
        {
            throw new System.Exception("The settings provided are not for the WEAK enemy!");
        }
    }
    protected override void TargetReachedActions()
    {
        Debug.Log("Destroying weak enemy...");
        base.TargetReachedActions();
    }

    protected override void SetCurrentHealth(int maxHealth)
    {
        currentHealth = ((WeakEnemySettingsSO)settings).startingHP;
    }
}
