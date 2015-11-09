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

            //stop the music
            GameObject _music = GameObject.Find("_Music");
            if (_music != null)
            {
                _music.GetComponent<musicControls>().musicStop();
                Debug.Log("Slowing Down Music");
            }

            //shake camera? 
            GameObject _cam = GameObject.Find("Main Camera");
            iTween.ShakePosition(_cam, new Vector3(0.1f, 0.1f, 0.1f), 0.3f);

            //slow down time
            Debug.Log("Slowing Down Time");
            Time.timeScale = 0.45f;

            Debug.Log("Hit");

            Invoke("restartLevel", 3.0f);

        }
    }

    private void restartLevel()
    {
        //set the time scale back to normal
        Time.timeScale = 1.0f;

        //load the level again 
        LoadNewLevelAsync.LoadLevelAsyncNow(Application.loadedLevelName);
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
