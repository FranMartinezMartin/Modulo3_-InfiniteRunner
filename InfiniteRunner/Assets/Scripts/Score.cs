using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    
    [SerializeField] int Yellow = 0; 
    [SerializeField] int Green = 0;
    [SerializeField] int Blue = 0;

    [SerializeField] TMP_Text yellowText, blueText, greenText;


    public void yellowDiamondSum(){
        Yellow++;
        yellowText.text = Yellow.ToString();
    }

    public void blueDiamondSum(){
        Blue++;
        blueText.text = Blue.ToString();
    }

    public void greenDiamondSum(){
        Green++;
        greenText.text = Green.ToString();
    }
    
}
