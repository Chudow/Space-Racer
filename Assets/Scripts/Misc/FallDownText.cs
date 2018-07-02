using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallDownText : MonoBehaviour
{
    Text t;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<Text>();
    }

    public void FallDown()
    {
        int r = Random.Range(0, 5);

        switch(r)
        {
            case 0:
                t.text = "Goodbye";
                break;
            case 1:
                t.text = "It's a long way down";
                break;
            case 2:
                t.text = "Be more careful next time";
                break;
            case 3:
                t.text = "You seem to have fallen off";
                break;
            case 4:
                t.text = "Fall flat into the deep ravine";
                break;
            default:
                break;
        }

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
