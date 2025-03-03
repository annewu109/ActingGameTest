using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour {

    public float beatTempo;
    public Transform buttonPos;
    public bool hasStarted;

    // Use this for initialization
    void Start () {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update () {

        if(!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }

        if (GameManager.gameOver) {
            Destroy(gameObject);
        }



    }
}
