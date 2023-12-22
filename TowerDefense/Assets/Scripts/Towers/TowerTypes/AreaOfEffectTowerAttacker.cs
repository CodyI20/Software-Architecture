using UnityEngine;

public class AreaOfEffectTowerAttacker : AbstractTower
{
    protected override void DoAttack()
    {
        Debug.Log("Doing AOE attack");
    }
}
