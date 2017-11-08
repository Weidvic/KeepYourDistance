using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour {

    public Texture2D FadeOutTexture;
    public float FadeSpeed = 0.8f;

    private int DrawDepth = -1000;
    private float alpha = 1.0f;
    private int FadeDir = -1; //-1 = fade in, 1 = fade out

    private void OnGUI()
    {
        alpha += FadeDir * FadeSpeed * Time.deltaTime;

        //force the number between 0 adn 1 because alpha uses balue between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        //set colour of Gui
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        //make sure black texture will render on top
        GUI.depth = DrawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeOutTexture);
    }


    public float BeginFade(int direction)
    {
        FadeDir = direction;

        //return fadespeed variable so its easy to time the scene transition
        return (FadeSpeed);
    }

    private void OnLevelWasLoaded()
    {
        //alpha fade in
        BeginFade(-1);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
