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

        if (Input.GetKeyDown(KeyCode.M))
        {

            if (m_AudioSource.volume > 0)
            {
                m_AudioSource.volume = 0.0f;
            }
            else
            {
                m_AudioSource.volume = 1.0f;
            }

        }

        if (m_AudioSource.isPlaying == false)
        {
            m_AudioSource.PlayOneShot(m_SongList[currentPlayingTrack]);
            currentPlayingTrack++;
            Debug.Log("Changing song");
        }

#if UNITY_STANDALONE

        //standalone music changing goes here

#endif

#if UNITY_XBOXONE

        if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonDPadRight))
        {
            if (currentPlayingTrack != m_SongList.Length)
            {
                m_AudioSource.PlayOneShot(m_SongList[currentPlayingTrack]);
            }
        }
        else if (XboxOneInput.GetKeyDown(XboxOneKeyCode.Gamepad1ButtonDPadLeft))
        {
            if (currentPlayingTrack != 0)
            {
                m_AudioSource.PlayOneShot(m_SongList[currentPlayingTrack - 1]);
            }
        }

#endif


        

	}
}
