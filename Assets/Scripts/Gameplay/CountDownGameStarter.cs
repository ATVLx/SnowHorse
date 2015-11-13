using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownGameStarter : MonoBehaviour {

    public Text mTimerText, mActionText;
    private BoardController mBoardController;
    private bool hasStartedTimer = false;
    private bool hasCompleted = false;
    private float timerValue = 3.0f;

	// Use this for initialization
	void Start () {

        mBoardController = GameObject.Find("Board").GetComponent<BoardController>();
        if(mBoardController != null)
        {
            Debug.Log("Success finding Board");
        }

	}
	
	// Update is called once per frame
	void Update () {

        //check if the countdown timer is done
        if (hasCompleted == false)
        {
            //check if the timer has been triggered or not
            if (hasStartedTimer == false)
            {
                //wait for any button to be pressed
                if (Input.anyKey)
                {
                    hasStartedTimer = true;
                    mActionText.gameObject.SetActive(false);
                    mTimerText.gameObject.SetActive(true);
                }

            }
            else
            {
                //timer has started
                //start counting down
                timerValue -= Time.deltaTime;
                mTimerText.text = Mathf.RoundToInt(timerValue).ToString();
                //check if the timer is complete
                if (timerValue < 0)
                {
                    //allow the player to move
                    mBoardController.enablePlayerForGameplay();
                    //stop the timer
                    hasCompleted = true;
                    //disable the panel
                    this.gameObject.SetActive(false);
                }


            }
        }
	
	}
}
