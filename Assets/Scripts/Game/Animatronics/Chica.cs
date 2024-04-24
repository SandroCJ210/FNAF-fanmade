using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chica : Animatronic
{
    [SerializeField] private DoorButton doorButton;
    private void Start()
    {
        StartCoroutine(MovementOportunity());
        waypoints[currentRoom].ChicaInside = true;  
    }

    protected override bool CheckDoorOpen()
    {
        return doorButton.IsOpen;
    }

    protected override void Move()
    {
        int randomNumber;
        waypoints[currentRoom].ChicaInside = false;
        switch (currentRoom)
        {
            case 1:
                currentRoom++;
                break;
            default:
                randomNumber = Random.Range(0,2) + 1;
                currentRoom += randomNumber;
                break;
                
        }
        waypoints[currentRoom].ChicaInside = true;
    }
}
