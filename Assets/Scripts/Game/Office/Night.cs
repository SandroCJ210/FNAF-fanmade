using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{
    [SerializeField] private float power = 100;
    [SerializeField] private float hourDuration = 86;
    [SerializeField] private float powerPenalty = 0.1f; //variable power penalty according to the usage bar
    [SerializeField] private int timeAdditionalDrain; //time to trigger the additional power penalty   
    [SerializeField] private int powerState = 1;
    [SerializeField] private int hour;
    [SerializeField] private int night;
    
    [SerializeField] private Bonnie bonnie;
    [SerializeField] private Chica chica;
    [SerializeField] private Freddy freddy;
    [SerializeField] private Foxy foxy;

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
        SetInitialAILevels();
        StartCoroutine(UpdateNightTime());
        StartCoroutine(PowerDecrease());
        StartCoroutine(AdditionalDrain());
    }

    private void CalculateAdditionalDrain()
    {
        if(GameManager.Instance.night < 5) timeAdditionalDrain = 8 - GameManager.Instance.night;
        else timeAdditionalDrain = 3;
    }

    private void RaiseAILevel()
    {
        switch(Hour)
        {
            case 2:
                bonnie.AILevel++;
                break;
            case 3:
                bonnie.AILevel++;
                chica.AILevel++;
                foxy.AILevel++;
                break;
            case 4:
                bonnie.AILevel++;
                chica.AILevel++;
                foxy.AILevel++;
                break;
        }
    }

    private void SetInitialAILevels()
    {
        switch(GameManager.Instance.night)
        {
            case 1:
                bonnie.AILevel = 0;
                chica.AILevel = 0;
                foxy.AILevel = 0;
                freddy.AILevel = 0;
                break;
            case 2:
                bonnie.AILevel = 3;
                chica.AILevel = 1;
                foxy.AILevel = 1;
                freddy.AILevel = 0;
                break;
            case 3:
                bonnie.AILevel = 0;
                chica.AILevel = 5;
                foxy.AILevel = 2;
                freddy.AILevel = 1;
                break;
            case 4:
                bonnie.AILevel = 2;
                chica.AILevel = 4;
                foxy.AILevel = 6;
                freddy.AILevel = Random.Range(0,2) + 1;
                break;
            case 5:
                bonnie.AILevel = 5;
                chica.AILevel = 7;
                foxy.AILevel = 5;
                freddy.AILevel = 3;
                break;
            case 6: 
                bonnie.AILevel = 10;
                chica.AILevel = 12;
                foxy.AILevel = 16;
                freddy.AILevel = 4;
                break;
        }
    }

    IEnumerator UpdateNightTime()
    {
        while(Hour != 6)
        {
            yield return new WaitForSeconds(hourDuration);
            Hour++;
            RaiseAILevel();
        }
        GameManager.Instance.Win();
    }

    IEnumerator PowerDecrease()
    {
        while (power > 0)
        {
            yield return new WaitForSeconds(1);
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
