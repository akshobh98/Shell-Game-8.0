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

public class PushPatientID : MonoBehaviour
{
    public Button link;
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {

        link.onClick.AddListener(SubmitID);
    }

    // Update is called once per frame
     private void SubmitID()
    {
        string temp = gameObject.GetComponent<InputField>().text;
        PlayerPrefs.SetString("patientid", temp);
        if(PlayerPrefs.GetInt("check1") == 1){
            startButton.interactable = true; 
        } else {
            PlayerPrefs.SetInt("check2", 1);
        }   
    }
    
}
