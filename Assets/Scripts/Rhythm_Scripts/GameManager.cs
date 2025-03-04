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

    // Fever Mode variables
    public bool inFeverMode = false;
    public int perfectComboCount = 0;    // consecutive perfect hits counter
    public int feverThreshold = 5;       // number of perfects needed to trigger fever mode
    public float feverDuration = 5f;     // duration in seconds for fever mode
    private float feverTimer = 0f;
    public ParticleSystem feverEffect;   // assign a particle system in the inspector for visual flair
    public int feverMultiplier = 2;      // extra score multiplier during fever mode

    // Use this for initialization
    void Start () {
        instance = this;
        // theMusic = GetComponent<AudioSource>(); // Uncomment if needed
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
                // theMusic.volume = 5f; // check that this isn't static
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

        // Fever Mode timer update
        if (inFeverMode) {
            feverTimer -= Time.deltaTime;
            if (feverTimer <= 0f) {
                inFeverMode = false;
                perfectComboCount = 0;  // reset the combo counter after fever ends
                if (feverEffect != null) {
                    feverEffect.Stop();
                }
                // Update multiplier display back to normal when fever ends
                multiText.text = "Multiplier: x" + currentMultiplier;
                Debug.Log("Fever Mode Ended.");
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

        // Display effective multiplier when fever mode is active
        if (inFeverMode) {
            multiText.text = "Multiplier: x" + (currentMultiplier * feverMultiplier) + " (Fever)";
        } else {
            multiText.text = "Multiplier: x" + currentMultiplier;
        }
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit() {
        int scoreToAdd = scorePerNote * currentMultiplier;
        if (inFeverMode) {
            scoreToAdd *= feverMultiplier;
        }
        currentScore += scoreToAdd;
        NoteHit();
        normalHits++;

        // Reset perfect combo because the hit wasn’t perfect
        perfectComboCount = 0;
    }

    public void GoodHit() {
        int scoreToAdd = scorePerGoodNote * currentMultiplier;
        if (inFeverMode) {
            scoreToAdd *= feverMultiplier;
        }
        currentScore += scoreToAdd;
        NoteHit();
        goodHits++;

        // Reset perfect combo because the hit wasn’t perfect
        perfectComboCount = 0;
    }

    public void PerfectHit() {
        int scoreToAdd = scorePerPerfectNote * currentMultiplier;
        if (inFeverMode) {
            scoreToAdd *= feverMultiplier;
        }
        currentScore += scoreToAdd;
        NoteHit();
        perfectHits++;

        // Increase perfect combo counter
        perfectComboCount++;

        // Trigger Fever Mode if threshold is reached
        if (!inFeverMode && perfectComboCount >= feverThreshold) {
            ActivateFeverMode();
        }
    }

    public void NoteMissed() {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
        missedHits++;

        // Reset perfect combo count on miss
        perfectComboCount = 0;
    }

    void ActivateFeverMode() {
        inFeverMode = true;
        feverTimer = feverDuration;
        if (feverEffect != null) {
            feverEffect.Play();
        }
        // Immediately update the multiplier display to show the effective fever multiplier
        multiText.text = "Multiplier: x" + (currentMultiplier * feverMultiplier) + " (Fever)";
        Debug.Log("Fever Mode Activated!");
    }
}
