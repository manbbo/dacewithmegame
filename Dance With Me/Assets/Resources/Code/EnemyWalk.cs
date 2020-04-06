using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public bool isColliding = false, hasType;
    float goSideWays = 1.0f, goToPlayer;
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        goToPlayer = 0.0f;
        hasType = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            coroutine = GoToPlayer();
            StartCoroutine(coroutine);

            this.transform.Translate(new Vector3(goToPlayer, 0.0f, 0.0f));

            if (isColliding && hasType)
            {
                this.GetComponent<Animator>().SetBool("isWalking", false);
                this.GetComponent<Animator>().SetInteger("atkNumber", Random.Range(0, 1));
            } 
        } else
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator GoToPlayer ()
    {
        goToPlayer = (this.GetComponent<SpriteRenderer>().flipX) ? 2.0f * Time.deltaTime * goSideWays * GetState.speed : 
            -2.0f * Time.deltaTime * goSideWays * GetState.speed;
        
        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            if (collision.gameObject.name.Equals("Player"))
            {
                isColliding = true;
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                goSideWays = 0.0f;

                if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f && isColliding)
                {
                    goSideWays = -1.0f;
                    isColliding = false;
                }
            }
        }
    }
}
