//*************************************************************
// Author: Paul Kelting
// Description: This is the singled out code prepared for the
// non modifiable trial stackmenu. Modifications will be done so that
// this code and the other code can be combined seamlessly
//*************************************************************

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class unmodifiableTrialStack : MonoBehaviour {
   void Start(){ //load existing presets
    string[] allStacks = System.IO.File.ReadAllLines(Application.dataPath + "\\trialStack.txt");
    for(int i = 0; i < allStacks.Length; i +=2+int.Parse(allStacks[i+1])){
      dropMenu.options.Add(new Dropdown.OptionData(){text = allStacks[i]});
      trialCountList.Add(int.Parse(allStacks[i+1]));
      trialStackData.Add(new List<int>());
      for(int j = 1; j <= int.Parse(allStacks[i+1]); j++){
        trialStackData[trialStackData.Count-1].Add(int.Parse(allStacks[i+1+j]));
      }
    }
    dropMenu.RefreshShownValue();
    updateStackCurrent(0);

  }

public void updateStackCurrent(int index){
  this.current = index;
  for(int i = 0; i < trialArr.Length; i++){ //clear current stack
    Destroy(trialArr[i]);
  }
//show current one
    trialArr = new GameObject[trialCountList[current]]; //spawn in appropriate stack
    for(int i = 0; i < trialCountList[current]; i++){
      trialArr[i] = (GameObject)Instantiate(trialOriginal, transform);
      trialArr[i].transform.SetParent(trialStackHold.transform, false);
      trialArr[i].GetComponent<unmodifiableStackPanel>().changeCurrent(trialStackData[current][i]);
      trialArr[i].GetComponent<unmodifiableStackPanel>().setTrial(i+1);
    }
    TextUpdate.text = dropMenu.options[current].text;
}

  public void shiftIndex(int target){
    for(int i = 0; i < trialCountList.Count; i++){
      for(int j = 0; j < trialCountList[i]; j++){
        if (trialStackData[i][j] >= target-1 && trialStackData[i][j] != 0) //target is one index larger due to existing in dropdown containing "add" as an option
          trialStackData[i][j]--; //shift down by one
      }
    }
  }

  public List<int> returnCurrentTrialstack(){
    List<int> fail = new List<int>();
    if (current > 0)
      return trialStackData[current];
    else
      return fail;
  }

  public bool isCurrentZero(){
    if (current == 0)
      return true;
    else
      return false;
  }


  private int current = 0; //current drop down index
  public  Dropdown dropMenu; //names of presets
  List<int>  trialCountList = new List<int>(); //list of preset values for trial stack
  List<List<int>> trialStackData= new List<List<int>>(); //list of trial stack data, first dimension represents preset index

  public GameObject trialOriginal; //base component
  public GameObject[] trialArr; //easily modifiable rows
  public GameObject trialStackHold; //location to add trials
  public InputField TextUpdate; 
}
