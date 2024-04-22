using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chica : Animatronic
{
    private void Start() 
    {
        waypoints[currentRoom].ChicaInside = true;  
    }

    protected override bool CheckDoorOpen()
    {
        return true;
    }

    protected override void Move()
    {
        
    }
}
