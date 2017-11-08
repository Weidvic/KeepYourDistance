using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Animator Anim;
    public GameObject SweatParticle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(IntruderBehaviour.HasReachedDestination == true)
        {
            ActivateStress();
        }

        if(GameManager.Instance.GameOver == true)
        {
            DisableStress();
        }
    }

    void ActivateStress()
    {
        SweatParticle.SetActive(true);
        Anim.SetBool("DoStress", true);
    }

    void DisableStress()
    {
        SweatParticle.SetActive(false);
        Anim.SetBool("DoStress", false);
    }
}
