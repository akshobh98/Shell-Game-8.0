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

public class secondpushid : MonoBehaviour
{
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        var input_id = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitID);
        input_id.onEndEdit = se; 
    }

    // Update is called once per frame
     private void SubmitID(string arg0)
    {
        UnityEngine.Debug.Log(arg0);
        PlayerPrefs.SetString("patientid", arg0);
        //startButton.interactable = true; 
    }
    
}
