using System.Collections.Generic;
using UnityEngine;

public class SlowingAttacker : AbstractTower
{
    protected override void DoAttack(Queue<GameObject> enemies, int damage)
    {
        Debug.Log("SLOWING ATTACK!");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().ReduceEnemySpeed(((SlowTowerSettingsSO)towerStats.towerSettings).SlowPercentage);
        }
    }
}
