using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingCameraLight : MonoBehaviour {

    public float TimeBetweenBlinks = 1;
    float elapsed = 0.0f;
    Image blinkingLightImage;
    

    void Start ()
    {
        blinkingLightImage = GetComponent<Image>();
	}
	
	void Update ()
    {
        if (elapsed > TimeBetweenBlinks)
        {
            blinkingLightImage.enabled = !blinkingLightImage.enabled;
            elapsed = 0.0f;
        }

        elapsed += Time.deltaTime;
    }
}
