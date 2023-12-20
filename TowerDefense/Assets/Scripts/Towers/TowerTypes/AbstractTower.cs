using UnityEngine;

/// <summary>
/// This class holds the base information needed for all towers.
/// </summary>
public abstract class AbstractTower : MonoBehaviour
{
    //[SerializeField, Tooltip("Drag in the tower settings")] protected TowerSettingsSO towerSettings;
    //SETTINGS
    [SerializeField, Min(0)] private int Damage;
    [SerializeField, Min(0.1f)] private float AttackSpeed;
    [SerializeField, Range(0,100f)] private float Range;
    protected TowerType towerType;

    protected abstract void DoAttack();

    private void AttackIfInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Range);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // Enemy is in range, perform attack
                DoAttack();
                return;
            }
        }
    }

    private void Update()
    {
        AttackIfInRange();
    }

}
