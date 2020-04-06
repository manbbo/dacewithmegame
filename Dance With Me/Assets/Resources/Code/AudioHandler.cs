using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audios/audio" + Random.Range(1, 3));
    }

    // Update is called once per frame
    void Update()
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {

            if (!this.GetComponent<AudioSource>().isPlaying)
            {
                AudioClip audio = Resources.Load<AudioClip>("Audios/audio" + Random.Range(1, 3));
                if (Resources.Load<AudioClip>("Audios/audio" + Random.Range(1, 3)) == this.GetComponent<AudioSource>().clip)
                    audio = Resources.Load<AudioClip>("Audios/audio" + Random.Range(1, 3));
                else if (!Resources.Load<AudioClip>("Audios/audio" + Random.Range(1, 3)) == this.GetComponent<AudioSource>().clip)
                    this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audios/audio" + Random.Range(1, 3));

                this.GetComponent<AudioSource>().Play();
            }
        } else
        {
            this.GetComponent<AudioSource>().Stop();
        }
    }
}
