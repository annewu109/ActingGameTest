using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RandomTest : MonoBehaviour {

      public int rangeStart = 0;
      public int rangeEnd;
      public string[] myPhrases;

       void Start(){
              //assign the length of the array to the end of the random range!
             rangeEnd = myPhrases.Length;
       }

       void Update(){
              //the listener for player input goes in the Update() function
              if (Input.GetKeyDown("r")){
                     RandomMaker();
              }
       }

       public void RandomMaker(){
            //The randomizer code:
            int randomNum = Random.Range(rangeStart, rangeEnd);

            //Display the content of the array at the index of the random number:
            Debug.Log("" + myPhrases[randomNum]);
       }
}