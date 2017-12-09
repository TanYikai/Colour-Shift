using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static AudioClip BGM;
    static AudioSource audioSrc;

    // Use this for initialization
    void Start () {
        BGM = Resources.Load<AudioClip>("Sound/SciFiBGM");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate () {
        if (!audioSrc.isPlaying)
            audioSrc.PlayOneShot(BGM);
        }
}
