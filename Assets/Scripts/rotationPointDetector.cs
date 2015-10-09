using UnityEngine;
using System.Collections;

public class rotationPointDetector : MonoBehaviour {

    public float hAxis;
    private float mTimer = 1.0f, mRecoveryTimer;
    public trickPointController m_trickController;

	// Use this for initialization
	void Start () {

        mRecoveryTimer = mTimer;
	}
	
	// Update is called once per frame
	void Update () {

        hAxis = Input.GetAxis("Horizontal");

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
            m_trickController.popPointsTimer("Horse Spinner", 1000);
            //Debug.Log("add points");
        }
    }
}
