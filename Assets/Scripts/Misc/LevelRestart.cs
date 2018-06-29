using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelRestart : MonoBehaviour {

    GameObject player;
    Finish finish;
    FallDownText fallDownText;

    public int killField;
    [HideInInspector]
    public bool fellDown = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        fallDownText = FindObjectOfType<FallDownText>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            if (player == null && !finish.finished)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }

        if (player != null)
        {
            if (player.transform.position.y < killField)
            {
                player.GetComponent<Move>().enabled = false;
                player.GetComponent<Boost>().enabled = false;
                fellDown = true;
                player = null;
                fallDownText.FallDown();
            }

        }
	}
}
