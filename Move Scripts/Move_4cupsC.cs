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

public class Move_4cupsC : MonoBehaviour
{
    public SpawnCups reference;
    public Transform[] notCupsArray = new Transform[4];
    public float speed1 = 0;
    public float speed2 = 0;
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
        notCupsArray[2].transform.Translate(speed2 * Vector3.right * 20 * Time.deltaTime, Space.World);
        if(notCupsArray[2].transform.position.x >= -75 && notCupsArray[2].transform.position.x < -25){
            notCupsArray[2].transform.Translate(speed2 * Vector3.forward * -20 * Time.deltaTime , Space.World);
        }
        if(notCupsArray[2].transform.position.x >= -25){
            notCupsArray[2].transform.Translate(speed2 * Vector3.forward * 20 * Time.deltaTime , Space.World);
            }
            if(notCupsArray[2].transform.position.x >= 25){
                speed2 = 0;
            }
            notCupsArray[1].transform.Translate(speed1 * Vector3.right * -20 * Time.deltaTime, Space.World);
            if(notCupsArray[1].transform.position.x <= 25 && notCupsArray[1].transform.position.x > -25){
                notCupsArray[1].transform.Translate(speed1 * Vector3.forward * 20 * Time.deltaTime , Space.World);
            }
            if(notCupsArray[1].transform.position.x <= -25){
                notCupsArray[1].transform.Translate(speed1 * Vector3.forward * -20 * Time.deltaTime , Space.World);
            }
            if(notCupsArray[1].transform.position.x <= -75){
                speed1 = 0;
            }
            if(speed1 == 0 && speed2 == 0){
                Transform temp;
                temp = notCupsArray[2];
                notCupsArray[2] = notCupsArray[1];
                notCupsArray[1] = temp;
            }
            
        user_click.onClick.AddListener(update_speed);  
    }
    public void update_speed(){
        speed1 = 1;
        speed2 = 1;
    }
}


