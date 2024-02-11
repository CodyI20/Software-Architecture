using UnityEngine;

[CreateAssetMenu(menuName = "Tower Defense/Upgrade Damage Command")]
public class UpgradeDamageCommandSO : CommandSO
{
    public int amount;

    public override void Execute(AbstractTower tower)
    {
        tower.UpgradeDamage(amount);
    }

    public override void Undo(AbstractTower tower)
    {
        // Implement undo logic here if needed
    }
}


