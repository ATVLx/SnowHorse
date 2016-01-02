/*
 *  Game Manager
 *  This is how we will save our persistent data such as: 
 *  Logged in save data
 *  With this Singleton we can store data we need for later use
 * 
 */

using UnityEngine;
using MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager
{

    //the name of the horse that is currently selected to use in game
    public string currentHorseSelected;

    //the number of points the  user has earned
    public int points;

    //the date time in ticks from when they last booted up the game
    public string lastTimePlayedTick;
	//the time it is right at boot. 
	//use this time to compare agaist the last time played
	public string currentPlayedTime;

    //This is a string that contains numbers separated by commas. 
    //The numbers are the horses that have been unlocked
    public string numberOfUnlockedHorses;

	public Dictionary<string,object> GameData = new Dictionary<string, object>();


    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
				Debug.Log("Created a new game manager");
            }
            return instance;
        }
    }

    //load all of the data we saved and assign it to the appropriate variables
    public void Setup()
    {
		getTicksOnStart();
    }

	//get the date right now in ticks
	//this will be used to compared against the saved date
	private void getTicksOnStart()
	{
		//get the date right now and convert it to ticks
		string currentDate = DateTime.Now.Ticks.ToString();

		//set the date we just got in ticks to the public variable
		currentPlayedTime = currentDate;
	}

	/// <summary>
	/// Saves the GameData Dictionary to a JSON String
	/// Then Saves to the appropriate location
	/// </summary>
	public void saveToJSON()
	{
		var str = Json.Serialize(GameData);
		Debug.Log(str);
	}

    /// <summary>
    /// Gets the JSON string and Deserializes it to the GameData Dictionary
    /// </summary>
    /// <param name="jsonString">Json string.</param>
	public void getFromJSON()
    {
		//read data from location then pass to method below: jsonString

		//GameData = Json.Deserialize(jsonString) as Dictionary<string,object>;
    }

	public void OnDisable()
	{
		Debug.Log("OnDisable called");
	}

	public void OnDestroy()
	{
		Debug.Log("Being Destoryed");
	}


}