using UnityEngine;

public class WeakEnemy : AbstractEnemy
{
    private void Awake()
    {
        if (settings.EnemyType != EnemyType.WEAK)
        {
            throw new System.Exception("WEAK enemy settings NOT found!");
        }
    }
    protected override void TargetReachedActions()
    {
        Debug.Log("Destroying weak enemy...");
        base.TargetReachedActions();
    }
    protected override void SetCurrentHealth(int maxHealth)
    {
        currentHealth = settings.startingHP;
    }
}
