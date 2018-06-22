using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Vector3 posDiff;
    GameObject player;
    Transform lookAtMe;

    float camSpeed = 0.2f;

    Vector3 v = Vector3.zero;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        lookAtMe = player.transform.GetChild(0);
        posDiff = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position - posDiff, maxDistDelta);
        if (player != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position - posDiff, ref v, camSpeed);
            transform.LookAt(lookAtMe);
        }
    }
}
