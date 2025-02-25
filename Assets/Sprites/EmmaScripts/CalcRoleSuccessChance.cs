using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CalcRoleSuccessChance : MonoBehaviour
{
    public int playerSingStat = 2;
    public int playerDanceStat = 3;
    public int roleSingStat = 5;
    public int roleDanceStat = 0;
    public int showPoints = 10;
    public Sprite mySprite;
    public string roleName;
    public TextMeshProUGUI danceStatDisplay;
    public TextMeshProUGUI singStatDisplay;
    public TextMeshProUGUI showPtDisplay;
    public TextMeshProUGUI roleNameDisplay;
    public TextMeshProUGUI probabilityText;
    public TextMeshProUGUI gotRoleText;
    public GameObject roleSprite;

    public bool gotRole;
    
    
    
    private int rngNum;
    private float percentageChance;
    // Start is called before the first frame update
    void Start()
    {
        danceStatDisplay.text = roleDanceStat.ToString();
        singStatDisplay.text = roleSingStat.ToString();
        showPtDisplay.text = showPoints.ToString();
        roleNameDisplay.text = roleName;
        roleSprite.GetComponent<Image>().sprite = mySprite;
        gotRoleText = GameObject.FindGameObjectWithTag("RoleText").GetComponent<TextMeshProUGUI>();

        gotRoleText.text = "Role Text Detected!";
        
        //pick a random num between 0 and 100
        rngNum = Random.Range(0, 101);
        Debug.Log("your RNG num is " + rngNum);
        float singProb = (playerSingStat > roleSingStat) ? 1 : (float) playerSingStat / roleSingStat;
        float danceProb = (playerDanceStat > roleDanceStat) ? 1 : (float) playerDanceStat / roleDanceStat;

        //both your singing stat and your dancing stat are equally weighted
        percentageChance = singProb * 50 + danceProb * 50;
        Debug.Log("rngNum: " + rngNum + ", percentageChance: " + percentageChance);
        probabilityText.text = "The chance of getting this role is " + percentageChance.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCardClicked() {
        Debug.Log("rngNum: " + rngNum + ", percentageChance: " + percentageChance);
        if (rngNum <= percentageChance) {
            gotRoleText.text = "You got the role!";
            gotRole = true;
        }
        else {
            gotRoleText.text = "You didn't get the role!";
            gotRole = false;
        }
    }
}
