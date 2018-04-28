using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCameraPosition : MonoBehaviour {

    public List<Transform> CameraPositions;
    public GameObject CameraNumberDisplayObject;
    public GameObject CameraBlinkingLightObject;
    Text CameraNumberDisplayText;
    float elapsed = 0.0f;
    float timeBetweenSwitches = 5;
    int currentCameraPosition = 0;
	
    void Start()
    {
        CameraNumberDisplayObject.SetActive(true);
        CameraBlinkingLightObject.SetActive(true);
        CameraNumberDisplayText = CameraNumberDisplayObject.GetComponent<Text>();
        CameraNumberDisplayText.text = "Cam 1";
    }

	void Update ()
    {
        if(elapsed > timeBetweenSwitches)
        {
            currentCameraPosition++;
            var cameraIndex = currentCameraPosition % CameraPositions.Count;
            SetCameraTransform(CameraPositions[cameraIndex]);
            CameraNumberDisplayText.text = "Cam " + (cameraIndex + 1);
            elapsed = 0.0f;
        }

        elapsed += Time.deltaTime;
    }

    void SetCameraTransform(Transform newTransform)
    {
        this.transform.position = newTransform.position;
        this.transform.rotation = newTransform.rotation;
    }
}
