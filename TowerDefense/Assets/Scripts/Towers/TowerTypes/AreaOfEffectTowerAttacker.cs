using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectTowerAttacker : AbstractTower
{
    protected override void DoAttack(Queue<GameObject> enemies, int damage)
    {
        Debug.Log("AOE ATTACK!");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<AbstractEnemy>().TakeDamage(damage);
        }
    }
}
