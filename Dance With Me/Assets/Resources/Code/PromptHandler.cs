using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptHandler : MonoBehaviour
{
    public GameObject prompt;
    // Start is called before the first frame update
    void Start()
    {
        if (!FixedThings.firstTime)
        {
            FixedThings.paused = false;
            FixedThings.prompting = false;
            prompt.SetActive(false);
        }

        FixedThings.firstTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
