using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freddy : Animatronic
{
    private void Start() 
    {
        waypoints[currentRoom].FreddyInside = true;    
    }

    protected override bool CheckDoorOpen()
    {
        return true;
    }

    protected override void Move()
    {
        
    }
}
