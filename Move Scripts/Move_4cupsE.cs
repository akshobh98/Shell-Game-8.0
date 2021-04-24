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

public class Move_4cupsE : MonoBehaviour
{
    public SpawnCups reference;
    public Transform[] notCupsArray = new Transform[4];
    public float speed3 = 0;
    public float speed0 = 0;
    public Button user_click;
    int numberofcups;
    
    void Start()
    {
        numberofcups = PlayerPrefs.GetInt("cups");
        for(int i = 0; i < numberofcups; i++){
            notCupsArray[i] = reference.moveAssist(i);
        }
        
    }

    public void Update(){
        notCupsArray[0].transform.Translate(speed0 * Vector3.right * 20 * Time.deltaTime, Space.World);
        if(notCupsArray[0].transform.position.x >= -25 && notCupsArray[0].transform.position.x < 25){
            notCupsArray[0].transform.Translate(speed0 * Vector3.forward * -17 * Time.deltaTime , Space.World);
        }
        if(notCupsArray[0].transform.position.x >= 25){
            notCupsArray[0].transform.Translate(speed0 * Vector3.forward * 17 * Time.deltaTime , Space.World);
        }
        if(notCupsArray[0].transform.position.x >= 75){
            speed0 = 0;
        }
        notCupsArray[3].transform.Translate(speed3 * Vector3.right * -20 * Time.deltaTime, Space.World);
        if(notCupsArray[3].transform.position.x <= 75 && notCupsArray[3].transform.position.x > 25){
            notCupsArray[3].transform.Translate(speed3 * Vector3.forward * 17 * Time.deltaTime , Space.World);
        }
        if(notCupsArray[3].transform.position.x <= 25){
            notCupsArray[3].transform.Translate(speed3 * Vector3.forward * -17 * Time.deltaTime , Space.World);
        }
        if(notCupsArray[3].transform.position.x <= -25){
            speed3 = 0;
        }
        if(speed3 == 0 && speed0 == 0){
            Transform temp;
            temp = notCupsArray[0];
            notCupsArray[0] = notCupsArray[3];
            notCupsArray[3] = temp;
        }
            
        user_click.onClick.AddListener(update_speed);  
    }
    public void update_speed(){
        speed3 = 1;
        speed0 = 1;
    }
}


