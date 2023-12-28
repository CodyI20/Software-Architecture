using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds the logic for the single target attacker.
/// It inherits from the base class of Abstract tower.
/// </summary>
public class SingleTargetTowerAttacker : AbstractTower
{
    protected override void DoAttack(Queue<GameObject> enemy)
    {
        enemy.Peek().GetComponent<AbstractEnemy>().TakeDamage(towerSettings.Damage);
    }
}
