using System;
using UnityEngine;

/// <summary>
/// This class holds all the information regarding the player
/// </summary>
public class Player : MonoBehaviour
{
    public static Player playerInstance { get; private set; }
    public static event Action<int> onCoinsChanged;
    public static event Action<int> onHealthChanged;
    [SerializeField] private PlayerDataSO data;

    public int coins { get; private set; }
    public int health { get; private set; }

    private void OnEnable()
    {
        AbstractEnemy.onEnemyDeath += GainCoins;
        AbstractEnemy.onEnemyReachedBase += LoseHealth;
    }
    private void OnDisable()
    {
        AbstractEnemy.onEnemyDeath -= GainCoins;
        AbstractEnemy.onEnemyReachedBase -= LoseHealth;
    }

    private void Awake()
    {
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SetInitialValues();
    }
    void SetInitialValues()
    {
        coins = data.StartingCoins;
        onCoinsChanged?.Invoke(coins);
        health = data.StartingHealth;
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
            GameManager.gameManagerInstance.ReloadCurrentScene();
        }
        onHealthChanged?.Invoke(health);
    }

    private void OnDestroy()
    {
        playerInstance = null;
    }
}
