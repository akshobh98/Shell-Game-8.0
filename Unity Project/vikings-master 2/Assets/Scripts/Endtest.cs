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

public class Endtest : MonoBehaviour
{
    public Button endtest;

    // Start is called before the first frame update
    void Start()
    {
        endtest.gameObject.SetActive(false);
        endtest.onClick.AddListener(switchscene);
    }

    // Update is called once per frame
    void switchscene()
    {
        SceneManager.LoadScene("LaunchPage");
    }
}
