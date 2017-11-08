using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerScript : MonoBehaviour {

    Rigidbody Rb;
    public float Speed = 5f;

	// Use this for initialization
	void Start ()
    {
        Rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float MovX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        transform.position += new Vector3(MovX, 0, 0);
    }
}
