using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharSelectScript : MonoBehaviour {


    Color BaseColor;
    public Image IMG;

	// Use this for initialization
	void Start ()
    {
        //BaseColor = this.IMG.color;
	}


    public void OnMouseEnter()
    {
        Debug.Log("Being called");

        IMG.color = new Color(255, 255, 255, 0.5f);
        IMG.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void OnMouseExit()
    {
        IMG.color = BaseColor;
        IMG.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void OnClickSwede()
    {
        //PlayerPrefs save character chosen
        SceneManager.LoadScene("Level 1");

    }
}
