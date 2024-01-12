using UnityEngine;

[CreateAssetMenu(menuName = "Tower Defense/Upgrade Range Command")]
public class UpgradeRangeCommandSO : CommandSO
{
    public int amount;
    public override void Execute(TowerStats tower)
    {
        tower.UpgradeRange(amount);
    }

    public override void Undo(TowerStats tower)
    {
        // Implement undo logic here if needed
    }
}




