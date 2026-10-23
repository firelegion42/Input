using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : EditorWindow
{
    private Color color;    

    private float health;

    private AnimationCurve curve;

    private bool toggle;


    [MenuItem("Window/Game Settings Window")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SettingsWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("GameSettings", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        health = EditorGUILayout.FloatField("Health", health);
        

        if (GUILayout.Button("Change color"))
        {
            ChangeColor();            
        }

        GUILayout.Label("Adjust Health", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("+ 10 health"))
        {
            health += 10;
        }
        if (GUILayout.Button("- 10 health"))
        {
            health -= 10;
        }
        EditorGUILayout.EndHorizontal();

        curve = EditorGUILayout.CurveField("A curve", curve);

        toggle = EditorGUILayout.Toggle("On/off", toggle );
        
    }



    private void ChangeColor()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
