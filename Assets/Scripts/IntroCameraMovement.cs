using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCameraMovement : MonoBehaviour {

    public Transform StartTransform;
    public Transform EndTransform;
    public IntroScriptDisplay ScriptToBeDisplayed;
    public Text SkipIntroText;
    public BattleSim BattleSimScript;
    float time = 0.0f;
    
	void Start ()
    {
        this.transform.position = StartTransform.position;
        this.transform.rotation = StartTransform.rotation;
	}
	
	void Update ()
    {
        time += Time.deltaTime / ScriptToBeDisplayed.TotalTime;
        transform.position = Vector3.Lerp(StartTransform.position, EndTransform.position, time);
        transform.rotation = Quaternion.Lerp(StartTransform.rotation, EndTransform.rotation, time);

        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.position = EndTransform.position;
            this.transform.rotation = EndTransform.rotation;
            Debug.Log("Intro skipped");
        }

        if(this.transform.position == EndTransform.position)
        {
            ScriptToBeDisplayed.enabled = false;
            ScriptToBeDisplayed.GetComponent<Text>().enabled = false;
            SkipIntroText.enabled = false;
            this.enabled = false;
            BattleSimScript.StartBattle();
        }

    }
}
