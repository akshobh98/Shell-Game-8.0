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

public class secondTestName : MonoBehaviour
{
    public Button user_click;
    void Start()
    {
        user_click.onClick.AddListener(submitTestName);
        //var se = new InputField.SubmitEvent();
        //se.AddListener(SubmitName);
        //input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    public void submitTestName(){
        var input = gameObject.GetComponent<InputField>();
        string tn;
        tn = input.text;
        UnityEngine.Debug.Log("test name " + tn);
        PlayerPrefs.SetString("testname", tn);
        int i = 0;
        PlayerPrefs.SetInt("index", i);
    }
    /*private void SubmitName(string arg0)
    {
        UnityEngine.Debug.Log(arg0);
        PlayerPrefs.SetString("testname", arg0);
    }*/
}
