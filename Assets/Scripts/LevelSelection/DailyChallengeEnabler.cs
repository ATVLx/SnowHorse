/*
 * Title: Daily Challenge Enabler
 * Used to check if the Game Manager allows for the daily challenge button to be displayed
 */ 

using UnityEngine;
using System.Collections;

public class DailyChallengeEnabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		if(GameManager.Instance.canDoDailyChallenge == false)
		{
			this.gameObject.SetActive(false);
		}

	}
	

}
