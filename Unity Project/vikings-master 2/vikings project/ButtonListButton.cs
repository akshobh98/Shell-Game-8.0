/*
Sprint 1
Akshobh Mirapurkar
script to Control the list of buttons/rectangles
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text myText;
    [SerializeField]
    private ButtonListControl buttonControl;

    private string myTextString;

    public void SetText(string textstring){
        myText.text = textstring;
        myText.text = textstring;
    }

    public void OnClick(){
        buttonControl.ButtonClicked(myTextString);
    }
}
