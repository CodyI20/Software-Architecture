using System;
using UnityEngine;

/// <summary>
/// This class holds all the information regarding the player
/// </summary>
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public static event Action<int> onCoinsChanged;
    public static event Action<int> onHealthChanged;
    [SerializeField] private PlayerDataSO data;

    public int coins { get; private set; }
    public int health { get; private set; }

    private void OnEnable()
    {
        data.onCoinsChanged += SetCoins;
        data.onHealthChanged += SetHealth;
        AbstractEnemy.onEnemyDeath += GainCoins;
        AbstractEnemy.onEnemyReachedBase += LoseHealth;
        UpgradeManager.onTowerSold += GainCoins;
    }
    private void OnDisable()
    {
        data.onHealthChanged -= SetHealth;
        data.onCoinsChanged -= SetCoins;
        AbstractEnemy.onEnemyDeath -= GainCoins;
        AbstractEnemy.onEnemyReachedBase -= LoseHealth;
        UpgradeManager.onTowerSold -= GainCoins;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SetValue();
    }
    void SetValue()
    {
        coins = data.currentCoins;
        onCoinsChanged?.Invoke(coins);
        health = data.currentHealth;
        onHealthChanged?.Invoke(health);
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            onCoinsChanged?.Invoke(coins);
            return true;
        }
        Debug.Log("Not enough coins!");
        return false;
    }

    void GainCoins(int amount)
    {
        coins += amount;
        onCoinsChanged?.Invoke(coins);
    }

    void LoseHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            //Implement logic for when the health reaches 0 or below
            Debug.Log("GAME OVER!");
            GameManager.Instance.ReloadCurrentScene();
        }
        onHealthChanged?.Invoke(health);
    }

    void SetHealth(int amount)
    {
        health = amount;
        onHealthChanged?.Invoke(health);
    }
    void SetCoins(int amount)
    {
        coins = amount;
        onCoinsChanged?.Invoke(coins);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
