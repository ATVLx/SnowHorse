using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

    [Header("Input Settings")]
    private float hAxis, vAxis, rightHAxis, rightVAxis;
    private Rigidbody _rigid;
    public float torque = 150.0f;
    private Transform startPosition;

    [Header("Trick Settings")]
    public trickPointController _trickController;
    public bool hasGivenRailPoints = false;

    [Header("Raycast Settings")]
    public float rayDistance = 5.0f;

    [Header("Air Settings")]
    public bool isGrounded = false;

    [Header("Animation Settings")]
    public Animator _anim;

	// Use this for initialization
	void Start () {

        //store the start position
        startPosition = transform;
        //get the rigidbody
        _rigid = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        rightHAxis = Input.GetAxis("Horizontal2");
        rightVAxis = Input.GetAxis("Vertical2");


        RaycastHit hit;
        Debug.DrawRay(transform.position, -Vector3.up * rayDistance, Color.green);
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, rayDistance))
        {
            if (hit.transform.tag == "Rail")
            {
                isGrounded = false;
                if (hasGivenRailPoints == false)
                {
                    //give rail points
                    hasGivenRailPoints = true;
                    _trickController.popPointsTimer("Hay Slide", 3400);
                }
                
            }
            else
            {
                _trickController.endTrickTimer();
                isGrounded = true;
                //give back rail point privledges since we have landed
                hasGivenRailPoints = false;
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
            //move on the ground code goes here
            //groundMovement();

        }

	}

    private void JumpControls()
    {
        if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonA) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                _rigid.AddForce(Vector3.up * 800);
                //Debug.Log("Angle: " + transform.eulerAngles.ToString());
                Debug.Log("Jump");
            }
        }
    }

    private void trickControls()
    {

        if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonB))
        {
            //base right trick
            _anim.SetTrigger("baseRight");
            _trickController.popPointsTimer("Horse Kick!", 1000);
        }
        else if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonX))
        {
            //base left trick
            _anim.SetTrigger("baseLeft");
            _trickController.popPointsTimer("Attack!", 2000);
        }
        else if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonY))
        {
            //base up trick
            _anim.SetTrigger("baseUp");
            _trickController.popPointsTimer("Nose Up!", 2300);
        }
        else if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonA))
        {
            //base down trick
            _anim.SetTrigger("baseDown");
            _trickController.popPointsTimer("Tail Wag!", 1000);
        }

    }

    /// <summary>
    /// the ground control 
    /// </summary>
    private void groundMovement()
    {
        //rotate left or right
        if (hAxis > 0.4f)
        {
            //rotate right
            _rigid.AddForce(Vector3.forward * 5);
        }
        else if (hAxis < -0.4f)
        {
            //rotate left
            _rigid.AddForce(-Vector3.forward * 5);
        }
        else
        {
            //stop rotating
            //_rigid.velocity = Vector3.zero;

        }
    }

    /// <summary>
    /// Control the board to rotate
    /// </summary>
    private void rotateControl()
    {
        //rotate left or right
        if (hAxis > 0.4f)
        {
            //rotate right
            _rigid.AddTorque(transform.up * torque * hAxis);
        }
        else if (hAxis < -0.4f)
        {
            //rotate left
            _rigid.AddTorque(-transform.up * -torque * hAxis);
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
        if (vAxis > 0.4f)
        {
            //rotate right
            _rigid.AddTorque(transform.forward * torque * vAxis);
        }
        else if (vAxis < -0.4f)
        {
            //rotate left
            _rigid.AddTorque(-transform.forward * -torque * vAxis);
        }
        else
        {
            //stop rotating
            _rigid.angularVelocity = Vector3.zero;

        }
    }
}
