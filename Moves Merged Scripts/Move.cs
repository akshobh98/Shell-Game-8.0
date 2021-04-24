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
    public float speed0;
    public float speed1;
    public float speed2;
    public float speed3;
    int numberofcups;
    int numberofmoves;
    public Button user_click;
    int functionSelection = -1;
    int x = 0;

    public void Start(){
        user_click.onClick.AddListener(Setup);
        //select = reference1.selector();
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
    
    public void playGame(int x){
        if(numberofcups == 2){
            functionSelection = 0;
        }
        if(numberofcups == 3){
            System.Random rnd = new System.Random();  
            functionSelection = rnd.Next(1, 4);
        }
        if(numberofcups == 4){
            System.Random rnd = new System.Random();  
            functionSelection = rnd.Next(4, 10);
        }
        if(x > numberofmoves - 1){
            functionSelection = -1;
        }
    }

    public void Update(){
        if(functionSelection > -1){
            if(numberofcups == 2){
                if(play){
                    playGame(x);
                    x++;
                    play = false;
                }
                if(functionSelection == 0){
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
                        speed2 = 0;
                        speed3 = 0;
                        play = true;
                        Transform temp;
                        temp = notCupsArray[1];
                        notCupsArray[1] = notCupsArray[0];
                        notCupsArray[0] = temp;
                    }
                    update_speed();
                }
            }
            if(numberofcups == 3){
                    if(play){
                        playGame(x);
                        x++;
                        play = false;
                    }
                    if(functionSelection == 1){
                        update_speed();
                        UnityEngine.Debug.Log("fs: 1");
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
                            speed2 = 0;
                            speed3 = 0;
                            play = true;
                            Transform temp;
                            temp = notCupsArray[1];
                            notCupsArray[1] = notCupsArray[0];
                            notCupsArray[0] = temp;
                        }
                    }
                    if(functionSelection == 2){
                        update_speed();
                        UnityEngine.Debug.Log("fs: 2");
                        notCupsArray[2].transform.Translate(speed2 * Vector3.right * -20 * Time.deltaTime, Space.World);
                        if(notCupsArray[2].transform.position.x <= 76 && notCupsArray[2].transform.position.x < 0){
                            notCupsArray[2].transform.Translate(speed2 * Vector3.forward * -10 * Time.deltaTime , Space.World);
                        }
                        if(notCupsArray[2].transform.position.x >= 0){
                            notCupsArray[2].transform.Translate(speed2 * Vector3.forward * 10 * Time.deltaTime , Space.World);
                        }
                        if(notCupsArray[2].transform.position.x <= -76){
                            speed2 = 0;
                        }
                        notCupsArray[1].transform.Translate(speed1 * Vector3.right * 20 * Time.deltaTime, Space.World);
                        if(notCupsArray[1].transform.position.x >= 0 && notCupsArray[1].transform.position.x > -76){
                            notCupsArray[1].transform.Translate(speed1 * Vector3.forward * 10 * Time.deltaTime , Space.World);
                        }
                        if(notCupsArray[1].transform.position.x <= 0){
                            notCupsArray[1].transform.Translate(speed1 * Vector3.forward * -10 * Time.deltaTime , Space.World);
                        }
                        if(notCupsArray[1].transform.position.x >= 76){
                            speed1 = 0;
                        }
                        if(speed1 == 0 && speed2 == 0){
                            speed0 = 0;
                            speed3 = 0;
                            play = true;
                            Transform temp;
                            temp = notCupsArray[2];
                            notCupsArray[2] = notCupsArray[1];
                            notCupsArray[1] = temp;
                        }
                }
                if(functionSelection == 3){
                    update_speed();
                    UnityEngine.Debug.Log("fs: 3");
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
                    if(notCupsArray[0].transform.position.x >= 0 && notCupsArray[0].transform.position.x > 38){
                        notCupsArray[0].transform.Translate(speed0 * Vector3.forward * 20 * Time.deltaTime , Space.World);
                    }
                    if(notCupsArray[0].transform.position.x <= 38){
                        notCupsArray[0].transform.Translate(speed0 * Vector3.forward * -20 * Time.deltaTime , Space.World);
                    }
                    if(notCupsArray[0].transform.position.x >= 76){
                        speed0 = 0;
                    }
                    if(speed0 == 0 && speed2 == 0){
                        speed1 = 0;
                        speed3 = 0;
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
                update_speed();
                notCupsArray[3].transform.Translate(speed3 * Vector3.right * -20 * Time.deltaTime, Space.World);
                if(notCupsArray[3].transform.position.x <= 75 && notCupsArray[3].transform.position.x > 50){
                    notCupsArray[3].transform.Translate(speed3 * Vector3.forward * -20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[3].transform.position.x <= 50){
                    notCupsArray[3].transform.Translate(speed3 * Vector3.forward * 20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[3].transform.position.x <= 25){
                    speed3 = 0;
                }
                notCupsArray[1].transform.Translate(speed1 * Vector3.right * 20 * Time.deltaTime, Space.World);
                if(notCupsArray[1].transform.position.x >= 25 && notCupsArray[1].transform.position.x < 50){
                    notCupsArray[1].transform.Translate(speed1 * Vector3.forward * 20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[1].transform.position.x >= 50){
                    notCupsArray[1].transform.Translate(speed1 * Vector3.forward * -20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[1].transform.position.x >= 75){
                    speed1 = 0;
                }
                if(speed3 == 0 && speed1 == 0){
                    speed0 = 0;
                    speed2 = 0;
                    play = true;
                    Transform temp;
                    temp = notCupsArray[1];
                    notCupsArray[1] = notCupsArray[3];
                    notCupsArray[3] = temp;
                }
                    
            }
            if(functionSelection == 5){
                update_speed();
                notCupsArray[2].transform.Translate(speed2 * Vector3.right * 20 * Time.deltaTime, Space.World);
                if(notCupsArray[2].transform.position.x >= -75 && notCupsArray[2].transform.position.x > -50){
                    notCupsArray[2].transform.Translate(speed2 * Vector3.forward * -20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[2].transform.position.x <= -50){
                    notCupsArray[2].transform.Translate(speed2 * Vector3.forward * 20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[2].transform.position.x >= -25){
                    speed2 = 0;
                }
                notCupsArray[0].transform.Translate(speed0 * Vector3.right * -20 * Time.deltaTime, Space.World);
                if(notCupsArray[0].transform.position.x <= -25 && notCupsArray[0].transform.position.x < -50){
                    notCupsArray[0].transform.Translate(speed0 * Vector3.forward * 20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[0].transform.position.x >= -50){
                    notCupsArray[0].transform.Translate(speed0 * Vector3.forward * -20 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[0].transform.position.x <= -75){
                    speed0 = 0;
                }
                if(speed0 == 0 && speed2 == 0){
                    speed1 = 0;
                    speed3 = 0;
                    play = true;
                    Transform temp;
                    temp = notCupsArray[2];
                    notCupsArray[2] = notCupsArray[0];
                    notCupsArray[0] = temp;
                }
            }
            if(functionSelection == 6){
                update_speed();
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
                    speed3 = 0;
                    speed0 = 0;
                    play = true;
                    Transform temp;
                    temp = notCupsArray[2];
                    notCupsArray[2] = notCupsArray[1];
                    notCupsArray[1] = temp;
                }
                
            }
            if(functionSelection == 7){
                update_speed();
                notCupsArray[2].transform.Translate(speed2 * Vector3.right * 20 * Time.deltaTime, Space.World);
                 if(notCupsArray[2].transform.position.x >= -75 && notCupsArray[2].transform.position.x < 0){
                    notCupsArray[2].transform.Translate(speed2 * Vector3.forward * -13 * Time.deltaTime , Space.World);
                 }
                if(notCupsArray[2].transform.position.x >= 0){
                    notCupsArray[2].transform.Translate(speed2 * Vector3.forward * 13 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[2].transform.position.x >= 75){
                    speed2 = 0;
                }
                notCupsArray[3].transform.Translate(speed3 * Vector3.right * -20 * Time.deltaTime, Space.World);
                if(notCupsArray[3].transform.position.x <= 75 && notCupsArray[3].transform.position.x > 0){
                    notCupsArray[3].transform.Translate(speed3 * Vector3.forward * 13 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[3].transform.position.x <= 0){
                    notCupsArray[3].transform.Translate(speed3 * Vector3.forward * -13 * Time.deltaTime , Space.World);
                }
                if(notCupsArray[3].transform.position.x <= -75){
                    speed3 = 0;
                }
                if(speed3 == 0 && speed2 == 0){
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
                update_speed();
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
                    speed1 = 0;
                    speed2 = 0;
                    play = true;
                    Transform temp;
                    temp = notCupsArray[0];
                    notCupsArray[0] = notCupsArray[3];
                    notCupsArray[3] = temp;
                }
                
            }
            if(functionSelection == 9){
                update_speed();
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
                    speed2 = 0;
                    speed3 = 0;
                    play = true;
                    Transform temp;
                    temp = notCupsArray[0];
                    notCupsArray[0] = notCupsArray[1];
                    notCupsArray[1] = temp;
                }
                     
            }
        }
            
        }
    }
    public void update_speed(){
        speed0 = 1;
        speed1 = 1;
        speed2 = 1;
        speed3 = 1;
    }

}


