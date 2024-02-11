using UnityEngine;

[CreateAssetMenu(menuName = "Tower Defense/Upgrade Range Command")]
public class UpgradeRangeCommandSO : CommandSO
{
    public int amount;
    public override void Execute(AbstractTower tower)
    {
        tower.UpgradeRange(amount);
    }

    public override void Undo(AbstractTower tower)
    {
        // Implement undo logic here if needed
    }
}