/*
 * Title: Game Event Saving
 * This is used to save the game data if the player has any of the following events happen:
 * Game Window: OnApplicationQuit
 * 
 */ 

using UnityEngine;
using System.Collections;

public class GameEventSaving : MonoBehaviour {


	public void Start()
	{
		//Dont destory this gameObject
		DontDestroyOnLoad(this.gameObject);
	}

	void OnApplicationQuit() 
	{
		
		//save the game data we have since the application is being destroyed
		GameManager.Instance.saveToJSON();
		//Debug.Log("Application is quitting save the data!");
	}

}
