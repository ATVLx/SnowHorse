using UnityEngine;
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
            LoadNewLevelAsync.LoadLevelAsyncNow("Bunny_Hill");
        }
    }

    public void LoadBigAir()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            LoadNewLevelAsync.LoadLevelAsyncNow("BigAir");
        }
    }

    public void LoadSnowPark()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            LoadNewLevelAsync.LoadLevelAsyncNow("SnowPark");
        }
    }

    public void LoadLittleTokyo()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            LoadNewLevelAsync.LoadLevelAsyncNow("LittleTokyo");
        }
    }

    public void LoadXDerby()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            LoadNewLevelAsync.LoadLevelAsyncNow("X_Derby");
        }
    }

    public void LoadMainMenu()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            LoadNewLevelAsync.LoadLevelAsyncNow("MainMenu");
        }
    }

    public void LoadCave()
    {
        if (hasPressedButton == false)
        {
            hasPressedButton = true;
            LoadNewLevelAsync.LoadLevelAsyncNow("Cave");
        }
    }

}
