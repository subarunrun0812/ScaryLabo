using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "Player")
    {
      Debug.Log("Enemyがplayerと衝突した");
    }
  }
}
