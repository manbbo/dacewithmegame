using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool hasType;
    private bool hasTouched;
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        hasTouched = false;

        this.GetComponent<Animator>().SetInteger("atkNumber", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            coroutine = makeTheAttack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            if (collision.gameObject.name.Equals("Player") && !hasTouched)
            {
                this.GetComponent<EnemyWalk>().isColliding = true;
                this.GetComponent<EnemyWalk>().hasType = hasType;
                StartCoroutine(coroutine);
                
                hasTouched = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            if (collision.gameObject.name.Equals("Player") && !hasTouched)
            {
                hasTouched = false;
            }
        }
    }

    private IEnumerator makeTheAttack()
    {
        //if (Time.frameCount % 2 == 0)
        {
            //if (!hasTouched)
            {
                if (!GetState.avoided)
                {
                    if (Time.frameCount % 2 == 0)
                    {
                        GetState.getDamage = true;
                        GetState.gavePoints = false;
                    }

                    yield return 1;
                }
                else
                {
                    if (hasType && !GetState.jumped)
                    {
                            GetState.getDamage = true;
                            GetState.gavePoints = false;
                            yield return 2;
                        
                    } else if (!hasType && !GetState.crouched)
                    {
                        GetState.getDamage = true;
                        GetState.gavePoints = false;
                        yield return 3;
                    }
                    else
                    {
                        GetState.getDamage = false;
                        GetState.gavePoints = true;
                        yield return 4;
                    }
                }
            }

            hasTouched = true;
            //GetState.getDamage = (GetState.getDamage) ? false : true;

            this.GetComponent<EnemyWalk>().isColliding = false;


            GetState.getDamage = false;
            GetState.gavePoints = false;

            yield return 5;
        }
    }
}
