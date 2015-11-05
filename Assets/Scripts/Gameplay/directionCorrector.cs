/*Created by Chris Figueroa
 * 
 * This is used so that the Horse Player always stays in one line going down the hill.
 * This helps us from drifting left or right. 
*/


using UnityEngine;
using System.Collections;

public class directionCorrector : MonoBehaviour {

    Vector3 startPOS;

	// Use this for initialization
	void Start () {

        getPosition();
	
	}

    void getPosition()
    {
        startPOS = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.z != 0)
        {
            Vector3 _newpos = new Vector3(transform.position.x, transform.position.y, startPOS.z);
            transform.position = _newpos;
        }

	}
}
