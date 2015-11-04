using UnityEngine;
using System.Collections;

public class TriggerEnableObjects : MonoBehaviour {

    public GameObject[] m_GameObjectsToEnable;

	// Use this for initialization
	void Start () {

        this.GetComponent<BoxCollider>().isTrigger = true;

	}

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < m_GameObjectsToEnable.Length; i++)
        {
            m_GameObjectsToEnable[i].SetActive(true);
            Destroy(m_GameObjectsToEnable[i], Random.Range(0.5f, 1.8f));
        }
    }
}
