using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

[RequireComponent(typeof(Image))]
public class ButtonColorBase: MonoBehaviour
{
     public Color color;
    [Header ("Refeferences")]
    public Image uiImage;

    public Player myPlayer;
  
    void Start()
    {
        uiImage.color = color;
    }
    public void OnClick()
    {
        myPlayer.ChangeColor(color);
    }
    private void OnValidate()
    {   
        uiImage=    GetComponent<Image>();
    }
}
