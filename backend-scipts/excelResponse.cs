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
  public void checkCurrent(int[] ballLocation, int selectedCup, Preset_Type currentTrial, DateTime startTime){
    string thePathing = menuPathScript.GetComponent<idSearchAndPath>().returnThePath(); //get pathing

    DateTime responseTime = DateTime.Now; //time now
    Double difference = (responseTime - startTime).TotalSeconds; //response time

    StreamWriter writer = new StreamWriter(thePathing, true); //enable
    if( new FileInfo(thePathing).Length == 0 ) //if empty add titles
    {
      writer.Write("trial #");
      writer.Write("trial cups");
      writer.Write("trial moves");
      writer.Write("cup speed");
      writer.Write("correct response");
      writer.Write("participant response");
      writer.Write("time to response");
      writer.Write(writer.NewLine);
      writer.Write("1");

    }
    writer.Close();
    writer = new StreamWriter(thePathing, true);
    if(Int32.Parse(File.ReadLines(thePathing).LastOrDefault()) != 1){ //trial number update for concatination
      writer.Write(Int32.Parse(File.ReadLines(thePathing).LastOrDefault())+1);
    }

    writer.Write(currentTrial.cups); //values
    writer.Write(currentTrial.moves);
    writer.Write(currentTrial.speed);
    for(int i = 0; i < ballLocation.Length; i++){
      if(ballLocation[i] == 1)
        writer.Write(i);
    }
    writer.Write(selectedCup);
    writer.Write(difference);
    writer.Write(writer.NewLine);
    writer.Close();
  }
  public GameObject menuPathScript; //Location of id linking
}
