using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectTowerAttacker : AbstractTower
{
    protected override void DoAttack(Queue<GameObject> enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<AbstractEnemy>().TakeDamage(towerSettings.Damage);
        }
    }
}
