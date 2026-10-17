using UnityEditor;
using UnityEngine;

public class SettingsWindow : EditorWindow
{
    [MenuItem("Window/Game Settings Window")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SettingsWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("GameSettings", EditorStyles.boldLabel);
    }
}
