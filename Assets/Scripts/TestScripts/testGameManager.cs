using UnityEngine;
using System.Collections;

public class testGameManager : MonoBehaviour {

	public delegate void MyEventHandler();

	// Use this for initialization
	void Start () {

		GameManager.Instance.Setup();
		string datebooted = GameManager.Instance.currentPlayedTime;
		//GameManager.Instance.GameData.Add("dateplayed", datebooted);
		//GameManager.Instance.saveToJSON();
	}

	void test()
	{
		Debug.Log("Setup Complete");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
