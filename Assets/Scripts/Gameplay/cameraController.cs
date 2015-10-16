using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    public GameObject m_Board;
    public Vector3 m_Offset;

	// Use this for initialization
	void Start () {

        m_Board = GameObject.Find("Board");
        if (m_Board == null)
        {
            Debug.Log("<color=red>Couldn't find Board in Hierarchy</color>");
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(m_Board.transform.position.x + m_Offset.x,
                                        m_Board.transform.position.y + m_Offset.y,
                                        m_Board.transform.position.z + m_Offset.z);

	}
}
