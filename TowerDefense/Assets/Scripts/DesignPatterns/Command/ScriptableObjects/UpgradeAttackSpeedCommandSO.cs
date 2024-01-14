using UnityEngine;

[CreateAssetMenu(menuName = "Tower Defense/Upgrade Attack Speed Command")]
public class UpgradeAttackSpeedCommandSO : CommandSO
{
    public float amount;
    public override void Execute(AbstractTower tower)
    {
        tower.UpgradeAttackSpeed(amount);
    }

    public override void Undo(AbstractTower tower)
    {
        // Implement undo logic here if needed
    }
}

