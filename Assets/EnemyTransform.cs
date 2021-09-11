using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyTransform : MonoBehaviour
{

  public EnemyMove enemymove;


  private void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.tag == "Player")
    {
      enemymove.EnemyTransformPosition();
    }


  }
}
