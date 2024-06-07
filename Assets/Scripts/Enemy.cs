using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float enemySpeed = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy(); //Abstraction
    }

    public virtual void MoveEnemy()
    {
        gameObject.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }
}
