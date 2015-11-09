using UnityEngine;
using System.Collections;

public class velocityDetector : MonoBehaviour {

	private Rigidbody _rigid;
	[HideInInspector]
    public float m_velocityCap = 25.0f;

	// Use this for initialization
	void Start () {

		_rigid = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {



	
	}
}
