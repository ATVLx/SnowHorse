/*
 *  Game Manager
 *  This is how we will save our persistent data such as: 
 *  Logged in save data
 *  With this Singleton we can store data we need for later use
 * 
 */

using UnityEngine;
using System.Collections;

public class GameManager
{


    //the name of the horse that is currently selected to use in game
    public string currentHorseSelected;

    //the number of points the  user has earned
    public int points;

    //the date time in ticks from when they last booted up the game
    public int lastTimePlayedTick;

    //This is a string that contains numbers separated by commas. 
    //The numbers are the horses that have been unlocked
    public string numberOfUnlockedHorses;

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

    //load all of the data we saved and assign it to the appropriate variables
    public void Setup()
    {

    }

    //save this class as json
    public string SaveToJSONToString()
    {
        return JsonUtility.ToJson(this, true);
    }

}