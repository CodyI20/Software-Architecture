#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WeakEnemySettingsSO))]
public class WeakEnemySettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        WeakEnemySettingsSO settings = (WeakEnemySettingsSO)target;

        // Ensure startingHP is within the valid range
        settings.startingHP = Mathf.Clamp(settings.startingHP, 0, settings.MaxHealth);

        EditorUtility.SetDirty(target);
    }
}
#endif
