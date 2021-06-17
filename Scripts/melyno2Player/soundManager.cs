using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    [SerializeField] private static AudioClip enemyHitSound, enemyAttackSound, enemyDeadSound;
    static AudioSource audioSrc;
    void Start()
    {
        enemyDeadSound = Resources.Load<AudioClip>("game_over_05");
        enemyHitSound = Resources.Load<AudioClip>("hit_02");
        enemyAttackSound = Resources.Load<AudioClip>("melee sound");



        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case"attack":
                audioSrc.PlayOneShot(enemyAttackSound);
                break;
            case"dead":
                audioSrc.PlayOneShot(enemyDeadSound);
                break;
            case"hit":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
        }
    }
}
