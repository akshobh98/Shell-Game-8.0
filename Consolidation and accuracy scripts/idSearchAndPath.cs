//*************************************************************
// Author: Paul Kelting
// Description: This is the singled out code prepared for the
// patient id pathing. Modifications will be done so that
// this code and the other code can be combined seamlessly
//*************************************************************

 using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

//created class used with the search id textfield and button
public class idSearchAndPath : MonoBehaviour
{
    public void Start(){
      var cubeRenderer = progressCube.GetComponent<Renderer>();
      cubeRenderer.material.SetColor("_Color", Color.grey);
      stall = true;
    }
    public void Update(){
      var cubeRenderer = progressCube.GetComponent<Renderer>();
      if(path != "Assets/Data/" + userInput.text + ".csv" && !stall){
        cubeRenderer.material.SetColor("_Color", Color.red);
      }
    }
    //handler to execute what happens when a click on the button is made
    public void theButtonFunction()
    {
        if (stall){
          stall = false;
        }
        var cubeRenderer = progressCube.GetComponent<Renderer>();
        //debug message to imform that the input was recieved
        UnityEngine.Debug.Log("Search ID: " + userInput.text);
        cubeRenderer.material.SetColor("_Color", Color.yellow);

        //creating a string that will be used as the files path
        //goes to the directory, adds the user inputted id and adds the csv extension.
        path = "Assets/Data/" + userInput.text + ".csv";

        //sets up the creathed string as a write path
        StreamWriter writer = new StreamWriter(path, true);


        //close the write path
        writer.Close();
        cubeRenderer.material.SetColor("_Color", Color.green);


    }
    public string returnThePath(){
      return path;
    }
    //in game assests to allow user input
    public GameObject progressCube;
    public InputField userInput;
    private string path;
    private bool stall;
}
