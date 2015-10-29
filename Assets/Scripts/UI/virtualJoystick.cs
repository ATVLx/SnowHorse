using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class virtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image joystickImg;
    private Image backgroundImg;
    private Vector3 inputVector;
    private BoardController m_Board;

	// Use this for initialization
	void Start () {

        //get the board controller
        m_Board = GameObject.Find("Board").GetComponent<BoardController>();

        //get the joystick images
        backgroundImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
	
	}


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (Input.touchCount == 1)
        {

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImg.rectTransform,
                                                                       eventData.position,
                                                                       eventData.pressEventCamera,
                                                                       out pos))
            {

                pos.x = (pos.x / backgroundImg.rectTransform.sizeDelta.x);
                pos.y = (pos.y / backgroundImg.rectTransform.sizeDelta.y);
                //get the input in a normal value like a joystick. example -1 to 1 on the horizontal
                inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
                inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

                //move joystick image around
                joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (backgroundImg.rectTransform.sizeDelta.x / 4), inputVector.z * (backgroundImg.rectTransform.sizeDelta.y / 4));

                //inputVector.x and inputVector.z is X & Y

                if (inputVector.x > 0.9f || inputVector.x < -0.9f)
                {
                    m_Board.hAxis = inputVector.x;
                }

                if (inputVector.z > 0.9f || inputVector.z < -0.9f)
                {
                    m_Board.vAxis = inputVector.z;
                }

                Debug.Log(inputVector.ToString());
            }
        }
                                                                   
    }

    public void trick1BaseDownbutton()
    {

        m_Board.baseTrickDown();
    }

    public void trick2BaseUpbutton()
    {

        m_Board.baseTrickUp();
    }

    public void trick3BaseRightbutton()
    {

        m_Board.baseTrickRight();
    }

    public void trick4BaseLeftbutton()
    {

        m_Board.baseTrickLeft();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        m_Board.vAxis = 0.0f;
        m_Board.hAxis = 0.0f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //OnDrag(eventData);

    }
}
