using UnityEditor;

[CustomEditor(typeof(HealthDisplayer), true)]
public class HealthDisplayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        HealthDisplayer healthDisplayer = (HealthDisplayer)target;
        serializedObject.Update();
        // Get references
        SerializedProperty displayTypeProp = serializedObject.FindProperty("displayType");
        EditorGUILayout.PropertyField(displayTypeProp);
        SerializedProperty textObject = serializedObject.FindProperty("TextObject");
        SerializedProperty maxHealthTextObject = serializedObject.FindProperty(nameof(HealthDisplayer.MaxHealthTextObject));
        SerializedProperty currentHealthTextObject = serializedObject.FindProperty(nameof(HealthDisplayer.CurrentHealthTextObject));
        // Show slider settings if displayType is Slider
        if (displayTypeProp.enumValueIndex == 0) // Slider
        {
            EditorGUILayout.LabelField("Slider Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Slider"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BackgroundColor"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("FillColor"));
        }

        // Show text settings if displayType is Text
        if (displayTypeProp.enumValueIndex == 1) // Text
        {
            EditorGUILayout.LabelField("Text Settings", EditorStyles.boldLabel);
            SerializedProperty textStyleProp = serializedObject.FindProperty("textStyle");

            EditorGUILayout.PropertyField(textStyleProp);
            // Show custom text fields if textStyle is Custom
            if (textStyleProp.enumValueIndex == 3) // Custom
            {
                EditorGUILayout.PropertyField(maxHealthTextObject);
                EditorGUILayout.PropertyField(currentHealthTextObject);
            }
            else
            {
                if (textObject.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("A TextMeshProUGUI component is required in order to provide real time display updates.", MessageType.Warning);
                }
                EditorGUILayout.PropertyField(textObject);
            }
        }
        serializedObject.ApplyModifiedProperties();
        healthDisplayer.UpdateHealthDisplayEditor();
    }
}
