using Scoring;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LoadAssetPaths assetPaths;
    public ScoreKeeper Keeper;
    //public Goal goal;

    public static GameManager instance;

    
    public Turns t_state;



    public GameObject puck;
    public GameObject scoreBoard;
    public GameObject countdown;
    public GameObject player;
    public GameObject AIplayer;
    

    public static int PlayerScore;
    public static int ComputerScore;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);

        assetPaths = new LoadAssetPaths();
        assetPaths.Start();
        Keeper = new ScoreKeeper();
        //goal = new Goal();

        puck = assetPaths.puck;
        scoreBoard = assetPaths.scoreBoard;
        countdown = assetPaths.countdown;
        player = assetPaths.player;
        AIplayer = assetPaths.AIplayer;
        

        PlayerScore = 0;
        ComputerScore =0;

        UpdateTurnState(GameManager.Turns.empty);

    }
    

    public void UpdateTurnState(Turns nextTurn)
    {
        t_state = nextTurn;
        switch (t_state)
        {
            case Turns.empty: Debug.Log("E:No one has hit the ball yet");
                break;
            case Turns.t_Player: Debug.Log("P:It is now the player's turn");
                break;
            case Turns.t_Computer: Debug.Log("C:It is now the computer's turn");
                break;
            case Turns.penaltyPlayer:
                Keeper.p_playerScored(-1);
                Debug.Log("X:The player has hit the puck more then once");
                break;
            case Turns.penaltyCPU:
                Keeper.p_computerScored(-1);
                Debug.Log("Y:The computer has hit the puck more then once");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(nextTurn), nextTurn, null);

        }

       
    }

    public enum Turns
    {
        empty, t_Player, t_Computer, penaltyPlayer, penaltyCPU
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Play")
        {
            checkCurrentScore();
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void checkCurrentScore()
    {
        if (PlayerScore == 5 || ComputerScore == 5)
        {
            Debug.Log("Max points reached");
            SceneManager.LoadScene("EndGame");
            //StartCoroutine(MaxPointsReached());
        }

    }
    /*
    public void MaxPointsReached()
    {

        //_scoreBoard.GetComponent<CanvasScaler>().scaleFactor = 1;
        //yield return new WaitForSeconds(1);
        //DontDestroyOnLoad(_scoreBoard);
        SceneManager.LoadScene("EndGame");
    }*/
}
