using UnityEngine;
using System.Collections;

public class CrowdAudioControl : MonoBehaviour {

    [Header("Airhorn")]
    public AudioSource m_AudioAirHornSource;

    [Header("Celebration Noise")]
    public AudioSource m_AudioCelebrationNoiseSource;

    [Header("Background Stadium Noise")]
    public AudioSource m_AudioStadiumNoiseSource;

    [Header("Airhorn")]
    public AudioClip m_Airhorn;
    public AudioClip m_CelebrationNoise;
    public AudioClip m_StadiumNoise;


	// Use this for initialization
	void Start () {

        m_AudioStadiumNoiseSource.clip = m_StadiumNoise;
        m_AudioStadiumNoiseSource.loop = true;
        m_AudioStadiumNoiseSource.volume = 0.8f;
        m_AudioStadiumNoiseSource.Play();
	
	}

    public void playAirHorn()
    {

        m_AudioAirHornSource.clip = m_Airhorn;
        m_AudioAirHornSource.volume = 0.8f;
        m_AudioAirHornSource.Play();

    }
	
	


}
