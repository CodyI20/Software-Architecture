using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds the logic for the single target attacker.
/// It inherits from the base class of Abstract tower.
/// </summary>
public class SingleTargetTowerAttacker : AbstractTower
{
    //private void Awake()
    //{
    //    towerType = TowerType.MAGE;
    //}
    //Implement a way to randomly attack a target from the queue rather than the first one
    //And an option to choose which target to attack
    protected override void DoAttack(Queue<GameObject> enemy, int damage)
    {
        Debug.Log("SINGLE TARGET ATTACK!");
        enemy.Peek().GetComponent<AbstractEnemy>().TakeDamage(damage);
    }
}
