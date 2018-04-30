using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScriptDisplay : MonoBehaviour {

    public TextAsset Intro;
    public float TimePerLine;
    public float TimePerFade;
    public float TotalTime;

    // Use this for initialization
	void Start ()
    {
        Text displayText = GetComponent<Text>();
        var introLines = Intro.text.Split(new string[] { "\r\n\r\n" }, System.StringSplitOptions.None);

        //calculate time it will take to show intro
        TotalTime = introLines.Length * (TimePerLine + TimePerFade * 3);

        //start showing intro
        StartCoroutine(IntroText(introLines, displayText, TimePerLine, TimePerFade));
    }

    public IEnumerator IntroText(string[] script, Text screenComponent, float timePerLine, float timeToFade)
    {
        foreach(var line in script)
        {
            screenComponent.text = line;
            StartCoroutine(FadeTextInAndOut(timeToFade, timePerLine, screenComponent));
            yield return new WaitForSeconds(timePerLine + (timeToFade * 3));
        }
    }

    public IEnumerator FadeTextInAndOut(float timeToFade, float totalTimeOnScreenAfterFade, Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / timeToFade));
            yield return null;
        }

        yield return new WaitForSeconds(totalTimeOnScreenAfterFade);

        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / timeToFade));
            yield return null;
        }
    }
}
