using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScreenWait : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;
    private void Start() 
    {
        StartCoroutine(WaitForStaticToFinish());    
    }
    IEnumerator WaitForStaticToFinish()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        Instantiate(blackScreen, transform.position, Quaternion.identity);
        GameManager.Instance.StartNight();
    }
}
