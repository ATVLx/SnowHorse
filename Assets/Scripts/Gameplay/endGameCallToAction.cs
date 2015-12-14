using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class endGameCallToAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKey)
        {
            Debug.Log("Loading the Level Selection Screen");
            SceneManager.LoadScene("Level Selection");
            //Application.LoadLevel("Level Selection");
        }

	}
}
