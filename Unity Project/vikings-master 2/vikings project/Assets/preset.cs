//*************************************************************
// Author: Paul Kelting
// Description: This is the singled out code prepared for the
// preset drop down menu. Modifcations will be done so that
// this code and the other code can be combined seemlessly
//*************************************************************

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



struct Preset_Type
{
    public int cups;
    public int moves;
    public int speed;

    public Preset_Type(int cups, int moves, int speed)
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
      Preset_Type temp = new Preset_Type(int.Parse(allPresets[i+1]), int.Parse(allPresets[i+2]),int.Parse(allPresets[i+3])); //temp preset
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
      dropMenu.options.Add(new Dropdown.OptionData(){text = textField.text}); //add title
      dropMenu.RefreshShownValue();

      Preset_Type temp = new Preset_Type(int.Parse(cupField.text), int.Parse(moveField.text),int.Parse(speedField.text)); //temp preset
      presetList.Add(temp);

      textUpdate.text = ""; //tidy up fields
      cupUpdate.text = "";
      moveUpdate.text = "";
      speedUpdate.text = "";
    }
  }
  public void deletePreset(){
    if(current > 0){ //doesn't remove add new option
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
    }
  }


  public Text cupField; //what is displayed in the cup field
  public Text moveField; //what is displayed in the move field
  public Text speedField; //what is displayed in the speed field
  public Text textField; //what is displayed in the text field

  public InputField cupUpdate; //modify this to modify cup field
  public InputField moveUpdate; //modify this to modify move field
  public InputField speedUpdate; //modify this to modify speed field
  public InputField textUpdate; //modify this to modify text field

  private int current = 0; //current drop down index
  public  Dropdown dropMenu; //names of presets
  List<Preset_Type>  presetList = new List<Preset_Type>(); //list of preset values
}
