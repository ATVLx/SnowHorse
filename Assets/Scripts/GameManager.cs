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

    /// <summary>
    /// the date time in ticks from when they last booted up the game
    /// </summary>
    //public string lastTimePlayedTick;

    /// <summary>
    /// Get current time at Game Boot. Use this time to compare agaist the last time played
    /// </summary>
    public string currentPlayedTime;


    private string mobileDataPath;
    private string standaloneDataPath;
    private bool dataLoaded = false;
    private string readfromfilejson;

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

        //get the time it was when the application booted
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
            readJSONFromFile(mobileDataPath);
        }
        else
        {
            //create the directory
            Directory.CreateDirectory(Application.persistentDataPath + "/" + "SnowHorse");
            File.WriteAllText(standaloneDataPath, "new save data here");
        }
#elif UNITY_STANDALONE

        standaloneDataPath = Application.persistentDataPath + "/" + "SnowHorse/" + "gamedata.json";

        //check to see if directory and file exists
        if (File.Exists(standaloneDataPath))
        {
            //pull the json data from the file
            readJSONFromFile(standaloneDataPath);
        }
        else
        {
            //create the directory
            Directory.CreateDirectory(Application.persistentDataPath + "/" + "SnowHorse");
            File.WriteAllText(standaloneDataPath, "new save data here");
        }

#endif

    }

    /// <summary>
    /// Reads the given json from the location send
    /// @ param - location - the location to read the json
    /// </summary>
    /// <param name="location"></param>
    private void readJSONFromFile(string location)
    {
        //read the json data
        string readJSON = File.ReadAllText(location);
        //set the json to a global variable in the gamemanager
        readfromfilejson = readJSON;
        //convert the json to a dictionary
        getFromJSON();

    }



	/// <summary>
	/// Saves the GameData Dictionary to a JSON String
	/// Then Saves to the appropriate location
	/// </summary>
	public void saveToJSON()
	{
		var str = Json.Serialize(GameData);

        //save the game data to their given platforms
#if UNITY_IOS || UNITY_ANDROID
        File.WriteAllText(mobileDataPath, str);
#elif UNITY_STANDALONE
        File.WriteAllText(standaloneDataPath, str);
#endif
        Debug.Log(str);
	}

    /// <summary>
    /// Gets the JSON string and Deserializes it to the GameData Dictionary
    /// </summary>
    /// <param name="jsonString">Json string.</param>
	private void getFromJSON()
    {
		//read data from location then pass to method below: jsonString
		GameData = Json.Deserialize(readfromfilejson) as Dictionary<string,object>;
        if(GameData != null)
        {
            dataLoaded = true;
        }
    }

    #endregion

    /// <summary>
    /// saves the json data when the game manager is disabled
    /// </summary>
    public void OnDisable()
	{
        //save the game data we have since the application is disabled
        saveToJSON();
		Debug.Log("OnDisable called");
	}

    /// <summary>
    /// saves the json data when the game manager is destroyed
    /// </summary>
	public void OnDestroy()
	{
        //save the game data we have since the application is being destroyed
        saveToJSON();

        Debug.Log("Being Destoryed");
	}


}