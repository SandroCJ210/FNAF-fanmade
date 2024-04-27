using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chica : Animatronic
{
    [SerializeField] private DoorButton doorButton;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            case 0:
                currentRoom++;
                break;
            case 3:
                randomNumber = Random.Range(0, 2);
                currentRoom = randomNumber == 1? 2 : 4;
                break;
            case 4:
                randomNumber = Random.Range(0, 3);
                currentRoom = randomNumber < 1? 1 : 5;
                break;
            case 5:
                randomNumber = Random.Range(0, 3);
                currentRoom = randomNumber < 1? 4 : 6;
                break;
            case 6:
                currentRoom = CheckDoorOpen()? 7 : 4;
                break;
            default:
                randomNumber = Random.Range(0,2) + 1;
                currentRoom += randomNumber;
                break;
                
        }
        audioSource.Play();
        waypoints[currentRoom].ChicaInside = true;
    }
}
