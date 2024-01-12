using UnityEngine;

public class TowerStats : MonoBehaviour
{
    //private int damage;
    private int level = 1;
    //private int range;

    private AbstractTower tower;

    private void Awake()
    {
        tower = GetComponent<AbstractTower>();
        if(tower == null)
        {
            throw new System.Exception("The AbstractTower component cannot be found on this object!");
        }
    }

    public void UpgradeDamage(int amount)
    {
        tower.towerSettings.Damage += amount;
        Debug.Log($"Tower upgraded! New damage: {tower.towerSettings.Damage}");
    }

    public void UpgradeLevel()
    {
        level++;
        Debug.Log($"Tower upgraded! New level: {level}");
    }

    public void UpgradeRange(int amount)
    {
        tower.towerSettings.Range += amount;
        Debug.Log($"Tower upgraded! New range: {tower.towerSettings.Range}");
    }

}
