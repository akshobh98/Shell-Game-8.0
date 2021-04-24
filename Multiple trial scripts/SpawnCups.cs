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
    public Transform ball;
    public Transform actualBall;
    public Transform[] cupsArray = new Transform[4];
    public TestArray reference;
    public IndexTracker indexreference;
    int numberofcups;
    void Start(){
        UnityEngine.Debug.Log(PlayerPrefs.GetInt("index"));
        numberofcups = reference.sendTrial(indexreference.sendIndex()).getNumCups();
        SpawnCupsboi();
    }

    public void SpawnCupsboi()
    { 
            if(numberofcups == 2){
                cupsArray[0] = (Transform)Instantiate(prefab, new Vector3(-50, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[1] = (Transform)Instantiate(prefab, new Vector3(50, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                actualBall = (Transform)Instantiate(ball, new Vector3(-135 ,119, -320), Quaternion.Euler(new Vector3(0, 0, 180))); 
            } else if(numberofcups == 3){
                cupsArray[0] = (Transform)Instantiate(prefab, new Vector3(0, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[1] = (Transform)Instantiate(prefab, new Vector3(-76, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[2] = (Transform)Instantiate(prefab, new Vector3(76, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                actualBall = (Transform)Instantiate(ball, new Vector3(-90 ,119, -320), Quaternion.Euler(new Vector3(0, 0, 180))); 
            } else if(numberofcups == 4){
                cupsArray[0] = (Transform)Instantiate(prefab, new Vector3(-25, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[1] = (Transform)Instantiate(prefab, new Vector3(25, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[2] = (Transform)Instantiate(prefab, new Vector3(-75, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                cupsArray[3] = (Transform)Instantiate(prefab, new Vector3(75, 140, -270), Quaternion.Euler(new Vector3(0, 0, 180)));
                actualBall = (Transform)Instantiate(ball, new Vector3(-110 ,119, -320), Quaternion.Euler(new Vector3(0, 0, 180))); 
            }

    }  
    public Transform moveAssist(int i){
        return cupsArray[i];
    }
    public Transform getBall(){
        return actualBall;
    }

}

    

