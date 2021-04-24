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

public class Move : MonoBehaviour
{
    public SpawnCups reference;
    public Transform[] notCupsArray = new Transform[4];
    public bool play = true;
    public float speed;
    public float speed0;
    public float speed1;
    public float speed2;
    public float speed3;
    public Vector3 Target1;
    public Vector3 Target2;
    public bool t1;
    public bool t2;
    int numberofcups;
    int numberofmoves;
    public Button user_click;
    int functionSelection = -1;
    int x = 0;

    public float time1;

    public void Start(){
        user_click.onClick.AddListener(Setup);
    }

    public void Setup(){
        numberofcups = PlayerPrefs.GetInt("cups");
        numberofmoves = PlayerPrefs.GetInt("moves");
        for(int i = 0; i < numberofcups; i++){
            notCupsArray[i] = reference.moveAssist(i);
        }
        functionSelection = 100;
        speed0 = 0;
        speed1 = 0;
        speed2 = 0;
        speed3 = 0;
    }
    //Randomizer - randomizes the moves
    public void playGame(int x){
        if(numberofcups == 2){
            functionSelection = 0;
            t1 = false;
            t2 = false;
        }
        if(numberofcups == 3){
            System.Random rnd = new System.Random();  
            functionSelection = rnd.Next(1, 4);
            t1 = false;
            t2 = false;
        }
        if(numberofcups == 4){
            System.Random rnd = new System.Random();  
            functionSelection = rnd.Next(4, 10);
            t1 = false;
            t2 = false;
        }
        if(x > numberofmoves - 1){
            functionSelection = -1;
            UnityEngine.Debug.Log(time1);
        }
    }

