using UnityEngine;
using UnityEditor;
using System.Collections;

public class AutoSave : EditorWindow {

    private float saveTime = 60;
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

        stopAutoSave = GUILayout.Toggle(stopAutoSave, "Stop Auto Save");

        if (stopAutoSave == false)
        {
            EditorGUILayout.LabelField("Save Each:", saveTime + " Secs");

            double timeToSave = nextSaveTime - EditorApplication.timeSinceStartup;

            EditorGUILayout.LabelField("Next Save:", timeToSave.ToString() + " Sec");
            this.Repaint();

            if (EditorApplication.timeSinceStartup > nextSaveTime)
            {
                var path = EditorApplication.currentScene.Split(char.Parse("/"));
                path[path.Length - 1] = "AutoSave_" + path[path.Length - 1];

                EditorApplication.SaveScene(string.Join("/", path), true);
                Debug.Log("Saved Scene");

                nextSaveTime = EditorApplication.timeSinceStartup + saveTime;
            }
        }

    }


	// Update is called once per frame
	void Update () {
	
	}
}
