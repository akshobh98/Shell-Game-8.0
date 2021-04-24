using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.IO;
using System;

public class ChoiceArray : MonoBehaviour
{
    public int[] choices;
    public char[] tempChoices;
    public IndexTracker reference;

    // Start is called before the first frame update
    void Start()
    {
        choices = new int[PlayerPrefs.GetInt("sizeoftest")];
        tempChoices = new char[PlayerPrefs.GetInt("sizeoftest")];
        for(int i = 0; i < PlayerPrefs.GetInt("sizeoftest"); i++){
            choices[i] = 5;
        }  
        if(reference.sendIndex() == 0){
            sendChoices();
        } else {
            recieveChoices();
        }
        
    }

    public void getChoice(int x, int temp){
        choices[x] = temp;
    }

    public void sendChoices(){
        for(int i = 0; i < PlayerPrefs.GetInt("sizeoftest"); i++){
            tempChoices[i] = Convert.ToChar(choices[i]);
        }
        string temp = new string(tempChoices);
        PlayerPrefs.SetString("choiceString", temp);
    }
    
    public void recieveChoices(){
        string temp = PlayerPrefs.GetString("choiceString");
        for(int i = 0; i < PlayerPrefs.GetInt("sizeoftest"); i++){
            choices[i] = Convert.ToInt32(temp[i]);
        }
        
    }

}
