using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DisplayChange : MonoBehaviour {

      public GameObject treeArt;
      public bool isVisible = true;

      void Start(){
           isVisible = false; //new command to disable the object through the bool
      }

      void Update(){
            if (isVisible == true){
                  treeArt.SetActive(true);
            } else {
                  treeArt.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Space)){
                  isVisible = !isVisible;
                  StopCoroutine(DelayTreeAway());
                  StartCoroutine(DelayTreeAway());
            }
      }

      IEnumerator DelayTreeAway(){
           yield return new WaitForSeconds(2f);
           isVisible = false;
      }
}