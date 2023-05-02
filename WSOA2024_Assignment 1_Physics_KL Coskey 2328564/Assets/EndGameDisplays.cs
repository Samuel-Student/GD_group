using Scoring;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameDisplays : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameEnds gameEnds;
    //public Goal goal;
    //private GameObject _scoreBoard;
    void Awake()
    {
        string theWinnertx = GameObject.Find("The Winner").GetComponent<TextMeshProUGUI>().text;
        GameObject.Find("P_Score").GetComponent<TextMeshProUGUI>().text = new string(GameManager.PlayerScore.ToString());
        GameObject.Find("CPU_Score").GetComponent<TextMeshProUGUI>().text = new string(GameManager.ComputerScore.ToString());

        if (GameManager.PlayerScore> GameManager.ComputerScore)
        {
            GameObject.Find("The Winner").GetComponent<TextMeshProUGUI>().text = new string(theWinnertx + " Player!");
        }
        else if ( GameManager.ComputerScore >GameManager.PlayerScore)
        {
            GameObject.Find("The Winner").GetComponent<TextMeshProUGUI>().text = new string(theWinnertx + " Computer!");
        }
        else
        {
            GameObject.Find("The Winner").GetComponent<TextMeshProUGUI>().text = new string( "It's a draw!");
        }
    }

    
    
}
