using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcRoleSuccessChance : MonoBehaviour
{
    public int playerSingStat = 2;
    public int playerDanceStat = 3;
    public int roleSingStat = 5;
    public int roleDanceStat = 0;
    public string roleName;
    private int rngNum;
    // Start is called before the first frame update
    void Start()
    {
        //pick a random num between 0 and 100
        rngNum = Random.Range(0, 101);
        Debug.Log("your RNG num is " + rngNum);
        float singProb = (playerSingStat > roleSingStat) ? 1 : (float) playerSingStat / roleSingStat;
        float danceProb = (playerDanceStat > roleDanceStat) ? 1 : (float) playerDanceStat / roleDanceStat;

        //both your singing stat and your dancing stat are equally weighted
        float percentageChance = singProb * 50 + danceProb * 50;
        Debug.Log("The chance of getting this role is " + percentageChance);

        if (rngNum <= percentageChance) {
            Debug.Log("You got the role!");
        }
        else {
            Debug.Log("You didn't get the role!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver() {
        
    }
}
