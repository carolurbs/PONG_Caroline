using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    #region variáveis
    [Header("Player Settings")]
    public int maxPoints;
    public float speed;
    public Rigidbody2D myRigidbody2D;
    [Header("Key Settup")]
    public KeyCode KeyCodeMoveUp = KeyCode.W;
    public KeyCode KeyCodeMoveDown = KeyCode.S;
    [Header("Point")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;
    public Ball ballBase;
    public Image uiPlayer;
    public string playerName; 
    #endregion

    #region métodos 
    public void AddPoint()
    {
        currentPoints++;
        Debug.Log(currentPoints);
        UpdateUI();
        CheckMaxPoints();
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }
    
    private void  CheckMaxPoints()
    {
        if(currentPoints>=maxPoints)
        {
            GameManager.Instance.EndGame();
            ballBase.CanMove(false);
            HighScoreManager.Instance.SavePlayerWin(this);
        }
       
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
    }


    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }
    public void SetName( string s)
    {
        playerName = s;
    }
    #endregion

    #region chamada de métodos
    private void Awake()
    {
        ResetPlayer();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCodeMoveUp))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
           
        }
        else if (Input.GetKey(KeyCodeMoveDown))
        {
            
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed);

        }
    }
    #endregion

   
}
