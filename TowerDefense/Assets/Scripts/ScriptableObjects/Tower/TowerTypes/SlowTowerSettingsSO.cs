using UnityEngine;

[CreateAssetMenu(fileName = "TowerSettings", menuName = "ScriptableObjects/TowerSettings/SlowTowerSettings", order = 1)]
public class SlowTowerSettingsSO : TowerSettingsSO
{
    [Range(0,100)] public float SlowPercentage;
}
