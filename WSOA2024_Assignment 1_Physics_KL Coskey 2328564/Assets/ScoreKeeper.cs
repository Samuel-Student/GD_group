using TMPro;
using UnityEngine;

namespace Scoring
{
    public class ScoreKeeper
    {
        private int _playerScore;
        private int _computerScore;
        
        public void p_playerScored(int p_Point)
        {
            _playerScore = GameManager.PlayerScore;
            Debug.Log("Point to Player");
            _playerScore = _playerScore + p_Point;
            GameManager.PlayerScore = _playerScore;
            GameObject.Find("P_Score").GetComponent<TextMeshProUGUI>().text = new string(_playerScore.ToString());
        }

        public void p_computerScored(int c_Point)
        {
            _computerScore = GameManager.ComputerScore;
            Debug.Log("Point to AI");
            _computerScore = _computerScore + c_Point;
            GameManager.ComputerScore = _computerScore;
            GameObject.Find("CPU_Score").GetComponent<TextMeshProUGUI>().text = new string(_computerScore.ToString());

        }

    }

}
