using UnityEngine;

public class EnemyMoneyGainedUI : AbstractUIText
{
    private void OnEnable()
    {
        AbstractEnemy.onEnemyDeath += ChangeText;
    }
    private void OnDisable()
    {
        AbstractEnemy.onEnemyDeath -= ChangeText;
    }
}
