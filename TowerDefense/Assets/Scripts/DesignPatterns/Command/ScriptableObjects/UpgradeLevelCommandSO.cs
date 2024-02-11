using UnityEngine;

[CreateAssetMenu(menuName = "Tower Defense/Upgrade Level Command")]
public class UpgradeLevelCommandSO : CommandSO
{
    public override void Execute(AbstractTower tower)
    {
        tower.UpgradeLevel();
    }

    public override void Undo(AbstractTower tower)
    {
        // Implement undo logic here if needed
    }
}