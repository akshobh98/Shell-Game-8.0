//*************************************************************
// Author: Paul Kelting
// Description: This is the singled out code prepared for the
// preset drop down menu. Modifications will be done so that
// this code and the other code can be combined seamlessly
//*************************************************************

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;



public struct Preset_Type
{
    public int cups;
    public int moves;
    public double speed;

    public Preset_Type(int cups, int moves, double speed)
    {
        this.cups = cups;
        this.moves = moves;
        this.speed = speed;
    }
}

public class preset : MonoBehaviour {
   void Start(){ //load existing presets
    string[] allPresets = System.IO.File.ReadAllLines(Application.dataPath + "\\preset.txt");
    for(int i = 0; i < allPresets.Length; i+=4){
      dropMenu.options.Add(new Dropdown.OptionData(){text = allPresets[i]});
      Preset_Type temp = new Preset_Type(int.Parse(allPresets[i+1]), int.Parse(allPresets[i+2]),Double.Parse(allPresets[i+3])); //temp preset
      presetList.Add(temp);
    }
    dropMenu.RefreshShownValue();
  }
  void  OnApplicationQuit(){ //save existing presets
    var outputFile = File.CreateText(Application.dataPath + "\\preset.txt");
    for(int i = 0; i < presetList.Count; i++){
      outputFile.WriteLine(dropMenu.options[i+1].text);
      outputFile.WriteLine(presetList[i].cups.ToString());
      outputFile.WriteLine(presetList[i].moves.ToString());
      outputFile.WriteLine(presetList[i].speed.ToString());
    }
    outputFile.Close();
  }
  public void addPreset(){
    if(current == 0){ //only adds when new option is selected

      int tempCup, tempMove;
      double tempSpeed;
      bool cupToInt = Int32.TryParse(cupField.text, out tempCup);
      bool moveToInt = Int32.TryParse(moveField.text, out tempMove);
      bool speedToDouble = Double.TryParse(speedField.text, out tempSpeed);
      if(cupToInt && moveToInt && speedToDouble && (tempCup>=2 && tempCup<=4) && (tempMove>=1 && tempMove<=20) && (tempSpeed>=.75 && tempSpeed<=1.25)){
        dropMenu.options.Add(new Dropdown.OptionData(){text = textField.text}); //add title
        dropMenu.RefreshShownValue();

        Preset_Type temp = new Preset_Type(tempCup, tempMove,tempSpeed); //temp preset
        presetList.Add(temp);

        textUpdate.text = ""; //tidy up fields
        cupUpdate.text = "";
        moveUpdate.text = "";
        speedUpdate.text = "";
		speedAlert.text = "";
		moveAlert.text = "";
		cupAlert.text = "";
        var outputFile = File.CreateText(Application.dataPath + "\\preset.txt"); //update presets in memory
        for(int i = 0; i < presetList.Count; i++){
          outputFile.WriteLine(dropMenu.options[i+1].text);
          outputFile.WriteLine(presetList[i].cups.ToString());
          outputFile.WriteLine(presetList[i].moves.ToString());
          outputFile.WriteLine(presetList[i].speed.ToString());
        }
        outputFile.Close();
        if(stackController.GetComponent<trialStack>().isCurrentZero() == false)
          stackController.GetComponent<trialStack>().updateAllPanels(); //update memory
      }
      else{
        if (!(tempCup>=2 && tempCup<=4))
          cupAlert.text = "X";
        else
          cupAlert.text = "";
        if (!(tempMove>=1 && tempMove<=20))
          moveAlert.text = "X";
        else
          moveAlert.text = "";
        if (!(tempSpeed>=.75 && tempSpeed<=1.25))
          speedAlert.text = "X";
        else
          speedAlert.text = "";
      }
    }
  }

  public void deletePreset(){
    if(current > 0){ //doesn't remove add new option
      stackController.GetComponent<trialStack>().shiftIndex(current); //update memory
	     presetList.RemoveAt(current-1); //remove preset data
      dropMenu.options.RemoveAt(current); //remove preset title
      dropMenu.RefreshShownValue();
      if(current-1 == 0){
        textUpdate.text = ""; //tidy up fields
        cupUpdate.text = "";
        moveUpdate.text = "";
        speedUpdate.text = "";
        dropMenu.value = 0;
      }
      else{
        textUpdate.text = dropMenu.options[current-1].text; //update fields
        cupUpdate.text = presetList[current-2].cups.ToString();
        moveUpdate.text =  presetList[current-2].moves.ToString();
        speedUpdate.text =  presetList[current-2].speed.ToString();
        dropMenu.value = current-1;
      }
      var outputFile = File.CreateText(Application.dataPath + "\\preset.txt"); //update presets in memory
      for(int i = 0; i < presetList.Count; i++){
        outputFile.WriteLine(dropMenu.options[i+1].text);
        outputFile.WriteLine(presetList[i].cups.ToString());
        outputFile.WriteLine(presetList[i].moves.ToString());
        outputFile.WriteLine(presetList[i].speed.ToString());
      }
      outputFile.Close();
      if(stackController.GetComponent<trialStack>().isCurrentZero() == false)
        stackController.GetComponent<trialStack>().updateAllPanels(); //update memory

  }
}
  public void updateCurrent(int index){
    this.current = index;
    if(current == 0){ //allow for new preset to be added
      textUpdate.text = ""; //tidy up fields
      cupUpdate.text = "";
      moveUpdate.text = "";
      speedUpdate.text = "";
    }
    else{ //show current one
      textUpdate.text = dropMenu.options[current].text; //update fields
      cupUpdate.text = presetList[current-1].cups.ToString();
      moveUpdate.text =  presetList[current-1].moves.ToString();
      speedUpdate.text =  presetList[current-1].speed.ToString();
      cupAlert.text = "";
      moveAlert.text = "";
      speedAlert.text = "";
    }
  }

  public List<Preset_Type> dataSend(){
    List<int> transferData = stackController.GetComponent<trialStack>().returnCurrentTrialstack();
    List<Preset_Type> returnData = new List<Preset_Type>();
    for(int i = 0; i < transferData.Count; i++)
      returnData.Add(presetList[transferData[i]]);
    return returnData;
  }

  public Text cupField; //what is displayed in the cup field
  public Text moveField; //what is displayed in the move field
  public Text speedField; //what is displayed in the speed field
  public Text textField; //what is displayed in the text field

  public Text cupAlert; //when setting requirements are out of bounds
  public Text moveAlert;
  public Text speedAlert;

  public InputField cupUpdate; //modify this to modify cup field
  public InputField moveUpdate; //modify this to modify move field
  public InputField speedUpdate; //modify this to modify speed field
  public InputField textUpdate; //modify this to modify text field

  private int current = 0; //current drop down index
  public  Dropdown dropMenu; //names of presets
  List<Preset_Type>  presetList = new List<Preset_Type>(); //list of preset values
  public GameObject stackController; //base component
}
