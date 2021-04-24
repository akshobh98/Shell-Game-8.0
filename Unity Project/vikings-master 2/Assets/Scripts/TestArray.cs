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
    int check;
    
    // Start is called before the first frame update
    void Start()
    {
        TestName = PlayerPrefs.GetString("testname");
        using(StreamReader file = new StreamReader(Application.dataPath + "\\trialStack.txt")){
        string ln;
        while((ln = file.ReadLine()) != null){
            if(ln == TestName){
                ln = file.ReadLine();
                check = 0;
                testSize = Convert.ToInt32(ln);
                PlayerPrefs.SetInt("sizeoftest", testSize);
                while(check < testSize){
                    ln = file.ReadLine();
                    int i = Convert.ToInt32(ln);
                    test.Add(reference.sendTrial(i));
                    check++;
                }
                break;
            }
        }
        //UnityEngine.Debug.Log(testSize + " " + check);
        file.Close();
        }
    }
    public TrialStruct sendTrial(int i){
        return test[i];
    }

}

