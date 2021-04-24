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

public class TypeField : MonoBehaviour
{
    public Button link;
    // Start is called before the first frame update
    void Start()
    {
        var input_id = gameObject.GetComponent<InputField>();
        var se = new InputField.OnChangeEvent();

        se.AddListener(linkinteractable);
        input_id.onValueChanged = se; 
    }

    private void linkinteractable(string arg0)
    {
        link.interactable = true;
    }
}
