using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds the logic for the single target attacker.
/// It inherits from the base class of Abstract tower.
/// </summary>
public class SingleTargetTowerAttacker : AbstractTower
{
    //Implement a way to randomly attack a target from the queue rather than the first one
    //And an option to choose which target to attack
    protected override void DoAttack(Queue<GameObject> enemy)
    {
        enemy.Peek().GetComponent<AbstractEnemy>().TakeDamage(towerSettings.Damage);
    }
}
