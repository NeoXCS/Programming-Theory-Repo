using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float enemySpeed = 1.0f;
    protected Animator enemyAnim;
    protected Collider enemyCollider;
    protected bool enemyDead = false;
    private AudioSource zombieSoundSource;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = gameObject.GetComponent<Animator>();
        enemyCollider = gameObject.GetComponent<Collider>();
        zombieSoundSource = gameObject.GetComponent<AudioSource>();

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
    if(other.gameObject.CompareTag("Projectile"))
    {
        zombieSoundSource.Play();
        enemyAnim.SetTrigger("Dead");
        Destroy(enemyCollider);
        enemyDead = true;
        MainManager.Instance.score += 1;
        MainManager.Instance.scoreText.text = "Score: " + MainManager.Instance.score;
        StartCoroutine(DeadDisappear());
    }
   }

   IEnumerator DeadDisappear()
   {
    yield return new WaitForSeconds(5);
    Destroy(gameObject);
   }
}
