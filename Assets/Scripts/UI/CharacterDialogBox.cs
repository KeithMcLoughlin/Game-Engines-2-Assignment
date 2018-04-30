using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDialogBox : MonoBehaviour {

    public Text DialogTextObject;
    public GameObject DialogBoxImage;

    public void DisplayDialog(TextAsset dialog)
    {
        //display the dialog box
        DialogTextObject.enabled = true;
        DialogBoxImage.SetActive(true);

        //display the text
        DialogTextObject.text = dialog.text;

        //close it after 5 seconds
        Invoke("CloseDialogBox", 5);
    }

    private void CloseDialogBox()
    {
        DialogTextObject.enabled = false;
        DialogBoxImage.SetActive(false);
    }
}
