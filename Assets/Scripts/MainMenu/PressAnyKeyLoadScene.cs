using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PressAnyKeyLoadScene : MonoBehaviour {

    private Text m_anyKeyText;

	// Use this for initialization
	void Start () {

        m_anyKeyText = GetComponent<Text>();

        //check what platform we are on and change this text
#if UNITY_STANDALONE
        m_anyKeyText.text = "Press Any Key/Button";
#endif

#if UNITY_IOS || UNITY_ANDROID
        m_anyKeyText.text = "Tap to Start";
#endif

#if UNITY_XBOXONE
        m_anyKeyText.text = "Press Any Button";
#endif



	}
	

}
