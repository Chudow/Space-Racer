using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {

    Text speed;
    Rigidbody rb;

    int spd;
    float color;

	// Use this for initialization
	void Start () {
        speed = FindObjectOfType<Text>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        spd = (int) Mathf.Round(transform.InverseTransformDirection(rb.velocity).y * 10);
        color = Mathf.Pow(transform.InverseTransformDirection(rb.velocity).y, 0.15f) - 1;

        if (speed != null)
        {
            speed.color = new Color(color, 0, 0);
            speed.text = "Speed: " + spd;
        }
        else Debug.Log("speed = null?!");
    }
}
