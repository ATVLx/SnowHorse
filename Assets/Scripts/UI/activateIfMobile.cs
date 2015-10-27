using UnityEngine;
using System.Collections;

public class activateIfMobile : MonoBehaviour {

	// Use this for initialization
	void Start () {

#if UNITY_STANDALONE
        this.gameObject.SetActive(false);
#endif

#if UNITY_IOS || UNITY_ANDROID
        this.gameObject.SetActive(true);
#endif

#if UNITY_XBOXONE
        this.gameObject.SetActive(false);
#endif


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
