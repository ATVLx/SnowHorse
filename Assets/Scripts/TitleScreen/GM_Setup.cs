/*
 * Title: Game Manager Setup
 * Calls setup on the Game Manager which loads the JSON save file where the save data is located
 */ 

using UnityEngine;
using System.Collections;

public class GM_Setup : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameManager.Instance.Setup();
		Debug.Log("Called Setup on Game Manager");
	}

}
