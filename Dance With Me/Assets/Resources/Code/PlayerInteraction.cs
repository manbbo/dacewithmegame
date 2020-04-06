using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    bool boolState, pressedSomething = false;
    string boolName;
    IEnumerator coroutine;
    Animator animator;
    void Start()
    {
        this.boolState = false;
        this.boolName = "";
        this.animator = this.GetComponent<Animator>() as Animator;
    }

    void Update()
    {
        coroutine = setBooltoFalse(boolName);
        //Debug.Log(boolState);
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            if (pressedSomething)
            {
                StartCoroutine(coroutine);
            } else
            {
                StopCoroutine(coroutine);
            }

            getKeyboardPress();
        }
    }

    // Function to be used by a button
    public void Interact(string boolName)
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            if (!pressedSomething)
            {
                this.boolName = boolName;
                    animator.SetBool(boolName, true);
                    this.boolState = animator.GetBool(boolName);

                    pressedSomething = true;

                    GetState.avoided = true;

                if (this.boolName == "isCrouching")
                {
                    GetState.crouched = true;
                    GetState.jumped = false;
                }
                else if (this.boolName == "isJumping")
                {
                    GetState.crouched = false;
                    GetState.jumped = true;
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

                GetState.avoided = true;
                GetState.crouched = false;
                GetState.jumped = true;
            }
            else if (crouch < 0.0f)
            {
                boolName = "isCrouching";
                animator.SetBool(boolName, true);
                this.boolState = animator.GetBool(boolName);

                pressedSomething = true;

                GetState.avoided = true;
                GetState.crouched = true;
                GetState.jumped = false;
            }
        }
    }

    private IEnumerator setBooltoFalse(string boolName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        {
            animator.SetBool(boolName, false);
            this.boolState = false;
            this.boolName = "";

            if (pressedSomething)
            {
                pressedSomething = false;

                GetState.avoided = false;
                GetState.jumped = false;
                GetState.crouched = false;
            }

            yield return 0;
        }

    }
}
