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

public class PushSpeed : MonoBehaviour{
 
    // Start is called before the first frame update
    void Start()
    {
        var input_speed = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitSpeed);
        input_speed.onEndEdit = se; 
    }

    // Update is called once per frame
     private void SubmitSpeed(string arg0)
    {
        UnityEngine.Debug.Log(arg0);
        PlayerPrefs.SetFloat("speed", float.Parse(arg0));
    }
}
