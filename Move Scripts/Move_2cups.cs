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

public class Move_2cups : MonoBehaviour
{
    public SpawnCups reference;
    public Transform[] notCupsArray = new Transform[4];
    public float speed1 = 0;
    public float speed2 = 0;
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
            if(numberofcups == 2){
                notCupsArray[1].transform.Translate(speed1 * Vector3.right * -20 * Time.deltaTime , Space.World);
                if(notCupsArray[1].transform.position.x <= 50 && notCupsArray[1].transform.position.x > 0){
                    notCupsArray[1].transform.Translate(speed1 * Vector3.forward * -6 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[1].transform.position.x <= 0){
                    notCupsArray[1].transform.Translate(speed1 * Vector3.forward * 6 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[1].transform.position.x <= -50){
                    speed1 = 0;
                }
                notCupsArray[0].transform.Translate(speed0 * Vector3.right * 20 * Time.deltaTime, Space.World);
                if(notCupsArray[0].transform.position.x >= -50 && notCupsArray[0].transform.position.x < 0){
                    notCupsArray[0].transform.Translate(speed0 * Vector3.forward * 6 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[0].transform.position.x >= 0){
                    notCupsArray[0].transform.Translate(speed0 * Vector3.forward * -6 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[0].transform.position.x >= 50){
                    speed0 = 0;
                }
                if(speed0 == 0 && speed1 == 0){
                    Transform temp;
                    temp = notCupsArray[1];
                    notCupsArray[1] = notCupsArray[0];
                    notCupsArray[0] = temp;
                }
            }
            if(numberofcups == 3){
                notCupsArray[1].transform.Translate(speed1 * Vector3.right * 20 * Time.deltaTime, Space.World);
                if(notCupsArray[1].transform.position.x >= -76 && notCupsArray[1].transform.position.x > -38){
                    notCupsArray[1].transform.Translate(speed1 * Vector3.forward * -20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[1].transform.position.x <= -38){
                    notCupsArray[1].transform.Translate(speed1 * Vector3.forward * 20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[1].transform.position.x >= 0){
                    speed1 = 0;
                }
                notCupsArray[0].transform.Translate(speed0 * Vector3.right * -20 * Time.deltaTime, Space.World);
                if(notCupsArray[0].transform.position.x <= 0 && notCupsArray[0].transform.position.x < -38){
                    notCupsArray[0].transform.Translate(speed0 * Vector3.forward * 20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[0].transform.position.x >= -38){
                    notCupsArray[0].transform.Translate(speed0 * Vector3.forward * -20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[0].transform.position.x <= -76){
                    speed0 = 0;
                }
                if(speed0 == 0 && speed1 == 0){
                    Transform temp;
                    temp = notCupsArray[1];
                    notCupsArray[1] = notCupsArray[0];
                    notCupsArray[0] = temp;
                }
            }
            if(numberofcups == 4){
           notCupsArray[0].transform.Translate(speed0 * Vector3.right * 20 * Time.deltaTime, Space.World);
        if(notCupsArray[0].transform.position.x >= -25 && notCupsArray[0].transform.position.x < 0){
            notCupsArray[0].transform.Translate(speed0 * Vector3.forward * -17 * Time.deltaTime , Space.World);
        }
        if(notCupsArray[0].transform.position.x >= 0){
            notCupsArray[0].transform.Translate(speed0 * Vector3.forward * 17 * Time.deltaTime , Space.World);
        }
        if(notCupsArray[0].transform.position.x >= 25){
            speed0 = 0;
        }
        notCupsArray[1].transform.Translate(speed1 * Vector3.right * -20 * Time.deltaTime, Space.World);
        if(notCupsArray[1].transform.position.x <= 25 && notCupsArray[1].transform.position.x > 0){
            notCupsArray[1].transform.Translate(speed1 * Vector3.forward * 17 * Time.deltaTime , Space.World);
        }
        if(notCupsArray[1].transform.position.x <= 0){
            notCupsArray[1].transform.Translate(speed1 * Vector3.forward * -17 * Time.deltaTime , Space.World);
        }
        if(notCupsArray[1].transform.position.x <= -25){
            speed1 = 0;
        }
        if(speed1 == 0 && speed0 == 0){
            Transform temp;
            temp = notCupsArray[0];
            notCupsArray[0] = notCupsArray[1];
            notCupsArray[1] = temp;
        }
            
            
        }
            user_click.onClick.AddListener(update_speed);  
    }
    public void update_speed(){
        speed1 = 1;
        speed2 = 1;
        speed3 = 1;
        speed0 = 1;
    }
}
