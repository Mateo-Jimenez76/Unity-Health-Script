using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Health), true)]
public class HealthCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Health health = (Health)target;

        //Makes inspector settings side by side
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Take Damage"))
        {
            health.Damage(1);
        }

        if (GUILayout.Button("Die"))
        {
            health.Damage(health.GetMaxHealth());
        }

        if (GUILayout.Button("Heal"))
        {
            health.Heal(1);
        }
        GUILayout.EndHorizontal();
    }
}

[CustomEditor(typeof(HealthDisplayer),true)]
public class HealthDisplayerCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        HealthDisplayer healthDisplayer = (HealthDisplayer)target;
        // Get references
        HealthDisplayer.DisplayType displayTypeProp = serializedObject.FindProperty(nameof(HealthDisplayer.displayType));
        EditorGUILayout.PropertyField(displayTypeProp);

        // Show slider settings if displayType is Slider
        if (displayTypeProp.value == HealthDisplayer.DisplayType.Slider) // Slider
        {
            EditorGUILayout.LabelField("Slider Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(HealthDisplayer.slider)));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(HealthDisplayer.backgroundColor)));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(HealthDisplayer.fillColor)));
        }

        // Show text settings if displayType is Text
        if ((int)displayTypeProp.enumValueIndex == 1) // Text
        {
            EditorGUILayout.LabelField("Text Settings", EditorStyles.boldLabel);
            var textStyleProp = serializedObject.FindProperty(nameof(HealthDisplayer.textStyle));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(HealthDisplayer.textObject)));
            EditorGUILayout.PropertyField(textStyleProp);

            // Show custom text fields if textStyle is Custom
            if ((int)textStyleProp.enumValueIndex == 3) // Custom
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(HealthDisplayer.maxHealthTextObject)));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(HealthDisplayer.currentHealthTextObject)));
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
