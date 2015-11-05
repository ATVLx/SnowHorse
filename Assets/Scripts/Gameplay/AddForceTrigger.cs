using UnityEngine;
using System.Collections;

public class AddForceTrigger : MonoBehaviour {

    public Vector3 forceToAdd = new Vector3(0, 300.0f, 0);

    // Use this for initialization
    void Start()
    {

        this.GetComponent<BoxCollider>().isTrigger = true;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Board")
        {
            other.GetComponent<Rigidbody>().AddForce(forceToAdd);
        }
    }
}
