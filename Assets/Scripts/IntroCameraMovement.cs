using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCameraMovement : MonoBehaviour {

    public Transform StartTransform;
    public Transform EndTransform;
    public IntroScriptDisplay ScriptToBeDisplayed;
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

        //todo if space pressed move straight to end
        //todo run start battle
    }
}
