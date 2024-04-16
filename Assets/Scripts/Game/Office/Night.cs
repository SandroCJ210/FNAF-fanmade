using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{
    [SerializeField] private int hour;
    [SerializeField] private float hourDuration = 86;
    [SerializeField] private float power = 100;
    [SerializeField] private int timeAdditionalDrain; //time to trigger the additional power penalty
    [SerializeField] private float powerPenalty = 0.1f; //variable power penalty according to the usage bar
    [SerializeField] private int powerState = 1;
    public int PowerState
    {
        get => powerState;
        set
        {
            powerState = value;
            UIManager.Instance.UpdateUsage(powerState);
        }
    }
    public int Hour 
    {
        get => hour;
        private set
        {
            hour = value;
            UIManager.Instance.UpdateHourText();    
        } 
    }
    private void Start()
    {
        CalculateAdditionalDrain();
        StartCoroutine(UpdateNightTime());
        StartCoroutine(PowerDecrease());
    }

    private void CalculateAdditionalDrain()
    {
        if(GameManager.Instance.night < 5) timeAdditionalDrain = 8 - GameManager.Instance.night;
        else timeAdditionalDrain = 3;
    }

    IEnumerator UpdateNightTime()
    {
        while(Hour != 6)
        {
            yield return new WaitForSeconds(hourDuration);
            Hour++;
        }
        GameManager.Instance.Win();
    }

    IEnumerator PowerDecrease()
    {
        while (power > 0)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(powerState * powerPenalty);
            power-= powerState * powerPenalty;
            UIManager.Instance.UpdatePowerLeft(power);
        }
        GameManager.Instance.PowerOver();
    }

    IEnumerator AdditionalDrain()
    {
        while(power > 0)
        {
            if(GameManager.Instance.night == 1) break;
            yield return new WaitForSeconds(timeAdditionalDrain);
            power -= 0.1f;
            UIManager.Instance.UpdatePowerLeft(power);
        }
    }
}
