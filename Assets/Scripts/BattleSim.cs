using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class BattleSim : MonoBehaviour {

    public SwitchCameraPosition SwitchCameraScript;
    public List<GameObject> Ships;

    public void StartBattle()
    {
        //enable the scripts for the battle
        SwitchCameraScript.enabled = true;
        foreach(var ship in Ships)
        {
            var boidScript = ship.GetComponent<Boid>();
            boidScript.enabled = true;

            var shipScript = ship.GetComponent<Ship>();
            shipScript.enabled = true;
        }
    }
}
