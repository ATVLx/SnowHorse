using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class PrototypeLevel : EditorWindow {

    public string CurrentDataPath = null;
    public GameObject Board;
    public GameObject Canvas;
    public GameObject Level;
    public GameObject Rail, Ramp;
    public GameObject Exit;

    [MenuItem("Snow Horse/Level Prototyper")]
    static void ShowEditor()
    {

        PrototypeLevel editor = EditorWindow.GetWindow<PrototypeLevel>();
        editor.minSize = new Vector2(200, 500);

        editor.Init();
    }

    public void Init()
    {
        //get the directory we are in so we can make our paths relative
        //Assetdatabase.LoadAsset requires a relative path
        CurrentDataPath = System.Environment.CurrentDirectory + "/";

    }

    public GameObject _board;
    public GameObject _canvas;

    void OnGUI()
    {

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Protoype Levels");
        EditorGUILayout.TextArea("Use this tool to create and prototype levels quickly.", "helpbox");
        GUILayout.Space(10);

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Setup the Scene");
        EditorGUILayout.TextArea("Make sure you are in a new scene. Control+N", "helpbox");
        if (GUILayout.Button("Setup Scene"))
        {
            //create a new Board Object in the scene
            if (GameObject.Find("Board") == null)
            {
                _board = Instantiate(Board, new Vector3(20.0f, 16.59f, 0), Quaternion.identity) as GameObject;
                _board.name = "Board";
            }
            else
            {
                _board = GameObject.Find("Board");
                Debug.Log("<color=green>Board Already Exists</color>");
            }

            //Create a new canvas
            if (GameObject.Find("Canvas") == null)
            {
                _canvas = Instantiate(Canvas, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                _canvas.name = "Canvas";
                //assign the trick controller to the fields it needs
                _board.GetComponent<BoardController>()._trickController = _canvas.GetComponent<trickPointController>();
                _board.GetComponent<rotationPointDetector>().m_trickController = _canvas.GetComponent<trickPointController>();
            }
            else
            {
                _canvas = GameObject.Find("Canvas");
                Debug.Log("<color=green>Canvas Already Exists</color>");
            }

            //find the main camera and add the script needed
            // add the Board to the object to follow
            GameObject.Find("Main Camera").AddComponent<cameraController>();
            GameObject.Find("Main Camera").GetComponent<cameraController>().m_Board = _board;
            GameObject.Find("Main Camera").transform.position = new Vector3( 24.20f, 20.31f, 0);
            GameObject.Find("Main Camera").transform.eulerAngles = new Vector3(30, -90, 0);
            GameObject.Find("Main Camera").GetComponent<cameraController>().m_Offset = new Vector3( 4, 4, 0);

            //create the ground
            //tag the ground as Ridable

            GameObject _level;
            _level = GameObject.Find("_Level");
            if (_level == null)
            {
                //create a new level
                _level = Instantiate(Level, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                _level.name = "_Level";
            }
            _level.transform.position = new Vector3(521, 293, 0);

            //change the directional light angle
            GameObject.Find("Directional Light").transform.eulerAngles = new Vector3(26, 133, 168);

            //create the exit
            GameObject _Exit;
            _Exit = Instantiate(Exit, new Vector3(-971, -358, -3.7f), Quaternion.identity) as GameObject;
            _Exit.name = "Exit_Trigger";

        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Primatives");

        if (GUILayout.Button("Rail"))
        {
            //create a rail
            GameObject _rail;
            _rail = Instantiate(Rail, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            _rail.name = "rail";

            GameObject _parent = GameObject.Find("_Level");
            if (_parent == null)
            {
                GameObject _newLevel = new GameObject();
                _newLevel.name = "_Level";
            }

            _rail.transform.parent = _parent.transform;

            //tag as Rail
            _rail.tag = "Rail";
        }

        if (GUILayout.Button("Ramp"))
        {
            //create a rail
            GameObject _rail;
            _rail = Instantiate(Ramp, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            _rail.name = "Ramp";

            GameObject _parent = GameObject.Find("_Level");
            if (_parent == null)
            {
                GameObject _newLevel = new GameObject();
                _newLevel.name = "_Level";
            }

            _rail.transform.parent = _parent.transform;

            //tag as Rail
            _rail.tag = "Ridable";
        }

        if (GUILayout.Button("Level Exit - End of Run"))
        {

            if (GameObject.Find("Exit_Trigger") == null)
            {
                //create the exit
                GameObject _Exit;
                _Exit = Instantiate(Exit, new Vector3(-971, -358, -3.7f), Quaternion.identity) as GameObject;
                _Exit.name = "Exit_Trigger";
            }
            else
            {
                Debug.Log("<color=green>Exit_Trigger already exists in scene</color>");
            }

        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Tag Models");

        if (GUILayout.Button("Tag as Ramp"))
        {
            GameObject _tempRamp = Selection.activeGameObject;
            _tempRamp.tag = "Ridable";
        }

        if (GUILayout.Button("Tag as Rail"))
        {
            GameObject _tempRamp = Selection.activeGameObject;
            _tempRamp.tag = "Rail";
        }


    }

}
