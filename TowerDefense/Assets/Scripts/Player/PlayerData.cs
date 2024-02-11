using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player")]
public class PlayerDataSO : ScriptableObject
{
    public event Action<int> onCoinsChanged;
    public event Action<int> onHealthChanged;

    [Min(1)] public int StartingHealth = 10;
    [Min(0)] public int StartingCoins = 100;
    [HideInInspector] public int currentCoins;
    [HideInInspector] public int currentHealth;
    public bool unlimitedCoins = false;
    public bool unlimitedHealth = false;

#if UNITY_EDITOR
    private void OnEnable()
    {
        CoinsCheat();
        HealthCheat();
    }
    private void OnValidate()
    {
        CoinsCheat();
        HealthCheat();
    }
    public void CoinsCheat()
    {
        if (unlimitedCoins)
        {
            currentCoins = 10000000;
        }
        else
        {
            currentCoins = StartingCoins;
        }
        onCoinsChanged?.Invoke(currentCoins);
    }
    public void HealthCheat()
    {
        if (unlimitedHealth)
        {
            currentHealth = 10000000;
        }
        else
        {
            currentHealth = StartingHealth;
        }
        onHealthChanged?.Invoke(currentHealth);
    }
#endif
}
