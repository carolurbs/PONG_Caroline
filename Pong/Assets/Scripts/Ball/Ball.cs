using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region variáveis

    [Header("Ball Settings")]
    public Vector2 speed = new Vector2(1, 1);
    public Vector2 startSpeed;

    public string keyToCheck = "Player";

    [Header("Randomization")]
    public Vector2 randSpeedY= new Vector2(1,3);
    public Vector2 randSpeedX = new Vector2(1, 3);

    private Vector2 _defaultPosition;
    public bool _canMove=false;
    #endregion

    #region métodos
    private void OnPlayerCollision()
    {
        speed.x *= -1;
        float rand = Random.Range(randSpeedX.x, randSpeedX.y);
        if (speed.x < 0)
            rand = -rand;
        speed.x = rand; 
        rand= Random.Range(randSpeedY.x, randSpeedY.y);
        speed.y = rand;
    }
    public  void ResetBall()
    {
        transform.position = _defaultPosition;
        speed = startSpeed;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
    #endregion
    #region chamada de métodos
    private void Awake()
    {
       _defaultPosition= transform.position ;
        startSpeed = speed;
    }
    private void Update()
    {
        if (!_canMove) return;
      
        transform.Translate(speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag==keyToCheck)
        {
            OnPlayerCollision();

        }
       else
        {
            speed.y *= -1;

        }
    }
    #endregion
}