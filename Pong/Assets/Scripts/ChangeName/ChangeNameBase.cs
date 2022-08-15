using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ChangeNameBase : MonoBehaviour
{
    #region variáveis
    [Header("References")]
    [SerializeField]
    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputFieldName;
    public GameObject changeNameInput;
    public Player player;
    
    private string playerName;
    #endregion
    #region métodos
    public void ChangeName()
    {
        playerName= uiInputFieldName.text;
        uiTextName.text = uiInputFieldName.text;
        changeNameInput.SetActive(false);
        player. SetName(playerName);
    }
    #endregion
}
