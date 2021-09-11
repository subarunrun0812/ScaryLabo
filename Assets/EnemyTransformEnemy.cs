using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransformEnemy : MonoBehaviour
{
  public EnemyMove enemymove;


  private int a = 1;
  private void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.tag == "Player")
    {
      if (a == 1)
      {


        // enemymove.EnemyTransformPositionLibrary();
        a = 0;
      }

    }

  }
}
