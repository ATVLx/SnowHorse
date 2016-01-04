using UnityEngine;
using System.Collections;

public class testGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameManager.Instance.Setup();
		//Debug.Log(GameManager.Instance.hasDataLoaded);
		GameManager.Instance.saveHighScore(20000000001);
		//GameManager.Instance.GameData.Add("test data", "this is data!");
	}



}
