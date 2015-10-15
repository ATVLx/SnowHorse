/*Created by Chris Figueroa
 * 
 * This is used so that the Horse Player always stays in one line going down the hill.
 * This helps us from drifting left or right. 
*/


using UnityEngine;
using System.Collections;

public class directionCorrector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.z != 0)
        {
            Vector3 _newpos = new Vector3(transform.position.x, transform.position.y, 0);
            transform.position = _newpos;
        }

	}
}
