using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour {

    public Text[] AllText;
    public Font PixelFont;
    public Font EasyFont;


    public static bool EasyFontEnabled = false;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ToggleFont()
    {
        //change the font to the opposite
        EasyFontEnabled = !EasyFontEnabled;

        //find ALL texts in the game
        AllText = FindObjectsOfType<Text>();

        if (EasyFontEnabled)
        {
            foreach (Text _Text in AllText)
            {
                _Text.font = EasyFont;
            }
        }

        else
        {
            foreach (Text _Text in AllText)
            {
                _Text.font = PixelFont;
            }
        }
    }
}
