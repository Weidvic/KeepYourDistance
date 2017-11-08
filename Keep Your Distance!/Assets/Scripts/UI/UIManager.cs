using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(this);
        }

    }

    public Button Keepcalm;
    public Button OnSwedeClick;
    public GameObject KeepCalmPanel;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if(IntruderBehaviour.HasReachedDestination == true)
        {
            KeepCalmPanel.SetActive(true);
        }

        else if(GameManager.Instance.CurrentPanic <= 0)
        {
            KeepCalmPanel.SetActive(false);
        }
	}

    public void OnKeepCalm()
    {
        GameManager.Instance.CurrentPanic += 0.5f;
    }

    public void OnClickSwede()
    {
        //PlayerPrefs save character chosen
        SceneManager.LoadScene("Level 1");

    }
}
