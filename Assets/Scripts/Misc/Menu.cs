using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    Rigidbody[] rb;
    bool started = false;

	// Use this for initialization
	void Start () {
        rb = GetComponentsInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
        {
            if (!started)
            {
                started = true;
                StartCoroutine(Mayhem());
            }
        }
	}

    IEnumerator Mayhem()
    {
        foreach (Rigidbody body in rb)
        {
            body.isKinematic = false;
            body.useGravity = true;
        }

        yield return new WaitForSecondsRealtime(3);

        SceneManager.LoadScene("level_001");
    }
}
