using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    bool isColliding = false;
    float goSideWays = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!FixedThings.paused || !FixedThings.prompting)
        {
            if (isColliding)
            {
                StartCoroutine(GoToPlayer());
            }
        } else
        {
            StopAllCoroutines();
        }
    }

    IEnumerator GoToPlayer ()
    {
        float goToPlayer = (this.GetComponent<SpriteRenderer>().flipX) ? -1.0f * Time.deltaTime * goSideWays : 1.0f * Time.deltaTime * goSideWays;
        this.transform.Translate(new Vector3(goToPlayer, 0.0f, 0.0f));
        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!FixedThings.paused || !FixedThings.prompting)
        {
            StopAllCoroutines();
            goSideWays = -1.0f;
        }
    }
}
