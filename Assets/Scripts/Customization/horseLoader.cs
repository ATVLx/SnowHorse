/*
 * Title: Horse Loader
 * Checks the GameManager which horse to load 
 * Then finds that prefab with the same name and instantiates it
 * 
 */ 

using UnityEngine;
using System.Collections;

public class horseLoader : MonoBehaviour {

	private string horseToLoad;
	public GameObject[] horses;


	// Use this for initialization
	void Start () {
	
		//get the name of the prefab that the user is playing as
		horseToLoad = GameManager.Instance.getCurrentHorse();
		Debug.Log("Current Horse: " + horseToLoad);

		//cycle through the prefabs and check for the prefab name we got from the GameManager
		for (int i = 0; i < horses.Length; i++) 
		{
			if(horses[i].name.ToLower()	== horseToLoad.ToLower())
			{
				Debug.Log("Found Horse: " + horseToLoad);
			}
			else
			{
				//are we at the limit? then instantiate the default horse
				//because we didn't find anything
				if(i == horses.Length - 1)
				{
					Debug.Log("Couldn't find horse name. Loading normal horse");
				}
			}
		}

	}

}
