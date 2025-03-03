using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class auditionMusic : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip goodClip;
    public AudioClip badClip;
    // Start is called before the first frame update
    void Start()
    {
        if (GameHandler.passedAudition == true) {
            musicSource.clip = goodClip;
        } else {
            musicSource.clip = badClip;
        }

        musicSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
