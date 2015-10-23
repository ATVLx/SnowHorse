using UnityEngine;
using System.Collections;

public class PathNodeResponse : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<BoxCollider>().isTrigger = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {
        transform.parent.GetComponent<FollowPath>().advancePath(other.gameObject);

    }

}
