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

public class Move_3cupsC : MonoBehaviour
{
    public SpawnCups reference;
    public Transform[] notCupsArray = new Transform[4];
    public float speed0 = 0;
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
            notCupsArray[2].transform.Translate(speed2 * Vector3.right * -20 * Time.deltaTime, Space.World);
            if(notCupsArray[2].transform.position.x <= 76 && notCupsArray[2].transform.position.x < 38){
                notCupsArray[2].transform.Translate(speed2 * Vector3.forward * -20 * Time.deltaTime , Space.World);
            }
            if(notCupsArray[2].transform.position.x >= 38){
                notCupsArray[2].transform.Translate(speed2 * Vector3.forward * 20 * Time.deltaTime , Space.World);
            }
            if(notCupsArray[2].transform.position.x <= 0){
                speed2 = 0;
            }
            notCupsArray[0].transform.Translate(speed0 * Vector3.right * 20 * Time.deltaTime, Space.World);
            if(notCupsArray[0].transform.position.x >= 38 && notCupsArray[0].transform.position.x > 76){
                notCupsArray[0].transform.Translate(speed0 * Vector3.forward * 20 * Time.deltaTime , Space.World);
            }
            if(notCupsArray[0].transform.position.x <= 38){
                notCupsArray[0].transform.Translate(speed0 * Vector3.forward * -20 * Time.deltaTime , Space.World);
            }
            if(notCupsArray[0].transform.position.x >= 76){
                speed0 = 0;
            }
            if(speed0 == 0 && speed2 == 0){
                Transform temp;
                temp = notCupsArray[2];
                notCupsArray[2] = notCupsArray[0];
                notCupsArray[0] = temp;
            }
        user_click.onClick.AddListener(update_speed);  
    }
    public void update_speed(){
        speed0 = 1;
        speed2 = 1;
    }
}
