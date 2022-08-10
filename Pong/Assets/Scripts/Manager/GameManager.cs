using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [Header("Player")]
    private Player playerBase; 

    [Header("Ball")]

    public Ball ballBase;
    public StateMachine stateMachine;
    public static GameManager Instance;
    public float timetoSetBallFree;

    [Header("Menus")]
    public GameObject uiMainMenu;
    public GameObject uiEndGame; 

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
    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.StateType.END_GAME);
        
    }

    public void ShowMainMenu()
    {

        uiMainMenu.SetActive(true);
        uiEndGame.SetActive(false);
        ballBase.CanMove(false);

    }
    public void EndGameMenu()
        
    {

        uiMainMenu.SetActive(false);
        uiEndGame.SetActive(true);

        #region área comentada - apenas leitura 

        //Algo aqui não funciona - Parte do código que detecta qual dos jogadores alcançou a pontuação máxima
        /* if (playerOne >= playerBase.maxPoints)
         {
             playerUI.text = "PLAYER ONE WINS";
             Debug.Log("PLAYER ONE WINS");


         }
         else if (playerTwo >= playerBase.maxPoints)

         {
             playerUI.text = "PLAYER TWO WINS";
             Debug.Log("PLAYER TWO WINS");
         }
*/
     }
        #endregion

    }