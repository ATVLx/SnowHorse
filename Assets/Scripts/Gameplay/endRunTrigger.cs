using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class endRunTrigger : MonoBehaviour {


	// Use this for initialization
	void Start () {

        this.GetComponent<BoxCollider>().isTrigger = true;

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Board")
        {
            Debug.Log("Hit");
            //stop the velocity of the player
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }



}
