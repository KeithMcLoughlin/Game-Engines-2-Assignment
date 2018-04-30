﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDialogBox : MonoBehaviour {

    public Text DialogTextObject;
    public GameObject DialogBoxImage;

    public void DisplayDialog(TextAsset dialog)
    {
        DialogTextObject.enabled = true;
        DialogBoxImage.SetActive(true);

        DialogTextObject.text = dialog.text;

        Invoke("CloseDialogBox", 5);
    }

    private void CloseDialogBox()
    {
        DialogTextObject.enabled = false;
        DialogBoxImage.SetActive(false);
    }
}