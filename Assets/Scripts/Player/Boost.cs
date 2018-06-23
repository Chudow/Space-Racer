using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {

    public float boostPower = 3.5f;
    int boosts = 0;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Boost"))
        {
            if (boosts > 0)
            {
                boosts--;
                rb.AddRelativeForce(Vector3.up * boostPower, ForceMode.Impulse);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boost")
            boosts++;
    }
}
