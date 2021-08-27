using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundStarFight : MonoBehaviour
{
    [SerializeField] private AudioSource SoundStartFight;
    void Start()
    {
        SoundStartFight.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
