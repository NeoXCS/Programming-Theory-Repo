using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    private float zombieSpeed = 2.0f;
   public override void MoveEnemy() //Inheritance
   {
     gameObject.transform.Translate(Vector3.forward * enemySpeed * zombieSpeed * Time.deltaTime); //Polymorphism
   }


}
