using UnityEngine;
using System.Collections;

public class horseMeshColliderCheck : MonoBehaviour {

    //the trigger
    private BoxCollider m_Collider;

    [Header("Ragdoll Settings")]
    public GameObject m_HorseRagdoll;
    public cameraController m_Camera;

	// Use this for initialization
	void Start () {

        m_Camera = GameObject.Find("Main Camera").GetComponent<cameraController>();

        m_Collider = GetComponent<BoxCollider>();
        m_Collider.isTrigger = true;

	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ridable" || other.tag == "Rail")
        {
            //instantiate a new ragdoll
            createRagdoll();
            //disable the parent
            transform.parent.gameObject.SetActive(false);

            Debug.Log("Hit");
        }
    }

    private void createRagdoll()
    {
        //create a ragdoll horse
        GameObject _newHorse;
        _newHorse = Instantiate(m_HorseRagdoll, transform.position, transform.rotation) as GameObject;
        _newHorse.name = "Horse Ragdoll";

        //set the new camera object to follow
        m_Camera.m_Board = _newHorse;

    }

}
