using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LoopTest : MonoBehaviour {

      void Start(){
            MyForLoop();
            MyWhileLoop();
      }

      void MyForLoop(){
            for (int i = 0; i < 100; i++){
                 Debug.Log("The for-loop is now at " + i);
           }
      }

      void MyWhileLoop(){
            int w = 0;
            while (w < 100){
                 Debug.Log("The while-loop is now at " + w);
                 w++;
           }
      }
}