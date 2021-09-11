using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTutorial : MonoBehaviour
{

  public GameObject enemy;

  private int a;

  void Start()
  {
    enemy.SetActive(false);
    a = 0;
  }
  void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.tag == "Player")
    {
      if (a == 0)
      {
        a = 1;
        enemy.SetActive(true);
      }
    }
  }

}
