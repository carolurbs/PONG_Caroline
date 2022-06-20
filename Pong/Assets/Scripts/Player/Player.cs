using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    #region variáveis
    [Header("Player Settings")]
    public float speed;
    public Rigidbody2D myRigidbody2D;
    [Header("Key Settup")]
    public KeyCode KeyCodeMoveUp = KeyCode.W;
    public KeyCode KeyCodeMoveDown = KeyCode.S;
    [Header("Point")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    #endregion

    #region métodos 
    public void AddPoint()
    {
        currentPoints++;
        Debug.Log(currentPoints);
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }
    


    private void ResetPlayer()
    {
        currentPoints = 0;
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
