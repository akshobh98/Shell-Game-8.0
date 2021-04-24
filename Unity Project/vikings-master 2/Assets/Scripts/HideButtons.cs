using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideButtons : MonoBehaviour
{
    public Button myButton1;
    public Button myButton2;
    public Button myButton3;
    public Button myButton4;
    public Button myButton5;
    public Button myButton6;
    public Button myButton7;
    public Button myButton8;
    public Button myButton9;

    public Text correct;
    public Text incorrect;


    // Start is called before the first frame update
    void Start()
    {
        myButton1.gameObject.SetActive(false);
        myButton2.gameObject.SetActive(false);
        myButton3.gameObject.SetActive(false);
        myButton4.gameObject.SetActive(false);
        myButton5.gameObject.SetActive(false);
        myButton6.gameObject.SetActive(false);
        myButton7.gameObject.SetActive(false);
        myButton8.gameObject.SetActive(false);
        myButton9.gameObject.SetActive(false);
        
        correct.gameObject.SetActive(false);
        incorrect.gameObject.SetActive(false);

    }
}
