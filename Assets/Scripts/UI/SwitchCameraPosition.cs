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
        if(Input.GetKeyDown(KeyCode.RightArrow) || elapsed > timeBetweenSwitches)
        {
            currentCameraPosition++;
            ChangeCamera(currentCameraPosition);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentCameraPosition--;
            ChangeCamera(currentCameraPosition);
        }

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
