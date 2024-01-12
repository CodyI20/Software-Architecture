using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds the base information needed for all towers.
/// </summary>
public abstract class AbstractTower : MonoBehaviour
{
    [SerializeField] private TowerType _towerType;
    public TowerType towerType
    {
        get { return _towerType;}
    }
    //private Canvas canvas;

    //SETTINGS
    [HideInInspector] public TowerSettingsSO towerSettings;
    //[SerializeField, Tooltip("Drag in the tower upgrader settings scriptable object!")] private TowerSpawnerSettingsSO towerUpgraderSettings;
    //public TowerSettingsSO TowerSettings { get { return towerSettings;} }

    private float attackTime = 0f;

    //private void Awake()
    //{
    //    if (towerUpgraderSettings == null)
    //    {
    //        throw new Exception("The mandatory scriptable object is missing from this prefab! Please drag in the TowerSpawnerSettingsSO file!");
    //    }
    //    SetupCanvas();
    //}

    //void SetupCanvas()
    //{
    //    canvas = GetComponentInChildren<Canvas>();
    //    if(canvas == null)
    //    {
    //        throw new Exception($"The canvas component on the Tower: {gameObject.name} cannot be found!");
    //    }
    //    canvas.gameObject.SetActive(false);
    //    foreach(GameObject upgradeImage in towerUpgraderSettings.towerIcons)
    //    {
    //        Instantiate(upgradeImage, canvas.transform);
    //    }
    //}
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
