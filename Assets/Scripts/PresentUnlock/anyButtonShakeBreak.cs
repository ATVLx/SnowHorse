using UnityEngine;
using System.Collections;

public class anyButtonShakeBreak : MonoBehaviour {

	private bool hasActivated = false;
	public GameObject actionText, confetti;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

		if(Input.anyKeyDown && hasActivated == false)
		{
			hasActivated = true;
			actionText.SetActive(false);
			confetti.SetActive(true);
			iTween.ShakePosition(this.gameObject, new Vector3(0.2f, 0.2f, 0.2f), 0.5f);
			Invoke("destroyPackage", 0.5f);
		}
	
	}

	private void destroyPackage()
	{
		Destroy(this.gameObject);
	}
}
