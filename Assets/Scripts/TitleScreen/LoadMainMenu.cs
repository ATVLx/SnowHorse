using UnityEngine;
using System.Collections;

public class LoadMainMenu : MonoBehaviour {

    private bool hasPressedButton = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Check if there is any input so we can load the Main Menu
        if (Input.anyKey && hasPressedButton == false)
        {
            hasPressedButton = true;
            LoadNewLevelAsync.LoadLevelAsyncNow("MainMenu");
        }


    }
}
