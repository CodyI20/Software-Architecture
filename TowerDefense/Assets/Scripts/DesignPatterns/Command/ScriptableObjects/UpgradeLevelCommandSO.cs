using UnityEngine;

[CreateAssetMenu(menuName = "Tower Defense/Upgrade Level Command")]
public class UpgradeLevelCommandSO : CommandSO
{
    public override void Execute(TowerStats tower)
    {
        tower.UpgradeLevel();
    }

    public override void Undo(TowerStats tower)
    {
        // Implement undo logic here if needed
    }
}



