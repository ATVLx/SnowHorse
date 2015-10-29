using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {


    [HideInInspector]
    public float hAxis, vAxis, rightHAxis, rightVAxis;
    private Rigidbody _rigid;

    [Header("Deadzone Settings")]
    public float deadZone = 0.2f;

    [Header("Torque Settings")]
    public float torque = 150.0f;
	public float flippingTorque = 100.0f;
    private Transform startPosition;

    [Header("Trick Settings")]
    public trickPointController _trickController;
    private bool hasGivenRailPoints = false;

    [Header("Raycast Settings")]
    private float rayDistance = 0.1f;

    [Header("Air Settings")]
    public bool isGrounded = false;
    public float jumpHeight = 400;

    [Header("Animation Settings")]
    public Animator _anim;

	[Header("One Time Air Events")]
	public bool oneTimeEvents = false;

	// Use this for initialization
	void Start () {

        //store the start position
        startPosition = transform;
        //get the rigidbody
        _rigid = GetComponent<Rigidbody>();

        //get the trickpointcontroller
        _trickController = GameObject.Find("Canvas").GetComponent<trickPointController>();
        if (_trickController == null)
        {
            Debug.Log("<color=red>Couldn't find Canvas in Hierarchy</color>");
        }

	}
	
	// Update is called once per frame
	void Update () {

#if UNITY_STANDALONE || UNITY_XBOXONE
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        rightHAxis = Input.GetAxis("Horizontal2");
        rightVAxis = Input.GetAxis("Vertical2");
#endif

        //check to see if we are touching the ground or a rail
        RaycastHit hit;
        Debug.DrawRay(transform.position, -Vector3.up * rayDistance, Color.green);
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, rayDistance))
        {
			//HIT SOMETHING

			//Did we hit a rail?
            if (hit.transform.tag == "Rail")
            {
                isGrounded = false;
                if (hasGivenRailPoints == false)
                {
                    //give rail points
                    hasGivenRailPoints = true;
                    _trickController.popPointsTimer("Hay Slide", 3400, Color.black);
                }
                
            }
            else
            {

				//No we didn't hit a rail! We touched the ground!!
                _trickController.endTrickTimer();
				_trickController.m_trickValue = 0;
				_trickController.m_numOfTricks = 1;
                isGrounded = true;

                //give back rail point privledges since we have landed
                hasGivenRailPoints = false;

                if (transform.localEulerAngles.y > 260 && transform.localEulerAngles.y < 320)
                {
                    _rigid.AddTorque(transform.up * 8000 * Time.deltaTime);
                    //Debug.Log("Correct right");
                }
                else if (transform.localEulerAngles.y > 30 && transform.localEulerAngles.y < 140)
                {
                    _rigid.AddTorque(-transform.up * 8000 * Time.deltaTime);
                    //Debug.Log("CORRECT left!");
                }
                else
                {
                    _rigid.angularVelocity = Vector3.zero;
                }
                

            }
        }
        else
        {
            isGrounded = false;
        }

        //is the player in the air? 
        if (isGrounded == false)
        {
            //flip back or forward
            flipControl();

            //rotate control
            rotateControl();

            //allow the player to do tricks
            trickControls();
        }
        else
        {
            //allow the player to jump
            JumpControls();

            _rigid.angularVelocity = Vector3.zero;

        }

	}

    private void JumpControls()
    {
#if UNITY_XBOXONE

        if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonA) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                _rigid.AddForce(Vector3.up * jumpHeight);

                //Debug.Log("Jump");
            }
        }
    
#endif

#if UNITY_STANDALONE

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (isGrounded == true)
			{
				_rigid.AddForce(Vector3.up * jumpHeight);

				//Debug.Log("Jump");
			}
		}
#endif

	}


    public void baseTrickRight()
    {
        //base right trick
        _anim.SetTrigger("baseRight");
        _trickController.popPointsTimer("Horse Kick!", 1000, Color.green);
    }

    public void baseTrickLeft()
    {
        //base left trick
        _anim.SetTrigger("baseLeft");
        _trickController.popPointsTimer("Attack!", 2000, Color.yellow);
    }

    public void baseTrickUp()
    {
        //base up trick
        _anim.SetTrigger("baseUp");
        _trickController.popPointsTimer("Nose Up!", 2300, Color.yellow);
    }

    public void baseTrickDown()
    {
        //base down trick
        _anim.SetTrigger("baseDown");
        _trickController.popPointsTimer("Tail Wag!", 1000, Color.green);
    }


    private void trickControls()
    {

#if UNITY_XBOXONE

        if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonB) || Input.GetKeyDown(KeyCode.L))
        {
            baseTrickRight();
        }
        else if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonX) || Input.GetKeyDown(KeyCode.J))
        {
            baseTrickLeft();
        }
        else if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonY) || Input.GetKeyDown(KeyCode.I))
        {
            baseTrickUp();
        }
        else if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonA) || Input.GetKeyDown(KeyCode.K))
        {
            baseTrickDown();
        }

#endif

#if UNITY_STANDALONE

		if (Input.GetKeyDown(KeyCode.L))
		{
			baseTrickRight();
		}
		else if (Input.GetKeyDown(KeyCode.J))
		{
			baseTrickLeft();
		}
		else if (Input.GetKeyDown(KeyCode.I))
		{
			baseTrickUp();
		}
		else if (Input.GetKeyDown(KeyCode.K))
		{
			baseTrickDown();
		}

#endif

    }

    /// <summary>
    /// Control the board to rotate
    /// </summary>
    private void rotateControl()
    {
        //rotate left or right
        if (hAxis > deadZone)
        {
            //rotate right
            _rigid.AddTorque(transform.up * torque);
        }
        else if (hAxis < -deadZone)
        {
            //rotate left
            _rigid.AddTorque(-transform.up * torque);
        }
        else
        {
            //stop rotating
            _rigid.angularVelocity = Vector3.zero;

        }
    }

    /// <summary>
    /// Control the board to flip forward or backward
    /// </summary>
    private void flipControl()
    {
        if (vAxis > deadZone)
        {
            //rotate forward
            _rigid.AddTorque(transform.forward * flippingTorque);
        }
        else if (vAxis < -deadZone)
        {
            //rotate back
            _rigid.AddTorque(-transform.forward * flippingTorque);
        }
        else
        {
            //stop rotating
            _rigid.angularVelocity = Vector3.zero;

        }
    }
}
