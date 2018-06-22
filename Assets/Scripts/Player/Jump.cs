using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public float groundProximity = 1f;
    public float jumpPower = 65f;
    public int jumpCD = 30;

    int lastJump = 0;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, groundProximity) && Input.GetButtonDown("Jump") && lastJump <= 0)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            lastJump = jumpCD;
        }

        lastJump--;
    }
}
