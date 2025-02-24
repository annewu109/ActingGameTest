using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour {

    public bool canBePressed;
    // Add a flag to indicate if the note has been hit already
    private bool hasBeenHit = false;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed && !hasBeenHit)
            {
                // Mark note as hit so that we don't register a miss later.
                hasBeenHit = true;
                gameObject.SetActive(false);

                // Determine timing and trigger the appropriate hit
                float absY = Mathf.Abs(transform.position.y);
                if(absY > 0.25f)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                } 
                else if(absY > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                } 
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;
            // Only register a miss if the note wasn't hit already.
            if(!hasBeenHit)
            {
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
