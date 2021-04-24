//*************************************************************
// Author: Paul Kelting
// Description: This is the singled out code prepared for unmodifiable
// stack panel template, which will be used in the trial stack.
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

public class unmodifiableStackPanel : MonoBehaviour {
  void Start(){
    trialStackScript = GameObject.Find("Unmodifiable Trial Preset");
    string[] readDisplayPresets = System.IO.File.ReadAllLines(Application.dataPath + "\\preset.txt");
    for(int i = 0; i < readDisplayPresets.Length; i+=4){
      presetNames.Add(readDisplayPresets[i]);
      Preset_Type temp = new Preset_Type(int.Parse(readDisplayPresets[i+1]), int.Parse(readDisplayPresets[i+2]),Double.Parse(readDisplayPresets[i+3])); //temp preset
      displayPresetValues.Add(temp);
    }
    cupDisplay.text = displayPresetValues[current].cups.ToString();
    moveDisplay.text = displayPresetValues[current].moves.ToString();
    speedDisplay.text = displayPresetValues[current].speed.ToString();
	trialNameDisplay.text = presetNames[current];
  }
  public void changeCurrent(int changeTarget){
	current = changeTarget;
	/*cupDisplay.text = displayPresetValues[current].cups.ToString();
    moveDisplay.text = displayPresetValues[current].moves.ToString();
    speedDisplay.text = displayPresetValues[current].speed.ToString();
    trialNameDisplay.text = presetNames[current];*/
  }

  public int returnCurrent(){
    return current;
  }

  public void setTrial(int trial){
    trialDisplay.text = trial.ToString();
  }

  public Text cupDisplay;
  public Text moveDisplay;
  public Text speedDisplay;
  public Text trialDisplay;
  public Text trialNameDisplay;

  private int current = 0; //current drop down index
  List<Preset_Type>  displayPresetValues = new List<Preset_Type>(); //list of preset value options for trial stack
  List<string> presetNames = new List<string>(); //list of preset names
  public GameObject trialStackScript; //base component
}
