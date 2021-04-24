// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CubeColor : MonoBehaviour{

//     public Color myColor;
//     public float aFloat;
//     public float rFloat;
//     public float gFloat;
//     //0 to 1

//     public Renderer myRenderer; 

//     // Start is called before the first frame update
//     void Start(){
//         aFloat = 1;
//         myRenderer = gameObject.GetComponent<myRenderer>();
//     }

//     // Update is called once per frame
//     void Update(){
//         if(Input.GetKey(KeyCode.A)){
//             if(aFloat < 1){
//                 aFloat += 0.01f;
//             }
//             else{
//                 aFloat = 0;
//             }
//         }
//         if(Input.GetKey(KeyCode.R)){
//             if(rFloat < 1){
//                 rFloat += 0.01f;
//             }
//             else{
//                 rFloat = 0;
//             }
//         }
//         if(Input.GetKey(KeyCode.G)){
//             if(gFloat < 1){
//                 gFloat += 0.01f;
//             }
//             else{
//                 gFloat = 0;
//             }
//         }
//         myColor = new Color(rFloat, gFloat, aFloat);
//         myRenderer.material.color = myColor;
//     }
// }
