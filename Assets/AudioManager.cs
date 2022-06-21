using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clipBoing;
    public AudioClip clipDerrota;
    public AudioClip clipVictoria;
    public AudioClip clipDerrotaFinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClipBoing()
    {
        source.clip = clipBoing;
        source.Play();
    }

    public void playClipDerrota()
    {
        source.clip = clipDerrota;
        source.Play();
    }

    public void playClipVictoria()
    {
        source.clip = clipVictoria;
        source.Play();
    }

    public void playClipDerrotaFinal()
    {
        source.clip = clipDerrotaFinal;
        source.Play();
    }
}
