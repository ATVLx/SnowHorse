using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class trickPointController : MonoBehaviour {

    [Header("UI Settings")]
    public Slider m_PointCountDownSlider;
    public int m_Points;
    public Text m_TrickNameText;
    public Text m_TrickPointText;
    public Text m_PointsText;
    public GameObject PointsPanel;

    [Header("Timer Settings")]
    public bool canCountdown = false;
    private float m_Timer = 4.0f;
    private float m_RecoveryTimer = 4.0f;
    public bool hasTimer = false;

	[Header("Trick Settings")]
	public int m_trickValue;
	public int m_numOfTricks = 1;

	// Use this for initialization
	void Start () {

        //set the slider max to the timer value
        m_PointCountDownSlider.maxValue = m_Timer;
        //set the timer to the top
        m_PointCountDownSlider.value = m_Timer;

        //fake trick
        //popPointsTimer("Horse Kick!", 1000);
	
	}

    public void popPointsTimer(string trickName, int pointValue, Color textColor)
    {
        //check to see if the UI is already up
        if (hasTimer == false)
        {
            hasTimer = true;
            PointsPanel.SetActive(true);
        }

        m_TrickNameText.color = textColor;

		//add the points to the trick value
		m_trickValue += pointValue;
		m_numOfTricks++;

        //reset the timer because we did a new trick
        m_Timer = m_RecoveryTimer;

        //set the point value
        m_TrickPointText.text = m_trickValue + " x " + m_numOfTricks;
        //set the trick name
        m_TrickNameText.text = trickName;
        //start the countdown timer
        canCountdown = true;

        //add the points value
        m_Points = (pointValue * m_numOfTricks);

    }

    public void endTrickTimer()
    {
        //check if the timer is running and if the timer has a value
        if (m_Timer > 0 && hasTimer == true)
        {
            m_Timer = 0.01f;
        }
    }

	// Update is called once per frame
	void Update () {

        if (canCountdown == true)
        {
            m_Timer -= Time.deltaTime;
            m_PointCountDownSlider.value = m_Timer;
            if (m_Timer < 0)
            {
                //done
                canCountdown = false;
                hasTimer = false;
                //disable the timer value and add to the points
                PointsPanel.SetActive(false);
                //add the points to the total value
                m_PointsText.text = "Score: " + m_Points.ToString();
            }

        }
	
	}
}
