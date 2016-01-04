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
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class GameManager
{

	//game data keys
	#region gamedata keys

	/// <summary>
	/// A GameData key for Last Time Played
	/// </summary>
	public string lasttimeplayed = "lasttimeplayed";
	/// <summary>
	/// The current highscore of the user saved locally
	/// </summary>
	public string currenthighscore = "highscore";

	#endregion


    /// Get current time at Game Boot. Use this time to compare agaist the last time played
    private string currentPlayedTime;
	public bool canDoDailyChallenge = false;


	#region json data paths and loading variables
    
	private string mobileDataPath;
    private string standaloneDataPath;
    public bool hasDataLoaded = false;
    private string readfromfilejson;

	#endregion

	public Dictionary<string,object> GameData = new Dictionary<string, object>();


    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }


    /// <summary>
    /// load all of the data we saved and assign it to the appropriate variables
    /// </summary>
    public void Setup()
    {
        //get all the data paths and start reading json
        startjsonreading();

    }

	public void saveHighScore(long score)
	{
		//check if the key exists
		if(GameData.ContainsKey(currenthighscore))
		{
			if((long)GameData[currenthighscore] < score)
			{
				GameData[currenthighscore] = score;
				Debug.Log("Over wrote the highscore");
			}
			else
			{
				Debug.Log("Score passed wasn't larger than saved score");
			}
		}
		else
		{
			if((long)GameData[currenthighscore] < score)
			{
				GameData.Add(currenthighscore, score);
				Debug.Log("Added a new highscore");
			}
			else
			{
				Debug.Log("Score passed wasn't larger than saved score");
			}
		}
	}

    //get the date right now in ticks
    //this will be used to compared against the saved date
	public void checkLastTimePlayed()
    {
        //get the date right now and convert it to ticks
        string currentDate = DateTime.Now.Ticks.ToString();

        //set the date we just got in ticks to the public variable

        currentPlayedTime = currentDate;

		if(GameData.ContainsKey(lasttimeplayed))
		{
			//key exists 
			//set the data to a public variable
			long dicTimeStamp = (long) GameData[lasttimeplayed];
			//check if difference from now and the last time stamp saved is 24 hours
			long subtractedValue = dicTimeStamp - Convert.ToInt64(currentPlayedTime);
			if(subtractedValue >= TimeSpan.TicksPerDay)
			{
				//unlock the daily challenge
				canDoDailyChallenge = true;
				Debug.Log("Can Do Daily Challenge: " + canDoDailyChallenge);
			}
			else
			{
				//lock the daily challenge because they are back in less than 24 hours
				canDoDailyChallenge = false;
				Debug.Log("Can Do Daily Challenge: " + canDoDailyChallenge);
			}
			

		}
		else
		{
			//key doesn't exist
			//take the time we just got and make a key for it
			GameData.Add(lasttimeplayed, Convert.ToInt64(currentPlayedTime));
			//Unlock the daily challenge
			//this is their first time playing. Allow them to play the daily challenge
			canDoDailyChallenge = true;
			Debug.Log("Can Do Daily Challenge: " + canDoDailyChallenge);
		}

    }

    #region json data reading


    private void startjsonreading()
    {

#if UNITY_IOS || UNITY_ANDROID
        mobileDataPath = Application.persistentDataPath + "/" + "SnowHorse/" + "gamedata.json";
        //pull the json data from the file
        
        //check to see if directory and file exists
        if (File.Exists(mobileDataPath))
        {
            //pull the json data from the file
            //readJSONFromFile(mobileDataPath);
			//read the json data
			string readJSON = File.ReadAllText(mobileDataPath);
			//set the json to a global variable in the gamemanager
			readfromfilejson = readJSON;
			//read data from location then pass to method below: jsonString
			GameData = Json.Deserialize(readfromfilejson) as Dictionary<string,object>;
        }
        else
        {
            //create the directory
            Directory.CreateDirectory(Application.persistentDataPath + "/" + "SnowHorse");
        }

#elif UNITY_STANDALONE

        standaloneDataPath = Application.persistentDataPath + "/" + "SnowHorse/" + "gamedata.json";

		//Debug.Log("checking if the path exists");

        //check to see if directory and file exists
        if (File.Exists(standaloneDataPath))
        {
			//Debug.Log("path exists");

            //pull the json data from the file
            //readJSONFromFile(standaloneDataPath);
			//read the json data
			string readJSON = File.ReadAllText(standaloneDataPath);
			//set the json to a global variable in the gamemanager
			readfromfilejson = readJSON;
			//read data from location then pass to method below: jsonString
			GameData = Json.Deserialize(readfromfilejson) as Dictionary<string,object>;

        }
        else
        {
            //create the directory
            Directory.CreateDirectory(Application.persistentDataPath + "/" + "SnowHorse");
        }

#endif
		//mark that we have loaded the data
		hasDataLoaded = true;

		//start the 24 hour check 
		checkLastTimePlayed();
    }
		


	/// <summary>
	/// Saves the GameData Dictionary to a JSON String
	/// Then Saves to the appropriate location
	/// </summary>
	public void saveToJSON()
	{
		if(hasDataLoaded)
		{

			var str = Json.Serialize(GameData);

	        //save the game data to their given platforms
	#if UNITY_IOS || UNITY_ANDROID
			File.WriteAllText(mobileDataPath, str);
			Debug.Log(standaloneDataPath);
	#elif UNITY_STANDALONE
	        File.WriteAllText(standaloneDataPath, str);
			Debug.Log(standaloneDataPath);

	#endif

			Debug.Log("JSON Data :" + str);
		}


	}

	/// <summary>
	/// Deletes the file at a given location
	/// </summary>
	/// <param name="location">Location - the location of the file</param>
	public void deleteFile(string location)
	{
		File.Delete(location);
	}

    #endregion



}