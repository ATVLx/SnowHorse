using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevelGameplayLevels : MonoBehaviour {

    private bool hasPressedButton = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadBunnyHill()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            SceneManager.LoadSceneAsync("Bunny_Hill_decorated");
            //LoadNewLevelAsync.LoadLevelAsyncNow();
        }
    }

    public void LoadBigAir()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            SceneManager.LoadSceneAsync("BigAir");
            //LoadNewLevelAsync.LoadLevelAsyncNow("BigAir");
        }
    }

    public void LoadSnowPark()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            SceneManager.LoadSceneAsync("SnowPark");
            //LoadNewLevelAsync.LoadLevelAsyncNow("SnowPark");
        }
    }

    public void LoadLittleTokyo()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            SceneManager.LoadSceneAsync("LittleTokyo");
            //LoadNewLevelAsync.LoadLevelAsyncNow("LittleTokyo");
        }
    }

    public void LoadTripleLane ()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            SceneManager.LoadSceneAsync("TripleLane");
            //LoadNewLevelAsync.LoadLevelAsyncNow("TripleLane");
        }
    }

    public void LoadTrickyLane()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            SceneManager.LoadSceneAsync("Tricky_Lane");
            //LoadNewLevelAsync.LoadLevelAsyncNow("Tricky_Lane");
        }
    }

    public void LoadXDerby()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            SceneManager.LoadSceneAsync("X_Derby");
            //LoadNewLevelAsync.LoadLevelAsyncNow("X_Derby");
        }
    }

    public void LoadMainMenu()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            SceneManager.LoadSceneAsync("MainMenu");
            //LoadNewLevelAsync.LoadLevelAsyncNow("MainMenu");
        }
    }

    public void LoadCave()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            SceneManager.LoadSceneAsync("Cave");
            //LoadNewLevelAsync.LoadLevelAsyncNow("Cave");
        }
    }

}
