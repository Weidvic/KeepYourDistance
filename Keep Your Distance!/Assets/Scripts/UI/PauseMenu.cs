using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public Text PageText;

    public GameObject PausePanel;
    public GameObject OptionsPanel;

    public Button Resume;
    public Button Options;
    public Button Quit;

    public Button Back;

    // Use this for initialization
    void Start ()
    {
        PageText.text = "PAUSED";

        PausePanel.SetActive(true);
        OptionsPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnButtonResume()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnButtonOptions()
    {
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void OnButtonQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnButtonBack()
    {
        PausePanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }
}
