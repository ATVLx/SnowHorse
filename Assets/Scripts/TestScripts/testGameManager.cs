using UnityEngine;
using System.Collections;

public class testGameManager : MonoBehaviour {

	public delegate void MyEventHandler();

	// Use this for initialization
	void Start () {

		GameManager.Instance.Setup();
		//Debug.Log(GameManager.Instance.hasDataLoaded);

		//GameManager.Instance.GameData.Add("test data", "this is data!");

		//Invoke("test", 1.0f);
	}

	void test()
	{
		if(GameManager.Instance.hasDataLoaded == true)
		{
			GameManager.Instance.GameData.Add("test data", "this is data!");
			Debug.Log("Setup Complete");
		}
		else
		{
			Debug.Log("Trying Again");
			Invoke("test", 1.0f);
		}
	}


}
