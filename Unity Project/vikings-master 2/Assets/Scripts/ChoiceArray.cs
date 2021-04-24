using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.IO;
using System;
using UnityEditor;

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
        var temp = "./Data/temp/temp.txt";
        using (StreamReader reader = new StreamReader(temp))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("sizeoftest"); i++)
            {
                string input = reader.ReadLine();
                choices[i] = Convert.ToInt32(input);
            }
        }
    }
    
    public void recieveChoices(){
        var temp = "./Data/temp/temp.txt";
        File.WriteAllText(temp, "");
        using (StreamWriter writer = new StreamWriter(temp))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("sizeoftest"); i++)
            {
                writer.WriteLine(choices[i]);
            }
            writer.Close();
        }
    }

}
