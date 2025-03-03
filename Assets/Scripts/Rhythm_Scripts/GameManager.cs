using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public AudioSource theMusic;
    public AudioClip vocalClipOne;
    public AudioClip danceClipOne;
    public AudioClip vocalClipTwo;
    public AudioClip danceClipTwo;
    public AudioClip vocalClipThree;
    public AudioClip danceClipThree;


    public bool startPlaying = false;

    public BeatScroller theBS;

    public static GameManager instance;

    public GameHandler gh;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public Button continueButton;
    public GameObject startScreen;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;
    public static bool gameOver;

    // Use this for initialization
    void Start () {
        instance = this;
        // theMusic = GetComponent<AudioSource>(); <=?should this be uncommented? forgot
        // Set the correct audio clip based on the chosen mode.
       
       if (GameHandler.level == 0) {
            if (GameHandler.singOrDance == "sing") {
                theMusic.clip = vocalClipOne;
            } 
            else {
                theMusic.clip = danceClipOne;
            }
       }
       else if (GameHandler.level == 1) {
            if (GameHandler.singOrDance == "sing") {
                theMusic.clip = vocalClipTwo;
            } 
            else {
                theMusic.clip = danceClipTwo;
            }
       }
       else if (GameHandler.level == 2 ) {
            if (GameHandler.singOrDance == "sing") {
                theMusic.clip = vocalClipThree;
            } 
            else {
                theMusic.clip = danceClipThree;
            }
       }
       else {
        print("level error");
       }
        

        gameOver = false;


        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        // totalNotes = FindObjectsOfType<NoteObject>().Length;

        continueButton.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        if (!startPlaying) {
            if (Input.anyKeyDown) {
                startScreen.gameObject.SetActive(false);
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        } else {
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy) {
                resultsScreen.SetActive(true);


                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = "" + missedHits;

                totalNotes = spawnArrows.numSpawned;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if (percentHit > 40) {
                    rankVal = "D";
                    if (percentHit > 55) {
                        rankVal = "C";
                        if (percentHit > 70) {
                            rankVal = "B";
                            if (percentHit > 85) {
                                rankVal = "A";
                                if (percentHit > 95) {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();

                gh.calcStatGain(currentScore, GameHandler.singOrDance);
                gameOver = true;
                continueButton.gameObject.SetActive(true);
            }
        }
    }

    public void NoteHit() {
        Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length) {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker) {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit() {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;
    }

    public void GoodHit() {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit() {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed() {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
        missedHits++;
    }
}
