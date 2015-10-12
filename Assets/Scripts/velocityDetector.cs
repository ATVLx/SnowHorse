using UnityEngine;
using System.Collections;

public class velocityDetector : MonoBehaviour {

	private Rigidbody _rigid;
	public float m_velocityCap = 20.0f;

	// Use this for initialization
	void Start () {

		_rigid = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {

		//check if we are going to fast
		if(Mathf.Abs(_rigid.velocity.x) > m_velocityCap)
		{
			//slow down
			_rigid.velocity = new Vector3(-m_velocityCap, _rigid.velocity.y, _rigid.velocity.z);

		}

	
	}
}
