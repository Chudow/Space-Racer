using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

    public string scene;

    [HideInInspector]
    public bool finished = false;

    void Start()
    {
        if (scene == "")
        {
            scene = SceneManager.GetActiveScene().name;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && finished)
        {
            SceneManager.LoadScene(scene);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            finished = true;
            Debug.Log("Finish!");
            Destroy(other.gameObject);
        }
    }
}
