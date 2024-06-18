using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class LoadSceneOnPlay : EditorWindow
{
    static LoadSceneOnPlay()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            EditorSceneManager.LoadScene("Boot");
        }
    }
}
