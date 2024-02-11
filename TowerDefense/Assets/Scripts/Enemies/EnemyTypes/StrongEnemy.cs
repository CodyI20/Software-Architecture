using UnityEngine;

/// <summary>
/// This class represents a type of enemy (Namely the strong enemy).
/// It derives from the main AbstractEnemy class.
/// It also uses a different version of the EnemySettings scriptable object.
/// </summary>
public class StrongEnemy : AbstractEnemy
{
    protected override void Awake()
    {
        base.Awake();
        if (!(settings is StrongEnemySettingsSO))
        {
            throw new System.Exception("The settings provided are not for the STRONG enemy!");
        }
    }
    protected override void TargetReachedActions()
    {
        Debug.Log("Destroying strong enemy...");
        base.TargetReachedActions();
    }
}
