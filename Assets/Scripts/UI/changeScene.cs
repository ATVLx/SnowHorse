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
        //playMusicAgain();
        LoadNewLevelAsync.LoadLevelAsyncNow(scene);
    }

    public void loadSameScene()
    {
        //change the time scale back to normal
        Time.timeScale = 1.0f;
        playMusicAgain();
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void playMusicAgain()
    {
        GameObject _music = GameObject.Find("_Music");
        if (_music != null)
        {
            _music.GetComponent<musicControls>().musicPlay();
            Debug.Log("Playing Music Again");
        }
    }
}
