using UnityEditor;

[CustomEditor(typeof(HealthDisplayer), true)]
public class HealthDisplayerEditor : Editor
{
    HealthDisplayer healthDisplayer;
    
    SerializedProperty textObject;
    SerializedProperty displayTypeProp;
    SerializedProperty maxHealthTextObject;
    SerializedProperty currentHealthTextObject;
    SerializedProperty slider;
    SerializedProperty backgroundColor;
    SerializedProperty fillColor;
    SerializedProperty textStyleProp;
    private void Awake()
    {
        healthDisplayer = (HealthDisplayer)target;
        // Get references
        displayTypeProp = serializedObject.FindProperty("displayType");
        textObject = serializedObject.FindProperty("TextObject");
        slider = serializedObject.FindProperty("Slider");
        backgroundColor = serializedObject.FindProperty("BackgroundColor"));
        maxHealthTextObject =  = serializedObject.FindProperty(nameof(HealthDisplayer.MaxHealthTextObject));
        currentHealthTextObject = serializedObject.FindProperty(nameof(HealthDisplayer.CurrentHealthTextObject));
        fillColor = serializedObject.FindProperty("FillColor");
        textStyleProp = serializedObject.FindProperty("textStyle");
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(displayTypeProp);
    
        // Show slider settings if displayType is Slider
        if (displayTypeProp.enumValueIndex == 0) // Slider
        {
            EditorGUILayout.LabelField("Slider Settings", EditorStyles.boldLabel);
            
            EditorGUILayout.PropertyField(slider);
            
            EditorGUILayout.PropertyField(backgroundColor);
            
            EditorGUILayout.PropertyField(fillColor);
            
        }

        // Show text settings if displayType is Text
        if (displayTypeProp.enumValueIndex == 1) // Text
        {
            EditorGUILayout.LabelField("Text Settings", EditorStyles.boldLabel);
            

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
