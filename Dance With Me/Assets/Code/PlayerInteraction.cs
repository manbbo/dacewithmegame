using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    bool boolState, pressedSomething = false;
    string boolName;
    Animator animator;
    void Start()
    {
        this.boolState = false;
        this.boolName = "";
        this.animator = this.GetComponent<Animator>() as Animator;
    }

    void Update()
    {
        //Debug.Log(boolState);
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            if (boolState)
            {
                if (Time.frameCount%5 == 0)
                setBooltoFalse(boolName);
            }
            else
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isCrouching", false);
            }

            switch(boolName)
            {
                case "isJumping":
                    boolName = "isIdle";
                    break;

                default:

                    break;
            }

            getKeyboardPress();
        }
    }

    // Function to be used by a button
    public void Interact(string boolName) 
    {
        if (!pressedSomething)
        {
            if (!FixedThings.paused && !FixedThings.prompting)
            {
                if (!animator.GetBool(boolName))
                {
                    animator.SetBool(boolName, true);
                    this.boolState = animator.GetBool(boolName);
                    this.boolName = boolName;

                    pressedSomething = true;
                }
            }
        }
    }

    private void getKeyboardPress()
    {
        if (!pressedSomething)
        {
            float jump = Input.GetAxis("Jump"), crouch = Input.GetAxis("Crouch");

            if (jump > 0.0f)
            {
                boolName = "isJumping";
                animator.SetBool(boolName, true);
                this.boolState = animator.GetBool(boolName);

                pressedSomething = true;
            }
            else if (crouch < 0.0f)
            {
                boolName = "isCrouching";
                animator.SetBool(boolName, true);
                this.boolState = animator.GetBool(boolName);

                pressedSomething = true;
            }
        }
    }

    private void setBooltoFalse(string boolName)
    {
        animator.SetBool(boolName, false);
        boolState = false;

        pressedSomething = false;
    }
}
