using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
   private float horizontalInput;
   [SerializeField] private float speed = 25.0f;
   [SerializeField] private float xRange = 25.0f;
   [SerializeField] private GameObject projectilePrefab;
   private bool canShoot = true;
   private Animator playerAnim;
   
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }

        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }


        PlayerMove(); //abstraction
    }

    void PlayerMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed* Time.deltaTime);
    }

    void Shoot()
    {
        if(canShoot)
        {
            Vector3 projectileSpawn = new Vector3(transform.position.x + 0.9f, projectilePrefab.transform.position.y, projectilePrefab.transform.position.z);
        
            Instantiate(projectilePrefab, projectileSpawn, projectilePrefab.transform.rotation);

            playerAnim.SetTrigger("Shoot");

            canShoot = false;

            StartCoroutine(ShootDelay());
        }
        

    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(0.8f);
        canShoot = true;
    }
}
