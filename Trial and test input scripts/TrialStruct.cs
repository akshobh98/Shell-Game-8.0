using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TrialStruct
{
    public int numCups;
    public int numMoves;
    public float speed;

    public TrialStruct(int x, int y, float z){
        this.numCups = x;
        this.numMoves = y;
        this.speed = z;
    }

    //Get functions - outputting    
    public int getNumCups(){
        return numCups;
    }
    public int getNumMoves(){
        return numMoves;
    }
    public float getSpeed(){
        return speed;
    }
    //set functions - taking input
    public void setNumCups(int temp){
        numCups = temp;
    }
    public void setNumMoves(int temp){
        numMoves = temp;
    }
    public void setSpeed(float temp){
        speed = temp;
    }
}
