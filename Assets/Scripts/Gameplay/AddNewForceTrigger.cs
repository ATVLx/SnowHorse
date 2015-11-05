using UnityEngine;
using System.Collections;

public class AddNewForceTrigger : MonoBehaviour {

    public float forceToAdd = 300.0f;
    public bool destoryTriggerAfter = true;

    // Use this for initialization
    void Start()
    {

        this.GetComponent<BoxCollider>().isTrigger = true;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Board")
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0 , forceToAdd, 0);
            
            if (destoryTriggerAfter == true)
            {
                Debug.Log("Destoryed AddNewForceTrigger");
                Destroy(this.gameObject);
            }
        }
    }
}