    public void Update(){
        if(x == 0){
            time1 = 0;
        } else {
            time1 += Time.fixedDeltaTime;   
        }
        if(functionSelection > -1){
            if(numberofcups == 2){
                if(play){
                    playGame(x);
                    x++;
                    play = false;
                }
                if(functionSelection == 0){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x - 50;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[0].transform.position;
                        Target2.x = Target2.x + 50;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[1].transform.position.x == 0){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x - 50;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[0].transform.position.x == 0){
                        Target2 = notCupsArray[0].transform.position;
                        Target2.x = Target2.x + 50;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[1].transform.position = Vector3.MoveTowards(notCupsArray[1].transform.position, Target1, speed1 * 1);
                    notCupsArray[0].transform.position = Vector3.MoveTowards(notCupsArray[0].transform.position, Target2, speed0 * 1);
                    if(notCupsArray[1].transform.position.x == -50 && notCupsArray[0].transform.position.x == 50){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[1];
                        notCupsArray[1] = notCupsArray[0];
                        notCupsArray[0] = temp;
                    }
                }
            }
            if(numberofcups == 3){
                if(play){
                    playGame(x);
                    x++;
                    play = false;
                }
                if(functionSelection == 1){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x + 38;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[0].transform.position;
                        Target2.x = Target2.x - 38;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[1].transform.position.x == -38){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x + 38;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[0].transform.position.x == -38){
                        Target2 = notCupsArray[0].transform.position;
                        Target2.x = Target2.x - 38;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[1].transform.position = Vector3.MoveTowards(notCupsArray[1].transform.position, Target1, speed1 * .76f);
                    notCupsArray[0].transform.position = Vector3.MoveTowards(notCupsArray[0].transform.position, Target2, speed0 * .76f);
                    if(notCupsArray[1].transform.position.x == 0 && notCupsArray[0].transform.position.x == -76){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[1];
                        notCupsArray[1] = notCupsArray[0];
                        notCupsArray[0] = temp;
                    }
                }
                if(functionSelection == 2){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x + 76;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[2].transform.position;
                        Target2.x = Target2.x - 76;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[1].transform.position.x == 0){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x + 76;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[2].transform.position.x == 0){
                        Target2 = notCupsArray[2].transform.position;
                        Target2.x = Target2.x - 76;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[1].transform.position = Vector3.MoveTowards(notCupsArray[1].transform.position, Target1, speed1 * 1.52f);
                    notCupsArray[2].transform.position = Vector3.MoveTowards(notCupsArray[2].transform.position, Target2, speed0 * 1.52f);
                    if(notCupsArray[1].transform.position.x == 76 && notCupsArray[2].transform.position.x == -76){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[1];
                        notCupsArray[1] = notCupsArray[2];
                        notCupsArray[2] = temp;
                    }
                }
                if(functionSelection == 3){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[2].transform.position;
                        Target1.x = Target1.x - 38;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[0].transform.position;
                        Target2.x = Target2.x + 38;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[2].transform.position.x == 38){
                        Target1 = notCupsArray[2].transform.position;
                        Target1.x = Target1.x - 38;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[0].transform.position.x == 38){
                        Target2 = notCupsArray[0].transform.position;
                        Target2.x = Target2.x + 38;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[2].transform.position = Vector3.MoveTowards(notCupsArray[2].transform.position, Target1, speed1 * .76f);
                    notCupsArray[0].transform.position = Vector3.MoveTowards(notCupsArray[0].transform.position, Target2, speed0 * .76f);
                    if(notCupsArray[2].transform.position.x == 0 && notCupsArray[0].transform.position.x == 76){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[2];
                        notCupsArray[2] = notCupsArray[0];
                        notCupsArray[0] = temp;
                    }
                }
            }
            if(numberofcups == 4){
                if(play){
                    playGame(x);
                    x++;
                    play = false;
                }
                if(functionSelection == 4){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x + 25;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[3].transform.position;
                        Target2.x = Target2.x - 25;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[1].transform.position.x == 50){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x + 25;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[3].transform.position.x == 50){
                        Target2 = notCupsArray[3].transform.position;
                        Target2.x = Target2.x - 25;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[1].transform.position = Vector3.MoveTowards(notCupsArray[1].transform.position, Target1, speed1 * .5f);
                    notCupsArray[3].transform.position = Vector3.MoveTowards(notCupsArray[3].transform.position, Target2, speed0 * .5f);
                    if(notCupsArray[1].transform.position.x == 75 && notCupsArray[3].transform.position.x == 25){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[1];
                        notCupsArray[1] = notCupsArray[3];
                        notCupsArray[3] = temp;
                    }
                    
                }
                if(functionSelection == 5){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[0].transform.position;
                        Target1.x = Target1.x - 25;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[2].transform.position;
                        Target2.x = Target2.x + 25;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[0].transform.position.x == -50){
                        Target1 = notCupsArray[0].transform.position;
                        Target1.x = Target1.x - 25;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[2].transform.position.x == -50){
                        Target2 = notCupsArray[2].transform.position;
                        Target2.x = Target2.x + 25;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[0].transform.position = Vector3.MoveTowards(notCupsArray[0].transform.position, Target1, speed1 * .5f);
                    notCupsArray[2].transform.position = Vector3.MoveTowards(notCupsArray[2].transform.position, Target2, speed0 * .5f);
                    if(notCupsArray[0].transform.position.x == -75 && notCupsArray[2].transform.position.x == -25){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[0];
                        notCupsArray[0] = notCupsArray[2];
                        notCupsArray[2] = temp;
                    }
                }
                if(functionSelection == 6){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x - 50;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[2].transform.position;
                        Target2.x = Target2.x + 50;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[1].transform.position.x == -25){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x - 50;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[2].transform.position.x == -25){
                        Target2 = notCupsArray[2].transform.position;
                        Target2.x = Target2.x + 50;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[1].transform.position = Vector3.MoveTowards(notCupsArray[1].transform.position, Target1, speed1 * 1);
                    notCupsArray[2].transform.position = Vector3.MoveTowards(notCupsArray[2].transform.position, Target2, speed0 * 1);
                    if(notCupsArray[1].transform.position.x == -75 && notCupsArray[2].transform.position.x == 25){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[1];
                        notCupsArray[1] = notCupsArray[2];
                        notCupsArray[2] = temp;
                    }
                }
                if(functionSelection == 7){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[2].transform.position;
                        Target1.x = Target1.x + 75;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[3].transform.position;
                        Target2.x = Target2.x - 75;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[2].transform.position.x == 0){
                        Target1 = notCupsArray[2].transform.position;
                        Target1.x = Target1.x + 75;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[3].transform.position.x == 0){
                        Target2 = notCupsArray[3].transform.position;
                        Target2.x = Target2.x - 75;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[2].transform.position = Vector3.MoveTowards(notCupsArray[2].transform.position, Target1, speed1 * 1.5f);
                    notCupsArray[3].transform.position = Vector3.MoveTowards(notCupsArray[3].transform.position, Target2, speed0 * 1.5f);
                    if(notCupsArray[2].transform.position.x == 75 && notCupsArray[3].transform.position.x == -75){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[2];
                        notCupsArray[2] = notCupsArray[3];
                        notCupsArray[3] = temp;
                    }
                }
                if(functionSelection == 8){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[0].transform.position;
                        Target1.x = Target1.x + 50;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[3].transform.position;
                        Target2.x = Target2.x - 50;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[0].transform.position.x == 25){
                        Target1 = notCupsArray[0].transform.position;
                        Target1.x = Target1.x + 50;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[3].transform.position.x == 25){
                        Target2 = notCupsArray[3].transform.position;
                        Target2.x = Target2.x - 50;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[0].transform.position = Vector3.MoveTowards(notCupsArray[0].transform.position, Target1, speed1 * 1);
                    notCupsArray[3].transform.position = Vector3.MoveTowards(notCupsArray[3].transform.position, Target2, speed0 * 1);
                    if(notCupsArray[0].transform.position.x == 75 && notCupsArray[3].transform.position.x == -25){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[0];
                        notCupsArray[0] = notCupsArray[3];
                        notCupsArray[3] = temp;
                    }
                }
                if(functionSelection == 9){
                    speed0 = update_speed(speed0);
                    speed1 = update_speed(speed1);
                    if(!t1){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x - 25;
                        Target1.z = Target1.z - 20;
                        t1 = true;
                    }
                    if(!t2){
                        Target2 = notCupsArray[0].transform.position;
                        Target2.x = Target2.x + 25;
                        Target2.z = Target2.z + 20;
                        t2 = true;
                    }
                    if(notCupsArray[1].transform.position.x == 0){
                        Target1 = notCupsArray[1].transform.position;
                        Target1.x = Target1.x - 25;
                        Target1.z = Target1.z + 20;
                    }
                    if(notCupsArray[0].transform.position.x == 0){
                        Target2 = notCupsArray[0].transform.position;
                        Target2.x = Target2.x + 25;
                        Target2.z = Target2.z - 20;
                    }
                    notCupsArray[1].transform.position = Vector3.MoveTowards(notCupsArray[1].transform.position, Target1, speed1 * .5f);
                    notCupsArray[0].transform.position = Vector3.MoveTowards(notCupsArray[0].transform.position, Target2, speed0 * .5f);
                    if(notCupsArray[1].transform.position.x == -25 && notCupsArray[0].transform.position.x == 25){
                        speed1 = 0;
                        speed0 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[1];
                        notCupsArray[1] = notCupsArray[0];
                        notCupsArray[0] = temp;
                    }
                }
            }
            
        }
    }
    public float update_speed(float speed){
        speed =  PlayerPrefs.GetFloat("adjustedSpeed");
        return speed;
    }

}


