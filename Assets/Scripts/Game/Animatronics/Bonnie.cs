using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonnie : Animatronic
{
    [SerializeField] private DoorButton doorButton;
    private AudioSource audioSource;
    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MovementOportunity());    
        waypoints[currentRoom].BonnieInside = true;
    }

    protected override bool CheckDoorOpen()
    {
        return doorButton.IsOpen;
    }

    protected override void Move()
    {
        int randomNumber;
        waypoints[currentRoom].BonnieInside = false;
        switch(currentRoom)
        {
            case 2:
                randomNumber = Random.Range(0,3);
                currentRoom = randomNumber < 1? 1 : 3;
                break;
            case 4:
                randomNumber = Random.Range(0,3);
                currentRoom = randomNumber < 1? 3 : 6;
                break;
            case 5:
                randomNumber = Random.Range(0,3);
                currentRoom = randomNumber < 1? 4 : 6;
                break;
            case 6:
                currentRoom = CheckDoorOpen()? 7 : 1;
                break;
            default:
                randomNumber = Random.Range(0,2) + 1;
                currentRoom += randomNumber;
                break;
        }
        audioSource.Play();
        waypoints[currentRoom].BonnieInside = true;
    }
}
