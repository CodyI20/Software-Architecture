using UnityEngine;

/// <summary>
/// This class holds the stats for the tower and the upgrade logic (uses the Command pattern)
/// </summary>
public class TowerStats : MonoBehaviour
{
    public TowerSettingsSO towerSettings;
    private int level = 1;

    public void UpgradeDamage(int amount)
    {
        towerSettings.Damage += amount;
        Debug.Log($"Tower upgraded! New damage: {towerSettings.Damage}");
    }

    public void UpgradeLevel()
    {
        level++;
        Debug.Log($"Tower upgraded! New level: {level}");
    }

    public void UpgradeRange(int amount)
    {
        towerSettings.Range += amount;
        Debug.Log($"Tower upgraded! New range: {towerSettings.Range}");
    }

}
