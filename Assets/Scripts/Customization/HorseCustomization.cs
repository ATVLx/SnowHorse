using UnityEngine;
using System;
using System.IO;
using System.Collections;

[Serializable]
public class HorseCustomization : MonoBehaviour {

    public int mBoard = 0;
    public int mHat = 0;
    private string jsonData;


	// Use this for initialization
	void Start () {
	


	}

    public void doesCustomizationExist()
    {
        if (File.Exists(Application.dataPath + "/horseCustomization.json"))
        {
            //load the file
            JsonUtility.FromJson<HorseCustomization>(Application.dataPath + "/horseCustomization.json");
            Debug.Log("Loaded: " + jsonData);
        }
        else
        {
            //create the file
            File.Create(Application.dataPath + "/horseCustomization.json");
        }
        
    }

    public void setCustomizationToFile()
    {
        jsonData = JsonUtility.ToJson(this, true);
        File.WriteAllText(Application.dataPath + "/horseCustomization.json", jsonData);

        Debug.Log("Saved Data: " + jsonData);
    }

    public void setHat(int hat)
    {
        //set the hat now
        mHat = hat;
        setCustomizationToFile();
    }

    public void setBoard(int board)
    {
        //set the board now
        mBoard = board;
        setCustomizationToFile();
    }

}
