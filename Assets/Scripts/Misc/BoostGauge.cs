using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostGauge : MonoBehaviour {

    Text t;

	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        t.text = "Boosts: 0";
	}
	
	public void SetBoosts(int i)
    {
        t.text = "Boosts: " + i;
    }
}
