using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomToolTip : MonoBehaviour {

    [Header("List of Tooltips")]
    public string[] mTooltips;

    [Header("Tooltip Text Object")]
    public Text mToolTipText;


	// Use this for initialization
	void Start () {

        //generate a random number
        int _rand = Random.Range(0, mTooltips.Length);
        //display that random tool tip
        mToolTipText.text = mTooltips[_rand];

	}
	
}
