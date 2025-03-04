using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour {

    public bool canBePressed;
    // Add a flag to indicate if the note has been hit already
    private bool hasBeenHit = false;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    // For hold note functionality
    public bool isHoldNote = false;          // Set this flag on hold note prefabs
    public float requiredHoldTime = 1.0f;      // How long the key must be held (in seconds)
    private float holdTimer = 0f;
    private bool holdStarted = false;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if(isHoldNote) {
            // --- Hold Note Logic ---
            if(canBePressed && !holdStarted && Input.GetKeyDown(keyToPress)) {
                holdStarted = true;
            }
            if(holdStarted) {
                if(Input.GetKey(keyToPress)) {
                    holdTimer += Time.deltaTime;
                }
                if(Input.GetKeyUp(keyToPress)) {
                    if(holdTimer >= requiredHoldTime) {
                        Debug.Log("Hold Note Perfect");
                        GameManager.instance.PerfectHit(); // Optionally, create a separate hold method
                        Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    } else {
                        Debug.Log("Hold Note Missed");
                        GameManager.instance.NoteMissed();
                        Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                    }
                    hasBeenHit = true;
                    gameObject.SetActive(false);
                    holdStarted = false;
                    holdTimer = 0f;
                }
            }
        } else {
            // --- Normal Note Logic ---
            if(Input.GetKeyDown(keyToPress)) {
                if(canBePressed && !hasBeenHit) {
                    hasBeenHit = true;
                    gameObject.SetActive(false);

                    float absY = Mathf.Abs(transform.position.y);
                    if(absY > 0.25f) {
                        Debug.Log("Hit");
                        GameManager.instance.NormalHit();
                        Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    } 
                    else if(absY > 0.05f) {
                        Debug.Log("Good");
                        GameManager.instance.GoodHit();
                        Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    } 
                    else {
                        Debug.Log("Perfect");
                        GameManager.instance.PerfectHit();
                        Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Activator") {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Activator") {
            canBePressed = false;
            // Only register a miss if the note wasn't hit already.
            if(!hasBeenHit) {
                // For hold notes: if the player never started holding, it's a miss.
                if(isHoldNote && !holdStarted) {
                    GameManager.instance.NoteMissed();
                    Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                }
                else if(!isHoldNote) {
                    GameManager.instance.NoteMissed();
                    Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                }
            }
        }
    }
}
