using Scoring;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetUpBoard : MonoBehaviour
{

    public GameObject _puck;
    public GameObject _scoreBoard;
    public GameObject _countdown;
    public GameObject _player;
    public GameObject _AIplayer;

    private GameManager gameManager;
    


    private void Awake()
    {
        gameManager = GameManager.instance;
        _puck = gameManager.puck;
        _scoreBoard = gameManager.scoreBoard;
        _countdown = gameManager.countdown;
        _player = gameManager.player;
        _AIplayer = gameManager.AIplayer;

        StartCoroutine(GameSetUp());
    }

    IEnumerator GameSetUp()
    {
        GameObject player = Instantiate(_player, new Vector3 (-6,0), Quaternion.identity);
        GameObject AIplayer= Instantiate(_AIplayer, new Vector3(6, 0), Quaternion.identity);
        GameObject scoreBoard= Instantiate(_scoreBoard);
        GameObject countdown= Instantiate(_countdown, new Vector3 (0,0), Quaternion .identity);

        scoreBoard.transform.SetParent(transform, true);
        countdown.transform.SetParent(transform, true);


        //player.GetComponent<MoveWithMouse>().mouseActive = false;
        AIplayer.GetComponent<AIController>().AIactive = false;

        yield return Ready();
        yield return countingDown();
        Destroy(countdown);
        GameObject puck= Instantiate(_puck, new Vector3(0, 0, 0), Quaternion.identity);

        //player.GetComponent<MoveWithMouse>().mouseActive = true;
        AIplayer.GetComponent<AIController>().AIactive = true;
    }

    IEnumerator countingDown()
    {
        
        for (int i = 3; i > 0; i--)
        {
            TextMeshProUGUI pText = GameObject.Find("Starting In:").GetComponent<TextMeshProUGUI>();
            pText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

    }

    IEnumerator Ready()
    {
        TextMeshProUGUI pText = GameObject.Find("Counter").GetComponent<TextMeshProUGUI>();
        pText.text = "Ready?";
        yield return new WaitForSeconds(1);
        pText.text = "";
    }
}


