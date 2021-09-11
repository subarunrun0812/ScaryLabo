using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GageBoxTrigger : MonoBehaviour
{
  public GameManager gameManager;
  private void OnTriggerStay(Collider col)
  {
    if (col.tag == "Player")
    {
      // gameManager.EnemyRunAudio();
      gameManager.GageBoxArea();
      Debug.Log("GageBoxAreaのtriggerEnterに入った");

    }
  }
  private void OnTriggerExit(Collider col)
  {
    if (col.tag == "Player")
    {
      gameManager.NormalAudio();
    }
  }

}
