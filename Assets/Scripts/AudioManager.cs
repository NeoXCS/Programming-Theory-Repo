using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]private AudioClip[] zombieSounds;
    private AudioSource zombieSoundSource;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForZombieSound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayZombieSound()
    {
            zombieSoundSource = gameObject.GetComponent<AudioSource>();
            int zombieSoundIndex = Random.Range(0, zombieSounds.Length);
            zombieSoundSource.clip = zombieSounds[zombieSoundIndex];
            zombieSoundSource.Play();
    }

    IEnumerator WaitForZombieSound()
    {
        while(true)
        {
            yield return new WaitForSeconds(7);
            PlayZombieSound();
        }
    }
}
