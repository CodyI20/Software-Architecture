using UnityEngine;

[CreateAssetMenu(fileName = "TowerSettings", menuName = "ScriptableObjects/TowerSettings/SlowTowerSettings", order = 1)]
public class SlowTowerSettingsSO : TowerSettingsSO, ISerializationCallbackReceiver
{
    [Range(0, 100)] public float InitialSlowPercentage;
    [Range(0,100)] public float SlowPercentage;

    public override void OnAfterDeserialize()
    {
        SlowPercentage = InitialSlowPercentage;
    }
}
