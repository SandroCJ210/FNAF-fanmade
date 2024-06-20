using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : Room
{
    private AudioSource audioSource;
    public override bool ChicaInside
    {
        get => chicaInside;
        set
        {
            chicaInside = value;
            audioSource.Play();
        }
    }

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
}
