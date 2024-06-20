using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private string camId;
    [SerializeField] private bool bonnieInside;
    [SerializeField] private bool chicaInside;
    [SerializeField] private bool freddyInside;
    
    private Animator animator;
    public string roomName;
    
    public string CamId
    {
        get => camId;
        set => camId = value;
    }

    public bool BonnieInside
    {
        get => bonnieInside;
        set
        {
            bonnieInside = value;
            animator.SetBool("bonnieInside", value);
            if(roomName != "Office") animator.SetFloat("randomNumber", Random.Range(0,2));
        }
    }
    
    public bool ChicaInside
    {
        get => chicaInside;
        set
        {
            chicaInside = value;
            animator.SetBool("chicaInside", value);
            if(roomName != "Office") animator.SetFloat("randomNumber", Random.Range(0,2));
        }
    }

    public bool FreddyInside
    {
        get => freddyInside;
        set
        {
            freddyInside = value;
            animator.SetBool("freddyInside", value);
        }
    }

    private void Start() 
    {
        animator = GetComponent<Animator>();    
    }

    private void LateUpdate()
    {
        bool animatronicInside = bonnieInside || chicaInside || freddyInside;
        animator.SetBool("animatronicInside",animatronicInside);
    }
    
    
}
