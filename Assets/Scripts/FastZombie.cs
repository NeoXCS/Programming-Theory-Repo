using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombie : Enemy
{
     private float fastZombieSpeed = 5.0f;
   public override void MoveEnemy() //inheritance
   {
     gameObject.transform.Translate(Vector3.forward * enemySpeed * fastZombieSpeed * Time.deltaTime); //polymorphism
   }

}
