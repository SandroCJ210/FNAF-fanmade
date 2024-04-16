using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    [SerializeField] private Text hourText;
    [SerializeField] private Text nightText;
    [SerializeField] private Text roomNameText;
    [SerializeField] private Text powerLeftText;
    [SerializeField] private Night night;
    [SerializeField] private GameObject kitchenText;
    [SerializeField] private Animator usageAnimator;
    [SerializeField] private Animator changeCameraAnimator;

    private void Start()
    {
        SetUpGame();  
        UpdateNightText();  
    }

    private void SetUpGame()
    {
        if(Instance == null)
        {
            Instance = this;
        }else if (Instance != this) Destroy(gameObject);
    }

    public void UpdateHourText()
    {
        if(night.Hour == 0) hourText.text = "12 AM";
        else  hourText.text = night.Hour.ToString() + " AM";
    }

    public void UpdateNightText()
    {
        nightText.text = "Night " + GameManager.Instance.night.ToString();
    }

    public void UpdateRoomNameText(string roomName)
    {
        if(roomName == "Kitchen") kitchenText.SetActive(true);
        else 
        {
            kitchenText.SetActive(false);
        }
        roomNameText.text = roomName;
    }

    public void UpdateUsage(int powerState)
    {
        usageAnimator.SetFloat("powerState", powerState);
    }

    public void UpdatePowerLeft(float power)
    {
        powerLeftText.text = Mathf.Floor(power).ToString() + "%";
    }

    public void ChangeCameraAnimation()
    {
        changeCameraAnimator.Play("ChangeCamera");
    }
}
