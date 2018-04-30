using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CharacterDialog : MonoBehaviour {

    public Ship RelatedTeammate; 
    public Ship CurrentShip;
    public TextAsset Dialog;
    public CharacterDialogBox UIDialogObject;
    public int DamageIncrease = 0;
    public float SpeedMultplier = 0.0f;

    void Start ()
    {
        //if this teammate dies, run this dialog
        RelatedTeammate.OnDeath += CharacterReaction;
    }

    void CharacterReaction()
    {
        //only run dialog if this character is still alive
        if (!CurrentShip.dead)
        {
            UIDialogObject.DisplayDialog(Dialog);
            //apply buffs
            CurrentShip.Damage += DamageIncrease;
            CurrentShip.Speed *= SpeedMultplier;
        }
    }
}
