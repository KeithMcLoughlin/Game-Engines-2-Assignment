using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class SwitchCameraPosition : MonoBehaviour {

    public List<Transform> CameraPositions;
    public GameObject CameraNumberDisplayObject;
    public GameObject CameraBlinkingLightObject;
    Text CameraNumberDisplayText;
    float elapsed = 0.0f;
    float timeBetweenSwitches = 5;
    int currentCameraPosition = 0;
    int currentCameraIndex = 0;
	
    void Start()
    {
        CameraNumberDisplayObject.SetActive(true);
        CameraBlinkingLightObject.SetActive(true);
        CameraNumberDisplayText = CameraNumberDisplayObject.GetComponent<Text>();
        CameraNumberDisplayText.text = "Cam 1";
    }

	void Update ()
    {
        //switch to next camera if right arrow pressed or an amount of time has passed
        if(Input.GetKeyDown(KeyCode.RightArrow) || elapsed > timeBetweenSwitches)
        {
            currentCameraPosition++;
            ChangeCamera(currentCameraPosition);
        }

        //switch to previous camera if left key pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentCameraPosition--;
            ChangeCamera(currentCameraPosition);
        }

        //if camera is available, switch to it
        if(CameraPositions[currentCameraIndex] != null)
            SetCameraTransform(CameraPositions[currentCameraIndex]);

        elapsed += Time.deltaTime;
    }

    void SetCameraTransform(Transform newTransform)
    {
        this.transform.position = newTransform.position;
        this.transform.rotation = newTransform.rotation;
    }

    void ChangeCamera(int cameraNumber)
    {
        var cameraIndex = cameraNumber % CameraPositions.Count;
        if (cameraIndex < 0)
            cameraIndex += CameraPositions.Count;

        //if camera not available remove it
        if (CameraPositions[cameraIndex] == null)
        {
            CameraPositions.Remove(CameraPositions[cameraIndex]);
            cameraIndex = cameraIndex % CameraPositions.Count;
        }
        
        CameraNumberDisplayText.text = "Cam " + (cameraIndex + 1);
        currentCameraIndex = cameraIndex;
        elapsed = 0.0f;
    }
}
