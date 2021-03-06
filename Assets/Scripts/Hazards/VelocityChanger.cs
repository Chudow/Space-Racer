﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityChanger : MonoBehaviour {
    
    public float speedChange;
    public bool show = true;

	void OnTriggerStay(Collider other)
    {
        Debug.Log(other.GetType());
        if (other.gameObject.tag == "Player")
        {
            if (other.attachedRigidbody)
            {
                if (other.GetType().Name == "MeshCollider")
                {
                    Vector3 vel = transform.InverseTransformDirection(other.attachedRigidbody.velocity);
                    if ((speedChange < 0 && other.attachedRigidbody.velocity.z < -0.01) || speedChange > 0)
                    {
                        other.attachedRigidbody.velocity = new Vector3(vel.x, vel.y, vel.z - speedChange); //other.attachedRigidbody.velocity += new Vector3(0, 0, speedChange);//other.attachedRigidbody.velocity.z * speedChange);
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        if (show)
        {
            BoxCollider box = GetComponent<BoxCollider>();

            Gizmos.color = new Color(1, 0, 1, 0.65f);
            Gizmos.DrawCube(transform.position, box.bounds.size);
        }
    }

}
