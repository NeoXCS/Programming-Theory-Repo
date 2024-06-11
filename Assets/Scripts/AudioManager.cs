using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]private AudioClip[] zombieSounds;
    private AudioSource zombieSoundSource;
    private bool canPlayZombieSound = false;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForZombieSound());
    }

    // Update is called once per frame
    void Update()
    {
        PlayZombieSound();
    }

    void PlayZombieSound()
    {
        if(canPlayZombieSound)
        {   
            zombieSoundSource = gameObject.GetComponent<AudioSource>();
            int zombieSoundIndex = Random.Range(0, zombieSounds.Length);
            zombieSoundSource.clip = zombieSounds[zombieSoundIndex];
            zombieSoundSource.Play();
            canPlayZombieSound = false;
            StartCoroutine(WaitForZombieSound());
            
        }
    }

    IEnumerator WaitForZombieSound()
    {
        yield return new WaitForSeconds(7);
        canPlayZombieSound = true;
    }
}
