using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OnClickStart : MonoBehaviour
{
    public Button user_click;

    void start(){
        user_click.onClick.AddListener(GetInputOnClickHandler);
    }
  
    public void GetInputOnClickHandler(){
        SceneManager.LoadScene("CupPreview", LoadSceneMode.Single);
    }
}
