/*Created by Chris Figueroa
 * 
 * This is the script used to rotate the camera around an object. 
 * Currently used in the title screen
 * 
*/

using UnityEngine;
using System.Collections;

public class rotateAroundObject : MonoBehaviour {

    public Transform objectToRotateAround;
    public Vector3 cameraOffSet;
    public float rotatingSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAround(objectToRotateAround.position, cameraOffSet, rotatingSpeed * Time.deltaTime);

	}
}
