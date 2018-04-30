using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PersonalDialog : MonoBehaviour {
    
    public Ship CurrentShip;
    public TextAsset Dialog;
    public CharacterDialogBox UIDialogObject;

    void Start()
    {
        CurrentShip.OnDeath += CharacterReaction;
    }

    void CharacterReaction()
    {
        UIDialogObject.DisplayDialog(Dialog);
    }
}
