using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scoring
{
    public class Goal : MonoBehaviour
    {
        private GameManager gameManager;
        private ScoreKeeper Keeper;
        [SerializeField] private FlashObjColor _flash;
        //private SetUpBoard set;

        public GameObject _puck;
        public GameObject _scoreBoard;
        public GameObject _player;
        public GameObject _AIplayer;

        
        
        public void Awake()
        {
            
            gameManager = GameManager.instance;
            Keeper = new ScoreKeeper();
            
            /*
            _puck = GameManager.instance.puck;
            _scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard");
            _player = GameObject.FindGameObjectWithTag("Player");
            _AIplayer = GameObject.FindGameObjectWithTag("Computer");
            ;*/
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            _puck = GameManager.instance.puck;
            _scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard");
            _player = GameObject.FindGameObjectWithTag("Player");
            _AIplayer = GameObject.FindGameObjectWithTag("Computer");
            if (other.CompareTag("Puck"))
            {
                _flash.objFlash(Color.white);
                Destroy(GameObject.FindWithTag("Puck"));
                StartCoroutine(goalScored());
                
                if (name == "Goal_PointAI")
                {
                    Keeper.p_computerScored(1);
                }
                else if (name == "Goal_PointPlayer")
                {
                    Keeper.p_playerScored(1);
                }
                
                //checkCurrentScore();
            }
        }
        /*
        public void checkCurrentScore()
        {
            if (GameManager.PlayerScore == 5 || GameManager.ComputerScore == 5)
            {
                StartCoroutine(MaxPointsReached());
            }
            
        }
        IEnumerator MaxPointsReached()
        {
            
            //_scoreBoard.GetComponent<CanvasScaler>().scaleFactor = 1;
            yield return new WaitForSeconds(1);
            //DontDestroyOnLoad(_scoreBoard);
            SceneManager.LoadScene("EndGame");
        }*/

        IEnumerator goalScored()
        {
            _player.GetComponent<MoveWithMouse>().mouseActive = false;
            _AIplayer.GetComponent<AIController>().AIactive = false;

            Vector3 ogPos = _scoreBoard.transform.localPosition;
            Vector3 ogScale = _scoreBoard.transform.localScale;

            _scoreBoard.transform.localPosition = new Vector3(0,0,0);
            _scoreBoard.transform.localScale = new Vector3(3, 3, 0);

            yield return new WaitForSeconds(5);

            _scoreBoard.transform.localPosition= ogPos;
            _scoreBoard.transform.localScale= ogScale;

            GameObject puck= Instantiate(_puck, new Vector3(0, 0, 0), Quaternion.identity);

            _player.transform.position = new Vector3(-6, 0);
            _AIplayer.transform.position = new Vector3(6, 0);

            _player.GetComponent<MoveWithMouse>().mouseActive = true;
            _AIplayer.GetComponent<AIController>().AIactive = true;
            
            GameManager.instance.UpdateTurnState(GameManager.Turns.empty);
        }

    }
}