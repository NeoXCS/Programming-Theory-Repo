using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float enemySpeed = 1.0f;
    protected Animator enemyAnim;
    protected Collider enemyCollider;
    protected bool enemyDead = false;
    [SerializeField]private AudioClip[] zombieSounds;
    private AudioSource zombieSoundSource;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = gameObject.GetComponent<Animator>();
        enemyCollider = gameObject.GetComponent<Collider>();
        //zombieSoundSource = gameObject.GetComponent<AudioSource>();
        //int zombieSoundIndex = Random.Range(0, zombieSounds.Length);
        //zombieSoundSource.clip = zombieSounds[zombieSoundIndex];
        //zombieSoundSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(!enemyDead)
        {
            MoveEnemy(); //Abstraction
        }
    }

    public virtual void MoveEnemy()
    {
        gameObject.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

     void OnTriggerEnter(Collider other)
   {
    //Destroy(gameObject);
    enemyAnim.SetTrigger("Dead");
    Destroy(enemyCollider);
    enemyDead = true;
    StartCoroutine(DeadDisappear());
   }

   IEnumerator DeadDisappear()
   {
    yield return new WaitForSeconds(5);
    Destroy(gameObject);
   }
}
