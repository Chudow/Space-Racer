using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject[] keys;

    public Vector3 movement = Vector3.zero;
    public Vector3 rotation = Vector3.zero;

    public float movTime = 1;

    bool isEmpty = false;

    // Use this for initialization
    void Start () {
        rotation += transform.rotation.eulerAngles;
	}

    // Update is called once per frame
    void Update() {

        if (!isEmpty)
        {
            isEmpty = true;

            foreach (GameObject g in keys)
            {
                if (g != null) isEmpty = false;
            }

            if (isEmpty)
            {
                StartCoroutine(OpenDoorFunc());
            }
        }
	}


    IEnumerator OpenDoorFunc()
    {
        float progress = 0;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(rotation);

        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + movement;

        while (progress <= movTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
            transform.position = Vector3.Lerp(startPos, endPos, progress);

            progress += 0.01f;

            yield return new WaitForSeconds(0.01f);
        }

    }
}
