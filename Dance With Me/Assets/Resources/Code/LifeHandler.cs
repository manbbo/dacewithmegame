using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHandler : MonoBehaviour
{
    public GameObject gameOver, lifeObject, menuToGetTransform;
    private List<GameObject> listLifeObject;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        GetState.gameOver = false;
        FixedThings.paused = false;
        GetState.life = 3;

        listLifeObject = new List<GameObject>();

        for (int i = 0; i < GetState.life; i++)
        {
            GameObject life = Instantiate(lifeObject, Vector3.zero, lifeObject.transform.rotation);
            listLifeObject.Add(life);

            life.SetActive(true);
            life.GetComponent<RectTransform>().sizeDelta = new Vector3(2.5f, 2.5f, 2.5f);
            life.transform.parent = menuToGetTransform.transform;
            life.transform.position = new Vector3(-7.9f + (1.20f * i), -4.12f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!FixedThings.paused && !FixedThings.prompting)
        {
            if (GetState.getDamage)
            {
                if (Time.frameCount % 2 == 0)
                {
                    GetState.life--;
                    Destroy(listLifeObject[GetState.life]);
                }

                if (GetState.life <= 0)
                    GetState.gameOver = true;

            }

            if (GetState.gameOver)
            {
                gameOver.SetActive(true);
                FixedThings.paused = true;
            }
        }
    }
}
