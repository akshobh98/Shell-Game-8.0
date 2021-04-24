using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexTracker : MonoBehaviour
{
    int temp;
    
    public void Start(){
        UnityEngine.Debug.Log(PlayerPrefs.GetInt("index"));
        temp = PlayerPrefs.GetInt("index");
    }
    
    public void updateIndex(){
        temp++;
        PlayerPrefs.SetInt("index", temp);
    }

    public int sendIndex(){
        return temp;
    }
}
