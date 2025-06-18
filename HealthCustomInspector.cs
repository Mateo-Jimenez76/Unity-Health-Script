using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Health),true)]
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

        if(GUILayout.Button("Heal"))
        {
            health.Heal(1);
        }
        GUILayout.EndHorizontal();
    }
}
