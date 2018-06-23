using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float accelSpeed = 20; //Farten när man fortsätter gasa
    public float strafeSpeed = 5; //Hur hårt man strafear
    public float turnSpeed = 5; //Hur hårt man svänger
    public float maxSpeed = 20; //Max fart för att gasa
    public float maxTurn = 20; //Hur starkt man kan svänga max, Quaternion.Angle så inte riktigt i grader
    [Range(0, 1)]
    public float turnBackSpeed = 0.3f; //Hur hårt man svänger tillbaka till default vinkel

    Quaternion defaultHeading;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        defaultHeading = transform.rotation;
	}
	
	void FixedUpdate()
    {
        float rotDiff = Quaternion.Angle(defaultHeading, transform.rotation);

        if (Input.GetAxis("Vertical") > 0 && transform.InverseTransformDirection(rb.velocity).y <= maxSpeed)
        {
            rb.AddRelativeForce(Vector3.up * accelSpeed, ForceMode.Acceleration);
        }

        //if (Input.GetAxis("Strafe") != 0)
        //{
            rb.AddRelativeForce(Vector3.left * strafeSpeed * Input.GetAxis("Horizontal"));
        //}

        if (Input.GetAxis("Mouse X") != 0 && rotDiff < maxTurn)
        {
            
                float turn = Input.GetAxis("Mouse X") * turnSpeed;
                rb.AddRelativeTorque(0, 0, turn);
            
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, defaultHeading, turnBackSpeed * Time.deltaTime);
        }
       
    }
}
