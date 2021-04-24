using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public void changeMenuScene(string scenename){
        Application.LoadLevel(scenename);
    }
    
}
