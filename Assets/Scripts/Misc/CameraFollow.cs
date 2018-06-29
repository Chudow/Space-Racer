using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 posDiff = new Vector3(0, -5, -10); //Vart i relation till spelaren kameran ska vara
    GameObject player;
    Transform lookAtMe;
    LevelRestart levelRestart;

    float camSpeed = 0.2f;

    Vector3 v = Vector3.zero;

    // Use this for initialization
    void Start () {
        levelRestart = GameObject.FindGameObjectWithTag("Holder of scripts").GetComponent<LevelRestart>();
        player = GameObject.FindGameObjectWithTag("Player");
        lookAtMe = player.transform.GetChild(0);
        transform.position = player.transform.position - posDiff;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position - posDiff, maxDistDelta);
        if (player != null)
        {
            if (!levelRestart.fellDown)
            {
                transform.position = Vector3.SmoothDamp(transform.position, player.transform.position - posDiff, ref v, camSpeed);
            }
            transform.LookAt(lookAtMe);
        }
    }
}
