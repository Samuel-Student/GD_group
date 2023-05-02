using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    /// <summary>
    /// this is the player controller, changing the script's name now will be a pain
    /// </summary>
    public Rigidbody2D player;
    Vector3 offset;
    Vector3 mousePosition;
    public bool mouseActive;
    [SerializeField] private FlashObjColor _flash;

    private GameManager gameManager;
    private GameManager.Turns currentTurn;
    
    
   
    // Update is called once per frame
    void Update()
    {
        currentTurn = GameManager.instance.t_state;
        //if (mouseActive == true)
        //{
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D pSelected = Physics2D.OverlapPoint(mousePosition);
                if (pSelected.transform.CompareTag("Player"))
                {
                    player = pSelected.transform.gameObject.GetComponent<Rigidbody2D>();
                    offset = player.transform.position - mousePosition;
                }
            }

            if (Input.GetMouseButtonUp(0) && player)
            {
                player = null;
            }

        //}
    }
    private void FixedUpdate()
    {
        if (player)
        {
            player.MovePosition(mousePosition + offset);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            if (currentTurn == GameManager.Turns.t_Computer)
            {
                GameManager.instance.UpdateTurnState(GameManager.Turns.penaltyPlayer);
                _flash.objFlash(Color.grey);
            }

            else if (currentTurn == GameManager.Turns.penaltyPlayer)
            {
                Debug.Log("Player is tyring to hit puck again!");
            }
            else
            {
                GameManager.instance.UpdateTurnState(GameManager.Turns.t_Computer);
            }

        }
        
    }
}
