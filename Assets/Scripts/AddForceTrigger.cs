using UnityEngine;
using System.Collections;

public class AddForceTrigger : MonoBehaviour {

    public float forceToAdd = 300.0f;

    // Use this for initialization
    void Start()
    {

        this.GetComponent<BoxCollider>().isTrigger = true;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Board")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * forceToAdd);
        }
    }
}
