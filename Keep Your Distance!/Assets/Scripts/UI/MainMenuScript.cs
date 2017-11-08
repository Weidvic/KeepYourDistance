using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    [SerializeField]
    public Button Play;
    [SerializeField]
    public Button Quit;

    public void ButtonPlay()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
