using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float speed;
    public int numberofcups;
    // Start is called before the first frame update
    void Start(){
        speed = PlayerPrefs.GetFloat("speed");
        numberofcups = PlayerPrefs.GetInt("cups");

        if(speed >= 0.8f && speed <= 0.85f){
            speed = 2.8f;
            if(numberofcups == 4){
                speed = 2.9f;
            }
        }
        if(speed > 0.85f && speed <= 0.95f){
            speed = 2.5f;
            if(numberofcups == 4){
                speed = 2.6f;
            }
        }
        if(speed > 0.95f && speed <= 1.05f){
            speed = 2.2f;
            if(numberofcups == 4){
                speed = 2.3f;
            }
        }
        if(speed > 1.05f && speed <= 1.15f){
            speed = 2.0f;
            if(numberofcups == 4){
                speed = 2.1f;
            }
        }
        if(speed > 1.15f && speed <= 1.2f){
            speed = 1.8f;
            if(numberofcups == 3 || numberofcups == 4){
                speed = 1.9f;
            }
        }
    PlayerPrefs.SetFloat("adjustedSpeed", speed);
    }

}
