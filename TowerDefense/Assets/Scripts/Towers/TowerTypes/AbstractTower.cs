using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds the base information needed for all towers.
/// </summary>

public abstract class AbstractTower : MonoBehaviour
{
    public TowerSettingsSO towerSettings;
    public int towerCost;
    private int level = 1;

    [SerializeField] private TowerType _towerType;
    public TowerType towerType
    {
        get { return _towerType;}
    }

    private float attackTime = 0f;
    protected abstract void DoAttack(Queue<GameObject> enemies, int damage = 0);

    private void AttackIfInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, towerSettings.Range);

        Queue<GameObject> enemyColliders = new Queue<GameObject>();
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                enemyColliders.Enqueue(collider.gameObject);
            }
        }
        if(enemyColliders.Count > 0)
        {
            attackTime = towerSettings.AttackDelay;
            DoAttack(enemyColliders, towerSettings.Damage);
        }
    }

    private void AttackAfterCD()
    {
        if (attackTime <= 0f)
        {
            AttackIfInRange();
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
    }

    private void Update()
    {
        AttackAfterCD();
    }

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

    public void UpgradeAttackSpeed(float amount)
    {
        towerSettings.AttackDelay -= amount;
        Debug.Log($"Tower upgraded! New attack speed: {towerSettings.AttackDelay}");
    }

    public void UpgradeRange(int amount)
    {
        towerSettings.Range += amount;
        Debug.Log($"Tower upgraded! New range: {towerSettings.Range}");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, towerSettings.Range);
    }

}
