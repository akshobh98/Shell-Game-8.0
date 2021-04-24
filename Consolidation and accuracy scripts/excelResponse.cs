//*************************************************************
// Author: Paul Kelting
// Description: This is the singled out code prepared for trial
// responses, which will be used in the 3D environment.
// Modifications will be done so that this code and the other code
// can be combined seamlessly
//*************************************************************

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Linq;


public class excelResponse : MonoBehaviour {

  public void checkCurrent(int[] ballLocation, int selectedCup, TrialStruct currentTrial, DateTime startTime, DateTime endTime, int index){
    string thePathing = "Assets/Data/" + PlayerPrefs.GetString("patientid") + ".csv"; //get pathing

    Double difference = (endTime - startTime).TotalSeconds; //response time

    StreamWriter writer = new StreamWriter(thePathing, true); //enable
    if( new FileInfo(thePathing).Length == 0 ) //if empty add titles
    {
      writer.Write("trial #,");
      writer.Write("trial cups,");
      writer.Write("trial moves,");
      writer.Write("cup speed,");
      writer.Write("Correct/Incorrect,");
      //writer.Write("correct response,");
      //writer.Write("participant response,");
      writer.Write("time to response,");
      writer.Write(writer.NewLine);

    }
    writer.Close();
    writer = new StreamWriter(thePathing, true);
    writer.Write(index + ",");
    writer.Write(currentTrial.numCups + ","); //values
    writer.Write(currentTrial.numMoves + ",");
    writer.Write(currentTrial.speed + ",");
    int temp = -1;
    int i = 0;
    for( ; i < ballLocation.Length; i++){
      if(ballLocation[i] == 1)
        //writer.Write(i + ",");
        temp = i;
    }
    if(temp == selectedCup){
      writer.Write("Correct,");
    } else {
      writer.Write("Incorrect,");
    }
    //writer.Write(selectedCup + ",");
    writer.Write(difference + ",");
    writer.Write(writer.NewLine);
    writer.Close();
  }
}
