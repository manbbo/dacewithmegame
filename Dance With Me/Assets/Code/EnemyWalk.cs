using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    bool isColliding = false;
    float goSideWays = 1.0f, goToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        goToPlayer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            if (!isColliding)
            {
                StartCoroutine(GoToPlayer());
                this.transform.Translate(new Vector3(goToPlayer, 0.0f, 0.0f));
            }
        } else
        {
            StopAllCoroutines();
        }
    }

    IEnumerator GoToPlayer ()
    {
        goToPlayer = (this.GetComponent<SpriteRenderer>().flipX) ? 2.0f * Time.deltaTime * goSideWays : -2.0f * Time.deltaTime * goSideWays;
        
        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            if (collision.gameObject.name.Equals("Player"))
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                goSideWays = 0.0f;

                if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
                {
                    goSideWays = -1.0f;
                    StopAllCoroutines();
                }
            }
        }
    }
}
