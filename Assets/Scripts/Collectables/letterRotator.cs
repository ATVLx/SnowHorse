using UnityEngine;
using System.Collections;

public class letterRotator : MonoBehaviour {

	private float rotationSpeed = 80.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	
	}

	void OnTriggerEnter(Collider other) 
	{
		Debug.Log("Collected Letter");
		Destroy(this.gameObject);
	}

}
