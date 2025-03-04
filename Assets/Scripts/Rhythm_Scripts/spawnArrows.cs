using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnArrows : MonoBehaviour
{
    public Transform testHost;
    public static int numSpawned;

    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject holdArrow;  // Assign your hold note prefab here
    public float tempo; 

    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    public Transform spawnPointUp;
    public Transform spawnPointDown;
    int[] arrowPositions;
    int[] singLevelOne = {1, 2, 1, 1, 2, 2, 1, 2, 1, 1, 1, 0, 2, 1, 2, 1, 2, 1, 1, 1, 2, 1, 3};
    int[] danceLevelOne = {1, 1, 1, 1, 2, 2, 1, 1, 2, 1, 2, 1, 2, 1, 1, 1, 2, 3};
    int[] singLevelTwo = {1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 2, 2, 1, 1, 1, 2, 1, 2}; 
    int[] danceLevelTwo = {1, 2, 1, 1, 2, 1, 1, 2, 3, 2, 1, 1, 2, 1, 1, 1, 2, 2, 2, 1, 1, 2, 3};
    int[] singLevelThree = {1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 2, 0, 0, 1, 1, 2, 1, 1, 1, 2, 1, 2, 1, 3, 1, 1, 1, 2, 3, 1, 3};
    int[] danceLevelThree = {1, 1, 2, 2, 1, 1, 1, 1, 1, 2, 1, 1, 0, 3, 2, 1, 2, 1, 2, 1, 2, 1, 3, 3};
    
    public int index;

    public BeatScroller myBS;

    // Start is called before the first frame update
    void Start()
    {
        numSpawned = 0;
        index = 0;
        
        tempo = 0.56f;

        if (GameHandler.level == 0) {
            if (GameHandler.singOrDance == "sing") {
                arrowPositions = singLevelOne;
            } 
            else {
                arrowPositions = danceLevelOne;
            }
       }
       else if (GameHandler.level == 1) {
            if (GameHandler.singOrDance == "sing") {
                arrowPositions = singLevelTwo;
                tempo = 0.52f;
            } 
            else {
                arrowPositions = danceLevelTwo;
                tempo = 0.48f;
            }
       }
       else if (GameHandler.level == 2 ) {
            if (GameHandler.singOrDance == "sing") {
                arrowPositions = singLevelThree;
            } 
            else {
                arrowPositions = danceLevelThree;
                tempo = 0.50f;
            }
       }
    }

    // Update is called once per frame
    void Update()
    {
        if (myBS.hasStarted && index == 0) {
            InvokeRepeating("ArrowSpawnerController", 0f, tempo);
        }
        else if (index == arrowPositions.Length - 1) {
            CancelInvoke();
        }
    }

    public void ArrowSpawnerController() {
        if (index < arrowPositions.Length) {
            int i = arrowPositions[index];

            int random = Random.Range(0, 4);

            if (i == 1) {	
                spawnAnArrow(random);
            }
            else if (i == 2) {
                int random2 = Random.Range(0, 4);
                while (random2 == random) { 
                    random2 = Random.Range(0, 4);
                }
                spawnAnArrow(random);
                spawnAnArrow(random2);
            } 
            else if (i == 3) {
                spawnAnArrow(0);
                spawnAnArrow(1);
                spawnAnArrow(2);
            }
            // For testing, if you want to spawn a hold note, include the value 4 in your pattern array.
            else if (i == 4) {
                spawnAnArrow(4);
            }
        }
        index++;
    }

    public void spawnAnArrow(int i) {
        if (i == 4) {
            // Spawn a hold note – adjust the spawn point if needed.
            Instantiate(holdArrow, spawnPointLeft.position, Quaternion.identity, testHost);
            numSpawned++;
            return;
        }
        if (i == 0) {
            Instantiate(leftArrow, spawnPointLeft.position, Quaternion.Euler(0, 0, 180), testHost);
        }
        if (i == 1){
            Instantiate(rightArrow, spawnPointRight.position, Quaternion.identity, testHost);
        }
        if (i == 2) {
            Instantiate(upArrow, spawnPointUp.position, Quaternion.Euler(0, 0, 90), testHost); 
        }
        if (i == 3) {
            Instantiate(downArrow, spawnPointDown.position, Quaternion.Euler(0, 0, 270), testHost); 
        }
        numSpawned++;
    }
}
