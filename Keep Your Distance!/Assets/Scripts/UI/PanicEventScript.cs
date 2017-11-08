using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicEventScript : MonoBehaviour {

    int Index;

    [Header("Clock Panel Info")]
    public GameObject ClockPanel;

    [Header("Phone Panel Info")]
    public GameObject PhonePanel;
    public Text ClickText;
    public Image Healthbar;
    public Button PhoneButton;
    public float PhoneTimer;
    float CurrentPhoneTime;
    public float Phoneclicks;
    public float CurrentTimeBonus;
    public float AppliedTimeBonus;

    [Header("Deep Breaths Info")]
    public GameObject BreathePanel;

	// Use this for initialization
	void Start ()
    {
        //resetting phone values
        CurrentPhoneTime = PhoneTimer;
        Phoneclicks = 0;
        AppliedTimeBonus = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GameManager.Instance.CurrentTime <= 30)
        {
            FidgetPhone();
        }
    }

    public void CheckClock()
    {
    }



    public void OnPhoneButtonClick()
    {
        Phoneclicks++;
    }

    public void FidgetPhone()
    {
        //Set item active
        PhonePanel.SetActive(true);

        //make healthbar update visually
        CurrentPhoneTime -= Time.deltaTime;
        Healthbar.fillAmount = CurrentPhoneTime / PhoneTimer;

        ClickText.text = Phoneclicks.ToString();

        //manage number of clicks
        if (Phoneclicks >= 10 && Phoneclicks < 20)
        {
            CurrentTimeBonus = 0.5f;

            
        }

        else if (Phoneclicks >= 20 && Phoneclicks < 30)
        {
            CurrentTimeBonus = 1f;


        }

        else if (Phoneclicks >= 30)
        {
            CurrentTimeBonus = 2f;
        }

        else
        {
            AppliedTimeBonus -= 1;
        }

        if (CurrentPhoneTime <= 0)
        {
            OnPhoneDisappear();
            CurrentPhoneTime = 0;
        }
    }

    public void OnPhoneDisappear()
    {
        AppliedTimeBonus = CurrentTimeBonus;

        //add Timebonus to the actual time countdown
        GameManager.Instance.CurrentPanic += AppliedTimeBonus;

        PhonePanel.SetActive(false);

        //resetting all values so console doesnt
        //get spammed the fuck out of
        AppliedTimeBonus = 0;
        CurrentTimeBonus = 0;
        Phoneclicks = 0;
    }


    public void DeepBreaths()
    {

    }
}
