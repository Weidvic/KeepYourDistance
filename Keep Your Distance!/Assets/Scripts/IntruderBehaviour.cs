using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntruderBehaviour : MonoBehaviour {

    public float speed;
    public float RotX;
    public Animator Anim;

    public static bool HasReachedDestination = false;

    private Transform Target;
    private int NodeIndex = 0;

	void Start ()
    {
        //make our target the first item in the array
        Target = NodeScript.Nodes[0];
        //tell character to start animating
        Anim.SetTrigger("StartWalking");
	}
	
	void Update ()
    {
        //gives us a direction vector
        Vector3 Dir = Target.position - transform.position;

        //move character towards target with desired speed
        transform.Translate(Dir.normalized * speed * Time.deltaTime, Space.World);

        //if we are closer than 0.2 units to the nodes
        if(Vector3.Distance(transform.position, Target.position) < 0.2f)
        {
            GetNextNode();
        }
	}

    //functionality for moving onto next node
    void GetNextNode()
    {
        if(NodeIndex >= NodeScript.Nodes.Length - 1)
        {
            //when we've reached our final node
            //destroy our nodes and rotate the character
            transform.Rotate(new Vector3(0f, RotX, 0f));

            Anim.SetTrigger("StopWalking");

            Destroy(this);

            //Send message to GameManager to start the countdown
            HasReachedDestination = true;

            Debug.Log("Destination Reached");
            return;
        }

        NodeIndex++;
        Target = NodeScript.Nodes[NodeIndex];
    }
}
