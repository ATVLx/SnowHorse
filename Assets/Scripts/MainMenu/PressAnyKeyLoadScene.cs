using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PressAnyKeyLoadScene : MonoBehaviour {

    private Text m_anyKeyText;
    public string sceneToLoad;

	// Use this for initialization
	void Start () {

        m_anyKeyText = GetComponent<Text>();

        //check what platform we are on and change this text
#if UNITY_STANDALONE
        m_anyKeyText.text = "Press Any Key/Button";
#endif

#if UNITY_XBOXONE
        m_anyKeyText.text = "Press Any Button";
#endif



	}
	
	// Update is called once per frame
	void Update () {

        //Check if there is any input so we can load the Main Menu
        if (Input.anyKey)
        {
            loadSceneNow();
        }

    }

    private void loadSceneNow()
    {
        Application.LoadLevel(sceneToLoad);
    }
}
