using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
        else
        {
            MainManager.Instance.LoseLife();
            Destroy(other.gameObject);  
        }
    }
    
    
}
