using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CalcRoleSuccessChance : MonoBehaviour
{
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

    public GameObject dialogueObject;
    public Dialogue dialogue;
    public GameObject roleSprite;
    
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

        dialogueObject = GameObject.FindGameObjectWithTag("DialogueManager");
        dialogue = dialogueObject.GetComponent<Dialogue>(); //this is broken
        
        //pick a random num between 0 and 100
        rngNum = Random.Range(0, 101);
        //Debug.Log("your RNG num is " + rngNum);
        float singProb = (GameHandler.singStat > roleSingStat) ? 1 : (float) GameHandler.singStat / roleSingStat;
        float danceProb = (GameHandler.danceStat > roleDanceStat) ? 1 : (float) GameHandler.danceStat / roleDanceStat;

        //both your singing stat and your dancing stat are equally weighted
        percentageChance = singProb * 50 + danceProb * 50;
        //Debug.Log("rngNum: " + rngNum + ", percentageChance: " + percentageChance);
        probabilityText.text = "The chance of getting this role is " + percentageChance.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCardClicked() {
        bool gotRole;
        Debug.Log("rngNum: " + rngNum + ", percentageChance: " + percentageChance);
        if (rngNum <= percentageChance) {
            gotRole = true;
        }
        else {
            gotRole = false;
        }

        GameObject[] allRoleCardsToDespawn;
        allRoleCardsToDespawn = GameObject.FindGameObjectsWithTag("RoleCard");
        foreach (GameObject card in allRoleCardsToDespawn) {
            Destroy(card);
        }

        GameHandler.passedAudition = gotRole;
        dialogueObject.NextLine(); //this is broken
    }
}
