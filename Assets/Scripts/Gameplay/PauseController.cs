using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseController : MonoBehaviour {

    public GameObject PauseMenu;

	// Use this for initialization
	void Start () {

        //make sure the pause menu is disabled 
        PauseMenu.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {

#if UNITY_XBOXONE

        if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonMenu))
        {
            if (PauseMenu.activeSelf == false)
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }

#endif

#if UNITY_STANDALONE

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (PauseMenu.activeSelf == false)
			{
				PauseMenu.SetActive(true);
				Time.timeScale = 0.0f;
			}
			else
			{
				PauseMenu.SetActive(false);
				Time.timeScale = 1.0f;
			}
		}

#endif
        
	
	}
}
