using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class VictoryDisplay : MonoBehaviour {

    public List<Ship> HumanShips;
    public List<Ship> VasikShips;
    public Text EndGameDisplayText;
    int humanDeathCount = 0;
    int vasikDeathCount = 0;
    
	void Start ()
    {
		foreach(var ship in HumanShips)
        {
            ship.OnDeath += IncrementHumanDeathCounter;
        }

        foreach (var ship in VasikShips)
        {
            ship.OnDeath += IncrementVasikDeathCounter;
        }
    }

    void IncrementHumanDeathCounter()
    {
        humanDeathCount++;
        if(humanDeathCount >= HumanShips.Count)
        {
            DisplayEndGameMessage("Defeat\n\nVasiks Win");
        }
    }

    void IncrementVasikDeathCounter()
    {
        vasikDeathCount++;
        if (vasikDeathCount >= VasikShips.Count)
        {
            DisplayEndGameMessage("Victory\n\nHumans Win");
        }
    }

    void DisplayEndGameMessage(string text)
    {
        EndGameDisplayText.enabled = true;
        EndGameDisplayText.text = text;
    }
}
