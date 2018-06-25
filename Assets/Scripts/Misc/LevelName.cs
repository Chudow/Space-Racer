using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelName : MonoBehaviour {

    Text t;
    [SerializeField]
    string levelName;

	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        t.text = levelName;

        StartCoroutine(FadeInNOut());
	}
	
	IEnumerator FadeInNOut()
    {
        float alpha = 0;
        Color color = t.color;

        while (alpha <= 1)
        {
            color = new Color(color.r, color.g, color.b, alpha);
            t.color = color;
            alpha += 0.05f;

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2);

        while (alpha > -0.5)
        {
            color = new Color(color.r, color.g, color.b, alpha);
            t.color = color;
            alpha -= 0.05f;

            yield return new WaitForSeconds(0.05f);
        }
    }


}
