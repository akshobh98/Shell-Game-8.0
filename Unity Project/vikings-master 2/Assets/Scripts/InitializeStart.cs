using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class InitializeStart : MonoBehaviour
{
    public int check = 0;
    public Button link;
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("check1", check);
        PlayerPrefs.SetInt("check2", check);
        link.interactable = false;
        startButton.interactable = false; 
    }

    
}
