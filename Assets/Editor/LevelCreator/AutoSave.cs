/* Created by Chris Figueroa - @Kinifi
 * Create a script called AutoSave.cs
 */

using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class AutoSave : EditorWindow {

    private float saveTime = 30;
    private double nextSaveTime = 0;
    private bool stopAutoSave;

    [MenuItem("Snow Horse/AutoSave Level")]
    static void ShowEditor()
    {

        AutoSave editor = EditorWindow.GetWindow<AutoSave>();
        editor.minSize = new Vector2(300, 100);
        editor.maxSize = new Vector2(300, 100);

        editor.Init();
    }

    public void Init()
    {
        Debug.Log("The level will now be saved automatically");
    }

    void OnGUI()
    {

        GUILayout.Label("Auto Saves Level Every 30 Seconds");
        stopAutoSave = GUILayout.Toggle(stopAutoSave, "Stop Auto Save");
        GUILayout.Space(10);

        if (stopAutoSave == false && EditorApplication.isCompiling == false && EditorApplication.isPlaying == false)
        {
            EditorGUILayout.LabelField("Save Each:", saveTime + " Secs");

            double timeToSave = nextSaveTime - EditorApplication.timeSinceStartup;

            EditorGUILayout.LabelField("Next Save:", timeToSave.ToString() + " Sec");
            this.Repaint();

            if (EditorApplication.timeSinceStartup > nextSaveTime)
            {

                Scene _currentScene = EditorSceneManager.GetActiveScene();
                var path = _currentScene.path;
                //Debug.Log(path);
                

                //EditorApplication.SaveScene(path, true);
                //EditorApplication.SaveScene();
                EditorSceneManager.SaveScene(_currentScene);
                EditorApplication.SaveAssets();
                Debug.Log("Saved Scene: " + path);

                nextSaveTime = EditorApplication.timeSinceStartup + saveTime;
            }
        }

    }


	// Update is called once per frame
	void Update () {
	
	}
}
