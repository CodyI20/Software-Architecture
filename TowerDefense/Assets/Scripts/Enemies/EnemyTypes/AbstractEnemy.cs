using UnityEngine;

/// <summary>
/// This abstract class holds all the base information an enemy must have: 
/// For example(Health, money dropped, speed).
/// It also holds base functions that every single enemy type should have: 
/// For example a method that finds the target and assigns it to a variable.
/// </summary>
[RequireComponent(typeof(EnemyController))]
public abstract class AbstractEnemy : MonoBehaviour
{
    [SerializeField, Tooltip("Drag in the ScriptableObject with the enemy settings")] protected EnemySettingsSO settings;
    public int currentHealth { get; protected set; }

    protected Transform target;

    private EnemyController controller;

    protected virtual void Awake()
    {
        if(settings == null)
        {
            throw new System.Exception("No settings file found! Assign one in the inspector!");
        }
        controller = GetComponent<EnemyController>();
        controller.SetEnemySpeed(settings.Speed);
        SetCurrentHealth(settings.MaxHealth);
    }

    private void OnEnable()
    {
        controller.onTargetReached += TargetReachedActions;
    }

    private void OnDisable()
    {
        controller.onTargetReached -= TargetReachedActions;
    }

    /// <summary>
    /// This function allows for easy manipulation of how the currentHealth of the enemy is initialized.
    /// It comes in very handy if there is a healing mechanic among enemies and there is a Berserker type for example that starts with half HP.
    /// In this aforementioned case, the total HP will still be the Health parameter, but its starting HP will be different.
    /// </summary>
    protected virtual void SetCurrentHealth(int maxHealth)
    {
        currentHealth = maxHealth;
    }

    //This method is made public so that the enemy can easily assign its target on the go during the game.
    //(for example if there are ground enemies that he has to stop and fight)
    public void AssignTarget(Transform currentTarget)
    {
        target = currentTarget;
    }

    protected virtual void TargetReachedActions()
    {
        //Implement all the required logic for when the target is reached!

        Destroy(gameObject);
    }
}
