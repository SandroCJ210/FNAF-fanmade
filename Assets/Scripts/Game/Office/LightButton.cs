using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    [SerializeField] private int id; // 0 is left, 1 is right
    [SerializeField] private Animator officeAnimator;
    [SerializeField] private LightButton otherButton;
    [SerializeField] private Night night;
    private AudioSource audioSource;
    private Animator buttonAnimator;
    private bool isOn;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        buttonAnimator = this.transform.parent.gameObject.GetComponent<Animator>();   
    }

    private void OnMouseDown() 
    {
        ToogleLights();
    }

    private void CheckOtherButton()
    {
        if(otherButton.isOn)
        {
            otherButton.isOn = false;
            otherButton.buttonAnimator.SetBool("isOn", otherButton.isOn);
            otherButton.audioSource.Stop();
        }
        else night.PowerState++;
    }

    private void ToogleLights()
    {
        if(isOn)
        {
            night.PowerState--;
            isOn = false;
            buttonAnimator.SetBool("isOn", isOn);
            officeAnimator.SetBool("isOn", isOn);
            officeAnimator.SetInteger("id", id);
            audioSource.Stop();
        }
        else
        {
            CheckOtherButton();
            isOn = true;
            buttonAnimator.SetBool("isOn", isOn);
            officeAnimator.SetBool("isOn", isOn);
            officeAnimator.SetInteger("id", id);
            audioSource.Play();
            StartCoroutine(DoLightsAnimation(3));
        }
    }

    IEnumerator DoLightsAnimation(float duration)
    {
        int randomNumber;
        while (isOn)
        {
            randomNumber = Random.Range(0, 40);
            officeAnimator.SetFloat("randomNumber", randomNumber);
            if(randomNumber <4) audioSource.Pause();
            else audioSource.UnPause();
            yield return null;
        }
    }
}
