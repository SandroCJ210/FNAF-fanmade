using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animatronic : MonoBehaviour
{
    [SerializeField] private Night night;
    [SerializeField] private float timeMovementOportunity;
    [SerializeField] private int aILevel;
    [SerializeField] private GameObject jumpscare;
    [SerializeField] private GameObject mainCamera;

    [SerializeField] protected Room[] waypoints;
    [SerializeField] protected int currentRoom;

    public int AILevel
    {
        get => aILevel;
        set => aILevel = value;
    }

    protected abstract bool CheckDoorOpen();
	protected abstract void Move();
    
    protected IEnumerator MovementOportunity()
	{
		int randomNumber;
		while(night.Hour != 6)
		{
			yield return new WaitForSeconds(timeMovementOportunity);
            Debug.Log(gameObject.name);
			randomNumber = Random.Range(0,20) + 1;
			if(aILevel > randomNumber) Move();	
            if(currentRoom == 7)
            {
                StartCoroutine(WaitThenAttack());
                break;
            }		
		}
	}

    private IEnumerator WaitThenAttack()
    {
        float time = 0;
        while(time < 30)
        {
            time+= Time.deltaTime;
            if(GameManager.Instance.isCameraUp) yield return null;
            else break;
        }
        GameManager.Instance.gameOver = true;
        UIManager.Instance.HideUI();
        AudioListener.pause = true;
        GameObject js = Instantiate(jumpscare,mainCamera.transform.position + new Vector3(0,0,10), Quaternion.identity);
        Destroy(js, 5);
    }
}
