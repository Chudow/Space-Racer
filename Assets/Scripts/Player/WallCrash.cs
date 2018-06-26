using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCrash : MonoBehaviour {

    public float crashSensitivity = 40;

	void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > crashSensitivity && collision.gameObject.tag == "Wall" && collision.contacts[0].thisCollider.GetType().Name == "BoxCollider")
        {
            Destroy(gameObject);
            Debug.Log("CRASH!");
        }
    }


}
