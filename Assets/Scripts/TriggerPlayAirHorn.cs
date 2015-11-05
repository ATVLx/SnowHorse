using UnityEngine;
using System.Collections;

public class TriggerPlayAirHorn : MonoBehaviour {

    public CrowdAudioControl m_CrowdAudioControl;

    // Use this for initialization
    void Start()
    {

        this.GetComponent<BoxCollider>().isTrigger = true;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Board")
        {
            m_CrowdAudioControl.playAirHorn();
            //Debug.Log("Call Airhorn sound");
        }
    }
}
