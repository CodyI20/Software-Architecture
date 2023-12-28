using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player")]
public class PlayerDataSO : ScriptableObject
{
    [Min(1)] public int StartingHealth = 10;
    [Min(0)] public int StartingCoins = 100;
}
