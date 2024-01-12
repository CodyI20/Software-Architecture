using System;
using UnityEngine;

/// <summary>
/// This abstract class holds all the base information an enemy must have: 
/// For example(Health, money dropped, speed).
/// It also holds base functions that every single enemy type should have: 
/// For example a method that finds the target and assigns it to a variable.
/// </summary>
[RequireComponent(typeof(EnemyController))]
public abstract class AbstractEnemy : MonoBehaviour, IDamageable
{
    public static event Action<int> onEnemyDeath;
    public static event Action<int> onEnemyReachedBase;
    public event Action<float,float> onEnemyHealthChange;

    [SerializeField, Tooltip("Drag in the ScriptableObject with the enemy settings")] protected EnemySettingsSO settings;
    public int currentHealth { get; protected set; }

    protected Transform target;

    [SerializeField, Tooltip("Drag in the canvas for the money dropped")] private Canvas moneyDroppedUI;
    private EnemyController controller;

    protected virtual void Awake()
    {
        if(settings == null)
        {
            throw new System.Exception("No settings file found! Assign one in the inspector!");
        }
        if(moneyDroppedUI == null)
        {
            throw new Exception("The canvas for the money dropped cannot be found!");
        }
        controller = GetComponent<EnemyController>();
        controller.SetInitialEnemySpeed(settings.Speed);
    }
    private void Start()
    {
        CurrentHealthSetAnnouncement(settings.MaxHealth);
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

    /// <summary>
    /// This function is used solely for the purpose of broadcasting the event
    /// </summary>
    /// <param name="maxHealth"></param>
    private void CurrentHealthSetAnnouncement(int maxHealth)
    {
        SetCurrentHealth(maxHealth);
        onEnemyHealthChange?.Invoke(maxHealth, currentHealth);
    }

    //This method is made public so that the enemy can easily assign its target on the go during the game.
    //(for example if there are ground enemies that he has to stop and fight)
    public void AssignTarget(Transform currentTarget)
    {
        target = currentTarget;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Instantiate(moneyDroppedUI, transform.position, Quaternion.identity);
            onEnemyDeath?.Invoke(settings.CoinsDropped);
            Destroy(gameObject);
        }
        onEnemyHealthChange?.Invoke(settings.MaxHealth,currentHealth);
    }

    protected virtual void TargetReachedActions()
    {
        //Implement all the required logic for when the target is reached!
        onEnemyReachedBase?.Invoke(settings.DamageToBase);
        Destroy(gameObject);
    }
}
