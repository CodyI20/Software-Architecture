using UnityEngine;

public class EnemyMoneyGainedUI : AbstractUIText
{
    private void OnEnable()
    {
        AbstractEnemy.onEnemyDeath += AdditionText;
    }
    private void OnDisable()
    {
        AbstractEnemy.onEnemyDeath -= AdditionText;
    }
}
