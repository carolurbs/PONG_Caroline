using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    private string keyToSave = "keyHighscore";
    [Header("References")]
    public TextMeshProUGUI uiTextHighscore; 
    public void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        uiTextHighscore.text = PlayerPrefs.GetString(keyToSave, "Sem Highscore");

    }
    public void SavePlayerWin(Player p)
    {
        if (p.playerName == "") return; 
        PlayerPrefs.SetString(keyToSave, p. playerName);
        UpdateText();

    }
}
