using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.IO;
using System;

public class TestArray : MonoBehaviour
{
    public TrialArray reference;
    TrialStruct tempTrial;
    List<TrialStruct> test = new List<TrialStruct>();
    string TestName;
    int testSize;
    int check = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        TestName = PlayerPrefs.GetString("testname");
        using(StreamReader file = new StreamReader(Application.dataPath + "\\trialStack.txt")){
        string ln;
        while((ln = file.ReadLine()) != null && check == 0){
            if(ln == TestName){
                ln = file.ReadLine();
                testSize = Convert.ToInt32(ln);
                while(check < testSize){
                    ln = file.ReadLine();
                    int i = Convert.ToInt32(ln);
                    test.Add(reference.sendTrial(i));
                    check++;
                }
            }
        }
        file.Close();
        }
    }
    public TrialStruct sendTrial(int i){
        return test[i];
    }

}

