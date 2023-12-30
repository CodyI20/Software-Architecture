using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds the base information needed for all towers.
/// </summary>
public abstract class AbstractTower : MonoBehaviour
{
    public static event Action onTowerAttack;
    [SerializeField] private TowerType _towerType;
    public TowerType towerType
    {
        get { return _towerType;}
    }

    //SETTINGS
    [SerializeField, Tooltip("Drag in the tower settings")] protected TowerSettingsSO towerSettings;
    public TowerSettingsSO TowerSettings { get { return towerSettings;} }

    private float attackTime = 0f;
    protected abstract void DoAttack(Queue<GameObject> enemies);

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
            attackTime = towerSettings.AttackSpeed;
            onTowerAttack?.Invoke();
            DoAttack(enemyColliders);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, towerSettings.Range);
    }

}
