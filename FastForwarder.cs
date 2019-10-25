using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForwarder : MonoBehaviour {

    public float speedupFUCKTOR = 20f;
    public float slowdownfactor = 0.1f;
    public AudioSource[] audioSources;
    public Animation[] animations;
    public Animation anim;

    public void Awake()
    {
        animations = Object.FindObjectsOfType(typeof(Animation)) as Animation[];
        audioSources = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            DOSpeedup();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            StopSpeedup();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SlowMo();
        }

    }

    void DOSpeedup()
    {
        Time.timeScale = speedupFUCKTOR;
        Time.fixedDeltaTime = .02f * speedupFUCKTOR;
        Debug.Log("Speeding up with a factor of: " + speedupFUCKTOR + "  wow almoste as fast as barry allen!");
        AudioSourceChanger(speedupFUCKTOR);


    }
    
    void StopSpeedup()
    {
       Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        Debug.Log("We have sucsesfully left hyper space! (or super slowmo time... :D)");
        AudioSourceChanger(1f);
    }

    void SlowMo()
    {
        Time.timeScale = slowdownfactor;
        Time.fixedDeltaTime = 0.02f * slowdownfactor;
        Debug.Log("OMG matrix yeas.");
        AudioSourceChanger(slowdownfactor);
    }

    void AudioSourceChanger(float factor)
    {
        int count = 0;
        foreach (AudioSource audio in audioSources)
        {
            AudioSource au = audioSources[count].GetComponent<AudioSource>();           
            au.pitch = factor;
            count++;
        }
    }

    void Rewind()
    {
        
        int count = 0;
        foreach (Animation ani in animations)
        {
            string aniname = animations[count].name;
            Debug.Log(aniname);
            anim = animations[count];
            Debug.Log(anim.name);
            anim[aniname].time = 0.0f;
            count++;
        }
    }
}
