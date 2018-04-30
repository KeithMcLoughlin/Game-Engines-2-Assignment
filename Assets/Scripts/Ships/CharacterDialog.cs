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
        RelatedTeammate.OnDeath += CharacterReaction;
    }

    void CharacterReaction()
    {
        if (!CurrentShip.dead)
        {
            UIDialogObject.DisplayDialog(Dialog);
            CurrentShip.Damage += DamageIncrease;
            CurrentShip.Speed *= SpeedMultplier;
        }
    }
}
