using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ballBase;
    public StateMachine stateMachine;
    public static GameManager Instance;
    public float timetoSetBallFree = 1f;
    public void Awake()
    {
        Instance = this;
    }
   
    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timetoSetBallFree); 
        
    }

    private void SetBallFree()
    {
        ballBase.CanMove(true);


    }
    public void StartGame()
    {
        ballBase.CanMove(true);
    }
}