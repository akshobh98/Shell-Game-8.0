using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGameButtons : MonoBehaviour
{   
    public Button trial;

    // Start is called before the first frame update
    void Start()
    {
        trial.gameObject.SetActive(false);
    }

}
