using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsHandler : MonoBehaviour
{
    int partiePoints;
    // Start is called before the first frame update
    void Start()
    {
        partiePoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.frameCount % 2 == 0)
        {
            FixedThings.bestPoints = (partiePoints > FixedThings.bestPoints) ? partiePoints : FixedThings.bestPoints;

            if (!FixedThings.paused && !FixedThings.prompting)
            {
                StartCoroutine(calculatePoints());
            }
        }

        this.GetComponent<Text>().text = FixedThings.bestPoints.ToString();
    }

    IEnumerator calculatePoints ()
    {
        partiePoints += (GetState.avoided && !GetState.getDamage && GetState.gavePoints) ? 1 : 0;

            GetState.gavePoints = false;

        yield return true;
    }
}
