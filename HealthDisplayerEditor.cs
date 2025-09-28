using UnityEditor;

[CustomEditor(typeof(HealthDisplayer), true)]
public class HealthDisplayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        // Get references
        SerializedProperty displayTypeProp = serializedObject.FindProperty("displayType");
        EditorGUILayout.PropertyField(displayTypeProp);

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
            var textStyleProp = serializedObject.FindProperty("textStyle");

            EditorGUILayout.PropertyField(textStyleProp);

            // Show custom text fields if textStyle is Custom
            if (textStyleProp.enumValueIndex == 3) // Custom
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(HealthDisplayer.MaxHealthTextObject)));
                EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(HealthDisplayer.CurrentHealthTextObject)));
            }
            else
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("TextObject"));
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}
