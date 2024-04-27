using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    [SerializeField] private GameObject lineAnimation;
    [SerializeField] private GameObject staticAnimation;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void EndOfJumpscare()
    {
        audioSource.Stop();
        Instantiate(staticAnimation, Camera.main.transform.position + new Vector3(0,0,10), Quaternion.identity);
        GameObject obj1 = Instantiate(lineAnimation, Camera.main.transform.position + new Vector3(0,0,10), Quaternion.identity);
        Destroy(obj1,3);
    }
}
