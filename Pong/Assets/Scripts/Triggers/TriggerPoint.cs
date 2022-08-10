using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TriggerPoint : MonoBehaviour
{
    public int playerOne;
    public int playerTwo;
    public bool _IsTrigger1;
    public Player player; 
    public string tagToCheck = "Ball";
    public TextMeshProUGUI playerUI;



    private void Start()
    {
        if (this.gameObject.name == "Trigger 1") _IsTrigger1 = true; 
        else if (this.gameObject.name == "Trigger 2") _IsTrigger1 = false;
    }
    private void Update()
    {
        EndGameText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag ==tagToCheck)
            {
            Debug.Log("Bati na bola");
            CountPoint();
            if (_IsTrigger1 == true)
            {
                playerTwo++;
            }
            if (_IsTrigger1 == false)
            {
                playerOne++;
            }
        }
    }
  void EndGameText()
    {
        if (playerOne == player.maxPoints) playerUI.text = "Player 1 Wins"; 
        else if (playerTwo == player.maxPoints) playerUI.text = "Player 2 Wins";
    }
    private void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }
}
