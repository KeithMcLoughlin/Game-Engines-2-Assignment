using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraPosition : MonoBehaviour {

    public List<Transform> CameraPositions;
    float elapsed = 0.0f;
    float timeBetweenSwitches = 5;
    int currentCameraPosition = 0;
	
	void Update ()
    {
        if(elapsed > timeBetweenSwitches)
        {
            currentCameraPosition++;
            var cameraIndex = currentCameraPosition % CameraPositions.Count;
            SetCameraTransform(CameraPositions[cameraIndex]);
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
