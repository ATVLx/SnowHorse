using UnityEngine;
using System.Collections;

public class horseCustomizationLoader : MonoBehaviour {

    [Header("Do you want to override the save file? and load what you select below?")]
    public bool overrideLoading = false;
    [Header("Which Hat do you want to be loaded?")]
    public int overrideHatNumber = 0;
    [Header("Which Snowboard do you want to be loaded? ")]
    public int overrideSnowboardNumber = 0;

    public GameObject[] m_Hats;
    public GameObject[] m_Snowboards;

    private int currentHatName;
    private int currentBoardName;



	// Use this for initialization
	void Start () {


        //if override is turned on
        if (overrideLoading == false)
        {
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
        else
        {

            //disable all the other boards 
            for (int i = 0; i < m_Snowboards.Length; i++)
            {
                m_Snowboards[i].SetActive(false);
            }
            //override the snowboard and set it active
            m_Snowboards[overrideSnowboardNumber].SetActive(true);

            //disable all the hats
            for (int i = 0; i < m_Hats.Length; i++)
            {
                m_Hats[i].SetActive(false);
            }
            //override the hat and set it active
            m_Hats[overrideHatNumber].SetActive(true);
        }


	}
	


	// Update is called once per frame
	void Update () {
	
	}
}
