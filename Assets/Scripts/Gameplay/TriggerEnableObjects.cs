using UnityEngine;
using System.Collections;

public class TriggerEnableObjects : MonoBehaviour {

    public GameObject[] m_GameObjectsToEnable;
    [Range(0.5f, 10.0f)]
    public float minRange = 0.5f;
    [Range(0.5f, 10.0f)]
    public float maxRange = 1.8f;

	// Use this for initialization
	void Start () {

        this.GetComponent<BoxCollider>().isTrigger = true;

	}

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < m_GameObjectsToEnable.Length; i++)
        {
            m_GameObjectsToEnable[i].SetActive(true);
            Destroy(m_GameObjectsToEnable[i], Random.Range(minRange, maxRange));
        }
    }
}
