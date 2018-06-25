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
        speed = GetComponent<Text>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rb != null)
        {
            spd = (int)Mathf.Round(-rb.velocity.z * 10); //transform.InverseTransformDirection(rb.velocity).y
            color = Mathf.Pow(-rb.velocity.z, 0.15f) - 1;

            if (speed != null)
            {
                speed.color = new Color(color, 0, 0);
                speed.text = "Speed: " + spd;
            }
            else Debug.Log("speed = null?!");
        }
    }
}
