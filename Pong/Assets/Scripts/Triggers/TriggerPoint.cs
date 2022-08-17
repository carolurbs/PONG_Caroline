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

    private void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }
}
