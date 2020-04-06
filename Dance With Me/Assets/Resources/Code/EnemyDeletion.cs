using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeletion : MonoBehaviour
{
    public GameObject[] deletor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            foreach (GameObject d in deletor)
            {
                float deletorX = d.transform.position.x, enemyX = this.transform.position.x;
                if (deletorX < 0)
                {
                    if (deletorX >= enemyX)
                    {
                        Destroy(this.gameObject);
                    }
                }
                else if (deletorX > 0)
                {
                    if (deletorX <= enemyX)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
