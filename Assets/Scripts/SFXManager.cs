using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static AudioClip EnemyDamaged;
    public static AudioClip GunShot;
    public static AudioClip Powerup;
    public static bool muteSfx;

    static AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {
        muteSfx = false;
        EnemyDamaged = Resources.Load<AudioClip>("/Sound/EnemyDamaged");
        GunShot = Resources.Load<AudioClip>("/Sound/GunShot");
        Powerup = Resources.Load<AudioClip>("/Sound/Powerup");

        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case ("EnemyDamaged"):
                if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(EnemyDamaged);
                break;
            case ("GunShot"):
                if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(GunShot);
                break;
            case ("PowerUp"):
                if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(Powerup);
                break;
        }
    }
}