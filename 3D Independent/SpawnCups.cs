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

public class SpawnCups : MonoBehaviour
{   
    public Transform prefab;
    public Transform[] cupsArray = new Transform[4];
    int numberofcups;
    //public Button user_click;
    void Start(){
        numberofcups = PlayerPrefs.GetInt("cups");
        //user_click.onClick.AddListener(SpawnCupsboi);
        SpawnCupsboi();
    }

    public void SpawnCupsboi()
    { 
            if(numberofcups == 2){
                cupsArray[0] = (Transform)Instantiate(prefab, new Vector3(-50, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[1] = (Transform)Instantiate(prefab, new Vector3(50, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
            } else if(numberofcups == 3){
                cupsArray[0] = (Transform)Instantiate(prefab, new Vector3(0, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[1] = (Transform)Instantiate(prefab, new Vector3(-76, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[2] = (Transform)Instantiate(prefab, new Vector3(76, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
            } else if(numberofcups == 4){
                cupsArray[0] = (Transform)Instantiate(prefab, new Vector3(-25, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[1] = (Transform)Instantiate(prefab, new Vector3(25, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[2] = (Transform)Instantiate(prefab, new Vector3(-75, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[3] = (Transform)Instantiate(prefab, new Vector3(75, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
            }   
    }  
    public Transform moveAssist(int i){
        return cupsArray[i];
    }

}

    

