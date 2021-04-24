using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class pushTestName : MonoBehaviour
{
    public Button startButton;
    void Start()
    {

        var input_id = gameObject.GetComponent<InputField>();
        var se = new InputField.OnChangeEvent();

        se.AddListener(SubmitID);
        input_id.onValueChanged = se; 
        //var se = new InputField.SubmitEvent();
        //se.AddListener(SubmitName);
        //input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    private void SubmitID(string arg0){
        var input = gameObject.GetComponent<InputField>();
        string tn;
        tn = input.text;
        UnityEngine.Debug.Log("test name " + tn);
        PlayerPrefs.SetString("testname", tn);
        int i = 0;
        PlayerPrefs.SetInt("index", i); 
        if(PlayerPrefs.GetInt("check2") == 1){
            startButton.interactable = true; 
        } else {
            PlayerPrefs.SetInt("check1", 1);
        }   
    }
    /*private void SubmitName(string arg0)
    {
        UnityEngine.Debug.Log(arg0);
        PlayerPrefs.SetString("testname", arg0);
    }*/
}
