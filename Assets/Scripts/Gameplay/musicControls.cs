using UnityEngine;
using System.Collections;

public class musicControls : MonoBehaviour {

    public AudioClip[] m_SongList;
    public int currentPlayingTrack = 0;
    private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {

        m_AudioSource = GetComponent<AudioSource>();
        
        DontDestroyOnLoad(this.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {

        if (m_AudioSource.isPlaying == false)
        {
            m_AudioSource.PlayOneShot(m_SongList[currentPlayingTrack]);
            currentPlayingTrack++;
            Debug.Log("Changing song");
        }

	}
}
