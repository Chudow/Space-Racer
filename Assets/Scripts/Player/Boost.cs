using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {

    public float boostPower = 3.5f;
    int boosts = 0;
    Rigidbody rb;
    BoostGauge bg;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        bg = GameObject.FindGameObjectWithTag("BoostGauge").GetComponent<BoostGauge>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Boost"))
        {
            if (boosts > 0)
            {
                boosts--;
                bg.SetBoosts(boosts);
                rb.AddRelativeForce(Vector3.up * boostPower, ForceMode.Impulse);
            }
        }
	}

    public void IncreaseBoosts(int i)
    {
        boosts += i;
        bg.SetBoosts(boosts);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Boost")
    //    {
    //        boosts++;
    //        bg.SetBoosts(boosts);
    //    }
    //}
}
