using UnityEngine;
using System.Collections;

public class horseCustomizationLoader : MonoBehaviour {

    public GameObject[] m_Hats;
    public GameObject[] m_Snowboards;

    private int currentHatName;
    private int currentBoardName;

	// Use this for initialization
	void Start () {

        

        //load the currentHatName
        if (PlayerPrefs.HasKey("hat"))
        {
            currentBoardName = PlayerPrefs.GetInt("hat");
        }
        else
        {
            //disable all the hats
            for (int i = 0; i < m_Hats.Length; i++)
            {
                m_Hats[i].SetActive(false);
            }

        }

        //load the currentBoardName
        if (PlayerPrefs.HasKey("board"))
        {
            currentHatName = PlayerPrefs.GetInt("board");
        }
        else
        {
            //disable all the board except 1
            for (int i = 1; i < m_Snowboards.Length; i++)
            {
                m_Snowboards[i].SetActive(false);
            }
        }
	
	}
	


	// Update is called once per frame
	void Update () {
	
	}
}
