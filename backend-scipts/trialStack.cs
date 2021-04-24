//*************************************************************
// Author: Paul Kelting
// Description: This is the singled out code prepared for the
// trial stack drop down menu. Modifications will be done so that
// this code and the other code can be combined seamlessly
//*************************************************************

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class trialStack : MonoBehaviour {
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
  }
  void  OnApplicationQuit(){ //save existing presets
    var outputFile = File.CreateText(Application.dataPath + "\\trialStack.txt");
    for(int i = 0; i < trialCountList.Count; i++){
      outputFile.WriteLine(dropMenu.options[i+1].text);
      outputFile.WriteLine(trialCountList[i].ToString());
      for(int j = 0; j < trialCountList[i]; j++)
        outputFile.WriteLine(trialStackData[i][j].ToString());
    }
    outputFile.Close();
  }
  public void addStack(){
    if(current == 0){ //only adds when new option is selected
      int tempTrials;
      bool trialsToInt = Int32.TryParse(numberField.text, out tempTrials);
      if(trialsToInt){
        dropMenu.options.Add(new Dropdown.OptionData(){text = textField.text}); //add title
        dropMenu.RefreshShownValue();

        trialCountList.Add(int.Parse(numberField.text));
        trialStackData.Add(new List<int>()); //allocate index memory
        for(int i = 0; i < int.Parse(numberField.text); i++) //allocate placeholder memory
          trialStackData[trialStackData.Count-1].Add(0);
        textUpdate.text = ""; //tidy up fields
        numberUpdate.text = "";

		var outputFile = File.CreateText(Application.dataPath + "\\trialStack.txt");
		for(int i = 0; i < trialCountList.Count; i++){
			outputFile.WriteLine(dropMenu.options[i+1].text);
			outputFile.WriteLine(trialCountList[i].ToString());
			for(int j = 0; j < trialCountList[i]; j++)
				outputFile.WriteLine(trialStackData[i][j].ToString());
		}
		outputFile.Close();
		}
	}
  }
  public void deleteStack(){
    if(current > 0){ //doesn't remove add new option
	    trialCountList.RemoveAt(current-1); //remove preset data
      dropMenu.options.RemoveAt(current); //remove preset title
      dropMenu.RefreshShownValue();
      for(int i = 0; i < trialArr.Length; i++) //clear current stack
        Destroy(trialArr[i]);
      if(current-1 == 0){
        textUpdate.text = ""; //tidy up fields
        numberUpdate.text = "";
        dropMenu.value = 0;
      }
      else{
        trialArr = new GameObject[trialCountList[current-2]]; //spawn in appropriate stack
        for(int i = 0; i < trialCountList[current-2]; i++)
          trialArr[i] = (GameObject)Instantiate(trialOriginal, transform);
        textUpdate.text = dropMenu.options[current-1].text; //update fields
        numberUpdate.text = trialCountList[current-2].ToString();
        dropMenu.value = current-1;
      }
	var outputFile = File.CreateText(Application.dataPath + "\\trialStack.txt");
	for(int i = 0; i < trialCountList.Count; i++){
		outputFile.WriteLine(dropMenu.options[i+1].text);
		outputFile.WriteLine(trialCountList[i].ToString());
		for(int j = 0; j < trialCountList[i]; j++)
			outputFile.WriteLine(trialStackData[i][j].ToString());
	}
	outputFile.Close();
  }
}
public void updateStackCurrent(int index){
  this.current = index;
  for(int i = 0; i < trialArr.Length; i++) //clear current stack
    Destroy(trialArr[i]);
  if(current == 0){ //allow for new preset to be added
    textUpdate.text = ""; //tidy up fields
    numberUpdate.text = "";
  }
  else{ //show current one
    trialArr = new GameObject[trialCountList[current-1]]; //spawn in appropriate stack
    for(int i = 0; i < trialCountList[current-1]; i++){
      trialArr[i] = (GameObject)Instantiate(trialOriginal, transform);
      trialArr[i].transform.SetParent(trialStackHold.transform, false);
      trialArr[i].GetComponent<stackPanel>().changeCurrent(trialStackData[current-1][i]);
      trialArr[i].GetComponent<stackPanel>().setTrial(i+1);
    }
    textUpdate.text = dropMenu.options[current].text; //update fields
    numberUpdate.text = trialCountList[current-1].ToString();
  }
}

  public void updateCurrentTrialstack(){
    for(int i = 0; i < trialStackData[current-1].Count; i++){
      stackPanel hold = trialArr[i].GetComponent<stackPanel>();
      trialStackData[current-1][i] = hold.returnCurrent();
    }
    var outputFile = File.CreateText(Application.dataPath + "\\trialStack.txt");
  	for(int i = 0; i < trialCountList.Count; i++){
  		outputFile.WriteLine(dropMenu.options[i+1].text);
  		outputFile.WriteLine(trialCountList[i].ToString());
  		for(int j = 0; j < trialCountList[i]; j++)
  			outputFile.WriteLine(trialStackData[i][j].ToString());
  	}
  	outputFile.Close();
  }

  public void shiftIndex(int target){
    for(int i = 0; i < trialCountList.Count; i++){
      for(int j = 0; j < trialCountList[i]; j++){
        if (trialStackData[i][j] >= target-1 && trialStackData[i][j] != 0) //target is one index larger due to existing in dropdown containing "add" as an option
          trialStackData[i][j]--; //shift down by one
      }
    }
  }

  public void updateAllPanels(){
    for(int i = 0; i < trialStackData[current-1].Count; i++){
      trialArr[i].GetComponent<stackPanel>().changeCurrent(trialStackData[current-1][i]);
      trialArr[i].GetComponent<stackPanel>().refreshPanel();
    }
  }

  public List<int> returnCurrentTrialstack(){
    List<int> fail = new List<int>();
    if (current > 0)
      return trialStackData[current-1];
    else
      return fail;
  }

  public bool isCurrentZero(){
    if (current == 0)
      return true;
    else
      return false;
  }


  public Text numberField; //what is displayed in the speed field
  public Text textField; //what is displayed in the text field

  public InputField numberUpdate; //modify this to modify speed field
  public InputField textUpdate; //modify this to modify text field

  private int current = 0; //current drop down index
  public  Dropdown dropMenu; //names of presets
  List<int>  trialCountList = new List<int>(); //list of preset values for trial stack
  List<List<int>> trialStackData= new List<List<int>>(); //list of trial stack data, first dimension represents preset index

  public GameObject trialOriginal; //base component
  public GameObject[] trialArr; //easily modifiable rows
  public GameObject trialStackHold; //location to add trials

}
