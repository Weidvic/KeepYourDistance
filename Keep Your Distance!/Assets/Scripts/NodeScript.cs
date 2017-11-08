using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour {

    public static Transform[] Nodes;


	void Awake ()
    {
        Nodes = new Transform[transform.childCount];

        for (int i = 0; i < Nodes.Length; i++)
        {
            //for every child object on this transform,
            //push that index into the slot of the array
            Nodes[i] = transform.GetChild(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
