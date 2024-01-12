using UnityEngine;

[CreateAssetMenu(menuName = "Tower Defense/Upgrade Damage Command")]
public class UpgradeDamageCommandSO : CommandSO
{
    public int amount;

    public override void Execute(TowerStats tower)
    {
        tower.UpgradeDamage(amount);
    }

    public override void Undo(TowerStats tower)
    {
        // Implement undo logic here if needed
    }
}


