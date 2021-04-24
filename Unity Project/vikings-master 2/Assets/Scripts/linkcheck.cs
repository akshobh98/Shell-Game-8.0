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


public class linkcheck : MonoBehaviour
{
    public Button startButton;
    public Button linkButton;
    // Start is called before the first frame update
    void Start()
    {
        linkButton.onClick.AddListener(linkClick);
    }

    public void linkClick(){
        startButton.interactable = true; 
    }
}
