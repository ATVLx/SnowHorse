using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void loadNewScene(string scene)
    {
        //change the time scale back to normal
        Time.timeScale = 1.0f;
        Application.LoadLevel(scene);
    }
}
