//*************************************************************
// Author: Paul Kelting
// Description: This is the singled out code prepared for stack
// panel template, which will be used in the trial stack.
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

public class stackPanel : MonoBehaviour {
  void Start(){
    trialStackScript = GameObject.Find("Trial Preset");
    string[] readDisplayPresets = System.IO.File.ReadAllLines(Application.dataPath + "\\preset.txt");
    for(int i = 0; i < readDisplayPresets.Length; i+=4){
      displayDropMenu.options.Add(new Dropdown.OptionData(){text = readDisplayPresets[i]});
      Preset_Type temp = new Preset_Type(int.Parse(readDisplayPresets[i+1]), int.Parse(readDisplayPresets[i+2]),Double.Parse(readDisplayPresets[i+3])); //temp preset
      displayPresetValues.Add(temp);
    }
    cupDisplay.text = displayPresetValues[current].cups.ToString();
    moveDisplay.text = displayPresetValues[current].moves.ToString();
    speedDisplay.text = displayPresetValues[current].speed.ToString();
    displayDropMenu.value = current;
    displayDropMenu.RefreshShownValue();
  }
  public void updateCurrent(int index){
    this.current = index;
    cupDisplay.text = displayPresetValues[current].cups.ToString();
    moveDisplay.text = displayPresetValues[current].moves.ToString();
    speedDisplay.text = displayPresetValues[current].speed.ToString();
    trialStackScript.GetComponent<trialStack>().updateCurrentTrialstack();
  }
  public void refreshPanel(){
    displayDropMenu.ClearOptions();
    displayPresetValues.Clear();
    string[] readDisplayPresets = System.IO.File.ReadAllLines(Application.dataPath + "\\preset.txt");
    for(int i = 0; i < readDisplayPresets.Length; i+=4){
      displayDropMenu.options.Add(new Dropdown.OptionData(){text = readDisplayPresets[i]});
      Preset_Type temp = new Preset_Type(int.Parse(readDisplayPresets[i+1]), int.Parse(readDisplayPresets[i+2]),Double.Parse(readDisplayPresets[i+3])); //temp preset
      displayPresetValues.Add(temp);
    }
    displayDropMenu.RefreshShownValue();
    cupDisplay.text = displayPresetValues[current].cups.ToString();
    moveDisplay.text = displayPresetValues[current].moves.ToString();
    speedDisplay.text = displayPresetValues[current].speed.ToString();
    displayDropMenu.value = current;

  }

  public void changeCurrent(int changeTarget){
    current = changeTarget;
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

  private int current = 0; //current drop down index
  public  Dropdown displayDropMenu; //names of presets
  List<Preset_Type>  displayPresetValues = new List<Preset_Type>(); //list of preset value options for trial stack
  public GameObject trialStackScript; //base component
}
