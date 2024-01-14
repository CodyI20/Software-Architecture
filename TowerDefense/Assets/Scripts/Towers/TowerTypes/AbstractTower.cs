using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

/// <summary>
/// This class holds the base information needed for all towers.
/// </summary>
[RequireComponent(typeof(TowerStats))]
public abstract class AbstractTower : MonoBehaviour
{
    protected TowerStats towerStats;

    private void Awake()
    {
        towerStats = GetComponent<TowerStats>();
    }

    [SerializeField] private TowerType _towerType;
    public TowerType towerType
    {
        get { return _towerType;}
    }

    private float attackTime = 0f;
    protected abstract void DoAttack(Queue<GameObject> enemies, int damage = 0);

    private void AttackIfInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, towerStats.towerSettings.Range);

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
            attackTime = towerStats.towerSettings.AttackSpeed;
            DoAttack(enemyColliders, towerStats.towerSettings.Damage);
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
        Gizmos.DrawWireSphere(transform.position, towerStats.towerSettings.Range);
    }

}
