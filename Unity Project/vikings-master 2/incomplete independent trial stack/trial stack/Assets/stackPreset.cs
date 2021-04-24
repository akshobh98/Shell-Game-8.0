//*************************************************************
// Author: Paul Kelting
// Description: This is the singled out code prepared for the
// trial stack drop down menu. Modifcations will be done so that
// this code and the other code can be combined seemlessly
//*************************************************************

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


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

public class stackPreset : MonoBehaviour {
   void Start(){ //load existing presets
    string[] allStacks = System.IO.File.ReadAllLines(Application.dataPath + "\\stackPreset.txt");
    for(int i = 0; i < allStacks.Length; i+=2){
      dropMenu.options.Add(new Dropdown.OptionData(){text = allStacks[i]});
      trailCountList.Add(int.Parse(allStacks[i+1]));
    }
    dropMenu.RefreshShownValue();
  }
  void  OnApplicationQuit(){ //save existing presets
    var outputFile = File.CreateText(Application.dataPath + "\\stackPreset.txt");
    for(int i = 0; i < trailCountList.Count; i++){
      outputFile.WriteLine(dropMenu.options[i+1].text);
      outputFile.WriteLine(trailCountList[i].ToString());
    }
    outputFile.Close();
  }
  public void addStackPreset(){
    if(current == 0){ //only adds when new option is selected
      dropMenu.options.Add(new Dropdown.OptionData(){text = textField.text}); //add title
      dropMenu.RefreshShownValue();

      trailCountList.Add(int.Parse(numberField.text));

      textUpdate.text = ""; //tidy up fields
      numberUpdate.text = "";
    }
  }
  public void deleteStackPreset(){
    if(current > 0){ //doesn't remove add new option
	    trailCountList.RemoveAt(current-1); //remove preset data
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
        trialArr = new GameObject[trailCountList[current-2]]; //spawn in appropriate stack
        for(int i = 0; i < trailCountList[current-2]; i++)
          trialArr[i] = (GameObject)Instantiate(trialOriginal, transform);
        textUpdate.text = dropMenu.options[current-1].text; //update fields
        numberUpdate.text = trailCountList[current-2].ToString();
        dropMenu.value = current-1;
      }
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
      trialArr = new GameObject[trailCountList[current-1]]; //spawn in appropriate stack
      for(int i = 0; i < trailCountList[current-1]; i++){
        trialArr[i] = (GameObject)Instantiate(trialOriginal, transform);
        //trialArr[i] = (GameObject)Instantiate(trialOriginal, new Vector3(trialOriginal.transform.position.x, trialOriginal.transform.position.y - (i*40), trialOriginal.transform.position.z), Quaternion.identity);
        trialArr[i].transform.SetParent(trialStackHold.transform, false);
      }

      textUpdate.text = dropMenu.options[current].text; //update fields
      numberUpdate.text = trailCountList[current-1].ToString();
    }
  }


  public Text numberField; //what is displayed in the speed field
  public Text textField; //what is displayed in the text field

  public InputField numberUpdate; //modify this to modify speed field
  public InputField textUpdate; //modify this to modify text field

  private int current = 0; //current drop down index
  public  Dropdown dropMenu; //names of presets
  List<int>  trailCountList = new List<int>(); //list of preset values

  public GameObject trialOriginal; //base component
  public GameObject[] trialArr; //easily modifiable rows
  public GameObject trialStackHold; //location to add trials





}
