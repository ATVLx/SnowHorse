using UnityEngine;
using System.Collections;

public class rotationPointDetector : MonoBehaviour {

    private float hAxis, vAxis;
    private float mTimer = 0.5f, mRecoveryTimer;
    public trickPointController m_trickController;
    public BoardController m_boardController;

	// Use this for initialization
	void Start () {

        mRecoveryTimer = mTimer;
	}
	
	// Update is called once per frame
	void Update () {

        hAxis = Input.GetAxis("Horizontal");
		vAxis = Input.GetAxis("Vertical");

        //check if the player is grounded
        if (m_boardController.isGrounded == false)
        {
			//spinning
			spinningDetection();
			//flipping rotation
			flippingDetection();

        }

	}

	private void flippingDetection()
	{
		if (vAxis > 0.4)
		{
			pointTimer();
		}
		else if (vAxis < -0.4)
		{
			pointTimer();
		}
	}

	private void spinningDetection()
	{
		if (hAxis > 0.4)
		{
			pointTimer();
		}
		else if (hAxis < -0.4)
		{
			pointTimer();
		}
	}

    private void pointTimer()
    {
        mTimer -= Time.deltaTime;

        if (mTimer < 0)
        {
            mTimer = mRecoveryTimer;
            m_trickController.popPointsTimer("Horse Spinner", 1000, Color.blue);
            //Debug.Log("add points");
        }
    }
}
