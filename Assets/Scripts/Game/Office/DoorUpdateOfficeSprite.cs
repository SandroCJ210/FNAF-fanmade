using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUpdateOfficeSprite : MonoBehaviour
{
    [SerializeField] private Animator officeAnimator;
    private Room room;

    private void Start() 
    {
        room = GetComponent<Room>();    
    }

    private void LateUpdate() 
    {
        if(room.roomName == "Left Door") officeAnimator.SetBool("bonnieInside", room.BonnieInside);
        else  officeAnimator.SetBool("chicaInside", room.ChicaInside);
    }
}
