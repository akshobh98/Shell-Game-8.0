using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Text;



public class passwordLock : MonoBehaviour
{
    public InputField password;
    public Button login;

    // Start is called before the first frame update
    void Start()
    {
        login.onClick.AddListener(GetInputOnClickHandler);

    }

    // Update is called once per frame
    public void GetInputOnClickHandler(){
        string text; 
        var fileStream = new FileStream("./Data/temp/password.txt", FileMode.Open, FileAccess.Read);
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8)){
            text = streamReader.ReadToEnd();
        }
        string input = password.text;
        if (input.Equals(text)){
            SceneManager.LoadScene("FirstScreenScene", LoadSceneMode.Single);
        }
        else{
            UnityEngine.Debug.Log("Wrong Password");
            SceneManager.LoadScene("Password", LoadSceneMode.Single);
        }
    }
}
