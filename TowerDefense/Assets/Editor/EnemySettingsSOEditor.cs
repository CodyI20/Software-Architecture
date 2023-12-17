using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(EnemySettingsSO))]
public class EnemySettingsSOEditor : Editor
{
    SerializedProperty maxHealthProp;
    SerializedProperty coinsDroppedProp;
    SerializedProperty speedProp;
    SerializedProperty enemyTypeProp;
    SerializedProperty startingHPProp;
    SerializedProperty attackDamageProp;

    private void OnEnable()
    {
        maxHealthProp = serializedObject.FindProperty("MaxHealth");
        coinsDroppedProp = serializedObject.FindProperty("CoinsDropped");
        speedProp = serializedObject.FindProperty("Speed");
        enemyTypeProp = serializedObject.FindProperty("EnemyType");
        startingHPProp = serializedObject.FindProperty("startingHP");
        attackDamageProp = serializedObject.FindProperty("attackDamage");

        SetEnemyTypeFromObjectName();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(maxHealthProp);
        EditorGUILayout.PropertyField(coinsDroppedProp);
        EditorGUILayout.PropertyField(speedProp);
        EditorGUILayout.PropertyField(enemyTypeProp);

        EnemyType selectedEnemyType = (EnemyType)enemyTypeProp.enumValueIndex;

        switch (selectedEnemyType)
        {
            case EnemyType.WEAK:
                EditorGUILayout.PropertyField(startingHPProp, new GUIContent("Starting HP"));
                break;

            case EnemyType.BOSS:
                EditorGUILayout.PropertyField(attackDamageProp, new GUIContent("Attack Damage"));
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void SetEnemyTypeFromObjectName()
    {
        if (serializedObject.targetObject != null)
        {
            string objectName = serializedObject.targetObject.name.ToUpper();

            foreach (EnemyType enemyType in System.Enum.GetValues(typeof(EnemyType)))
            {
                if (objectName.Contains(enemyType.ToString()))
                {
                    enemyTypeProp.enumValueIndex = (int)enemyType;
                    serializedObject.ApplyModifiedProperties();
                    return;
                }
            }

            // If the object name doesn't contain any valid enum, default to DEFAULT
            enemyTypeProp.enumValueIndex = (int)EnemyType.DEFAULT;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif