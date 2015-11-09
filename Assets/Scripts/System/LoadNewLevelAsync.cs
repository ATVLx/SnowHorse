/* 1. Create an object with this script attached
/  2. Set the name of the level you want to load
/  3. Call Start Load
/  4. Loads into a blank Scene called Loading Screen
/  5. Loads the level Async
*/

using UnityEngine;
using System.Collections;

public class LoadNewLevelAsync : MonoBehaviour {

    private AsyncOperation async;
    public string levelToLoad;
    private string loadScreenLevel = "LoadingScreen";


    // Use this for initialization
    public void StartLoadScene () {

        DontDestroyOnLoad(this.gameObject);

        //load the blank scene with the loading animation
        Application.LoadLevel(loadScreenLevel);
        //start the level async operation
        Invoke("AsyncLevelAfterLoadingScreen", 2.0f);
    }

    private void AsyncLevelAfterLoadingScreen()
    {

        StartCoroutine(StartAsyncLoadLevel());
    }

    IEnumerator StartAsyncLoadLevel()
    {

        async = Application.LoadLevelAsync(levelToLoad);
        yield return async;
        Debug.Log("Loading" + levelToLoad + "complete");
        Destroy(this.gameObject);
    }

    public static void LoadLevelAsyncNow(string levelToBeLoaded)
    {
        GameObject _new = new GameObject();
        _new.name = "AsyncLevelLoader";
        _new.AddComponent<LoadNewLevelAsync>();
        _new.GetComponent<LoadNewLevelAsync>().levelToLoad = levelToBeLoaded;
        Debug.Log("Create Async Object. Loading: " + levelToBeLoaded + " Now");
        _new.GetComponent<LoadNewLevelAsync>().StartLoadScene();
    }
}
