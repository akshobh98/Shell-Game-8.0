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

public class PushMoves : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var input_numberofmoves = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitMoves);
        input_numberofmoves.onEndEdit = se; 
    }

    // Update is called once per frame
     private void SubmitMoves(string arg0)
    {
        UnityEngine.Debug.Log(arg0);
        PlayerPrefs.SetInt("moves", Int32.Parse(arg0));
    }
}
