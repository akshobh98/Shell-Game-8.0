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
    public int functionSelection = -2;
    int x = 0;

    public Transform ball;
    bool c;
    bool b;
    bool m;
    bool z;
    public Vector3 ballTarget1;
    public Vector3 ballTarget2;
    public Button ball_click;
    public int[] ballLocation = new int[4];

    public float time1;
    bool ballUpdate;
    bool cupUpdate;
    public DateTime startTime;
    public DateTime endTime;
    
    public TestArray testreference;
    public IndexTracker indexreference;
    public Button next_trial_click;
    
    public Button myButton1;
    public Button myButton2;
    public Button myButton3;
    public Button myButton4;
    public Button myButton5;
    public Button myButton6;
    public Button myButton7;
    public Button myButton8;
    public Button myButton9;
    public bool response = false;
    public int choice = -1;
    public ChoiceArray choiceReference;
    public excelResponse excelresponseref;
    TrialStruct sendResponse;
    public Button endtest;
    

    public void Start(){
        //UnityEngine.Debug.Log("move " + PlayerPrefs.GetInt("index"));
        TrialStruct tempTrial;
        user_click.interactable = true;
        tempTrial = testreference.sendTrial(indexreference.sendIndex());
        numberofcups = tempTrial.getNumCups();
        numberofmoves = tempTrial.getNumMoves();
        sendResponse = tempTrial;
        for(int i = 0; i < numberofcups; i++){
            notCupsArray[i] = reference.moveAssist(i);
        }
        //ball_click.onClick.AddListener(ballSetup);
        user_click.onClick.AddListener(ballSetup);
    }
    
    public void ballSetup(){
        ball = reference.getBall();
        c = false;
        b = false;
        m = false;
        z = false;
        ballUpdate = true;
        for(int i = 0; i < numberofcups; i++){
            ballLocation[i] = 0;
        }
        ballLocation[0] = 1;
    }

    public void Setup(){
        functionSelection = 100;
        speed0 = 0;
        speed1 = 0;
        speed2 = 0;
        speed3 = 0;
        cupUpdate = true;
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
            startTime = DateTime.Now;
            
            if(numberofcups == 4){
                myButton1.gameObject.SetActive(true);
                myButton2.gameObject.SetActive(true);
                myButton3.gameObject.SetActive(true);
                myButton4.gameObject.SetActive(true);
            }
            if(numberofcups == 3){
                myButton5.gameObject.SetActive(true);
                myButton6.gameObject.SetActive(true);
                myButton7.gameObject.SetActive(true);
            }
            if(numberofcups == 2){
                myButton8.gameObject.SetActive(true);
                myButton9.gameObject.SetActive(true);
            }

            
        }
    }

    public void button1Picked(){
        response = true;
        choice = 0;
        UnityEngine.Debug.Log(choice);
    }
    public void button2Picked(){
        response = true;
        choice = 1;
        UnityEngine.Debug.Log(choice);
    }
    public void button3Picked(){
        response = true;
        choice = 2;
        UnityEngine.Debug.Log(choice);
    }
    public void button4Picked(){
        response = true;
        choice = 3;
        UnityEngine.Debug.Log(choice);
    }

    public void next_trial(){
        if(indexreference.sendIndex() + 1 < PlayerPrefs.GetInt("sizeoftest")){
            indexreference.updateIndex();
            SceneManager.LoadScene("CupPreview");
        }

    }

    public void FixedUpdate(){
        if(functionSelection == -1){
            myButton1.onClick.AddListener(button3Picked);
            myButton2.onClick.AddListener(button1Picked);
            myButton3.onClick.AddListener(button2Picked);
            myButton4.onClick.AddListener(button4Picked);
            myButton5.onClick.AddListener(button2Picked);
            myButton6.onClick.AddListener(button1Picked);
            myButton7.onClick.AddListener(button3Picked);
            myButton8.onClick.AddListener(button1Picked);
            myButton9.onClick.AddListener(button2Picked);
            
            UnityEngine.Debug.Log("choice");
            if(response){
                next_trial_click.gameObject.SetActive(true);
                endTime = DateTime.Now;
                excelresponseref.checkCurrent(ballLocation, choice, sendResponse,startTime, endTime, indexreference.sendIndex());
                myButton1.gameObject.SetActive(false);
                myButton2.gameObject.SetActive(false);
                myButton3.gameObject.SetActive(false);
                myButton4.gameObject.SetActive(false);
                myButton5.gameObject.SetActive(false);
                myButton6.gameObject.SetActive(false);
                myButton7.gameObject.SetActive(false);
                myButton8.gameObject.SetActive(false);
                myButton9.gameObject.SetActive(false);
                choiceReference.getChoice(indexreference.sendIndex(), choice);
                choiceReference.sendChoices();
                functionSelection = -2;
                response = false;

                if (indexreference.sendIndex() + 1 < PlayerPrefs.GetInt("sizeoftest"))
                {
                    next_trial_click.onClick.AddListener(next_trial);
                }
                else
                {
                    next_trial_click.gameObject.SetActive(false);
                    endtest.gameObject.SetActive(true);
                }
            }
        }
        if(ballUpdate){
                if(!c){ 
                    ballTarget1 = notCupsArray[0].transform.position;
                    ballTarget1.y = ballTarget1.y + 50;
                    c = true;
                    user_click.interactable = false;
                }
            notCupsArray[0].transform.position = Vector3.MoveTowards(notCupsArray[0].transform.position, ballTarget1, 1);
            if(c){
                if(!b){
                    ballTarget2 = ball.transform.position;
                    ballTarget2.z = ballTarget2.z + 50;
                    b = true;
                }
                ball.transform.position = Vector3.MoveTowards(ball.transform.position, ballTarget2, 1);
            }
            if(ball.transform.position == ballTarget2 && !m){
                ballTarget1.y = ballTarget1.y - 50;
                m = true;
            }
            if(m){
                notCupsArray[0].transform.position = Vector3.MoveTowards(notCupsArray[0].transform.position, ballTarget1, 1);
            }
            if(m && notCupsArray[0].transform.position == ballTarget1){
                z = true;
            }
            if(z){
                z = false;
                m = false;
                ballTarget1 = ball.transform.position;
                ballTarget1.y = ballTarget1.y + 1000;
                ball.transform.position = ballTarget1;
                ballUpdate = false;
                Setup();
            }
        }
        if(cupUpdate){
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
                            int tempint = ballLocation[0];
                            ballLocation[0] = ballLocation[1];
                            ballLocation[1] = tempint;
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
                            int tempint = ballLocation[0];
                            ballLocation[0] = ballLocation[1];
                            ballLocation[1] = tempint;
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
                            int tempint = ballLocation[2];
                            ballLocation[2] = ballLocation[1];
                            ballLocation[1] = tempint;
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
                            int tempint = ballLocation[2];
                            ballLocation[2] = ballLocation[0];
                            ballLocation[0] = tempint;
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
                            int tempint = ballLocation[3];
                            ballLocation[3] = ballLocation[1];
                            ballLocation[1] = tempint;
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
                            int tempint = ballLocation[2];
                            ballLocation[2] = ballLocation[0];
                            ballLocation[0] = tempint;
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
                            int tempint = ballLocation[2];
                            ballLocation[2] = ballLocation[1];
                            ballLocation[1] = tempint;
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
                            int tempint = ballLocation[2];
                            ballLocation[2] = ballLocation[3];
                            ballLocation[3] = tempint;
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
                            int tempint = ballLocation[0];
                            ballLocation[0] = ballLocation[3];
                            ballLocation[3] = tempint;
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
                            int tempint = ballLocation[0];
                            ballLocation[0] = ballLocation[1];
                            ballLocation[1] = tempint;
                        }
                    }
                }
                
            }
        }
    }
    public float update_speed(float speed){
        speed =  PlayerPrefs.GetFloat("adjustedSpeed");
        return speed;
    }
    public int ballLoc(int i){
        return ballLocation[i];
    }
    public DateTime sendStartTime(){
        return startTime;
    }
    public DateTime sendEndTime(){
        return endTime;
    }
    public int sendChoice(){
        return choice;
    }

}


