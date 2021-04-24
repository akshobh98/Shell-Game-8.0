using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.EventSystems;


public class GetInputonClick_3Cups : MonoBehaviour
{

    public Button user_click;
    public Transform prefab;

    // Start is called before the first frame update
    void Start(){
        user_click.onClick.AddListener(GetInputOnClickHandler);
    }

    public void GetInputOnClickHandler(){
            Instantiate(prefab, new Vector3(1465, 231, 323), Quaternion.Euler(new Vector3(0, 0, 180)));
            Instantiate(prefab, new Vector3(1865, 231, 323), Quaternion.Euler(new Vector3(0, 0, 180)));
    }
    
}
