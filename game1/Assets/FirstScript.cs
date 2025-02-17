using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FirstScript : MonoBehaviour {
   public float a = 5f;
   public float b = 3f;
   public bool canDisplay = false;
   public string myName;

   void Start(){
   }

   void Update(){
       if (canDisplay == true){
         Debug.Log("Hey, " + myName + ", a plus b = " + (a+b));
       } else {
         Debug.Log("I will show you nothing!");
       }
    }
}