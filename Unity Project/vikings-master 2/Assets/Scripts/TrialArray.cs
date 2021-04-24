using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.IO;
using System;

public class TrialArray : MonoBehaviour
{
    List<TrialStruct> trialList = new List<TrialStruct>();
    public void Start(){
        using(StreamReader file = new StreamReader(Application.dataPath + "\\preset.txt")){
            string ln;
            int handler = 0;

            int tempCups = 0;
            int tempMoves = 0;
            float tempSpeed = 0;
            while((ln = file.ReadLine()) != null){
                if(handler == 0){
                    handler = 1;
                }
                if(handler == 1){
                    ln = file.ReadLine();
                    handler = 2;
                    tempCups = Convert.ToInt32(ln);
                }
                if(handler == 2){
                    ln = file.ReadLine();
                    handler = 3;
                    tempMoves = Convert.ToInt32(ln);
                }
                if(handler == 3){
                    ln = file.ReadLine();
                    handler = 0;
                    tempSpeed = float.Parse(ln, CultureInfo.InvariantCulture.NumberFormat);
                    
                    TrialStruct tempTrial = (new TrialStruct(tempCups, tempMoves, tempSpeed));
                    trialList.Add(tempTrial);
                }

            } 
            file.Close();

        }
    }
    public TrialStruct sendTrial(int i){
        return trialList[i];
    }
}