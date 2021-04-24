/*
Sprint 1
Akshobh Mirapurkar
Script for saving and deleting the options
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDMenu : MonoBehaviour {
    public Text dropDownText;

    private int index;

    public Dropdown drop;

    public InputField eraseField; 

    public void addit(){
        drop.options.Add (new Dropdown.OptionData(){text = dropDownText.text});
        drop.RefreshShownValue ();

        eraseField.text = "";
    }
    public void deleteit(){
        drop.options.RemoveAt(index);
        drop.RefreshShownValue ();
    }

    public void setIndex(int varIndex){
        this.index = varIndex;
    }

    
}
