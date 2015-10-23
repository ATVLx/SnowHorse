using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {

    //public List<GameObject> m_Nodes = new List<GameObject>();
    public float speed = 10;
    public Transform target;
    public Transform[] pathPoints;
    private int c = 1;



	// Use this for initialization
	void Start () {
	
	}

    public void advancePath(GameObject _target)
    {
        if (target == null)
        {
            target = _target.transform;
        }
        else
        {
            c++;
            Debug.Log("Advance along path");
        }

    }

	// Update is called once per frame
	void Update () {

        if (target != null)
        {
            target.GetComponent<Rigidbody>().MovePosition(pathPoints[c].transform.position + transform.forward);

        }
	
	}


}
