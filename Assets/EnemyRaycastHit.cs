using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRaycastHit : MonoBehaviour
{

  Ray ray;
  RaycastHit hit;//ヒットしたオブジェクト情報




  private void Update()
  {
    //レイの設定
    ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

    //レイキャスト（原点、飛ばす方向、衝突した情報、長さ）
    if (Physics.Raycast(ray, out hit, 4f))
    {
      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
      if (hit.transform.gameObject.tag == "KeyDoor")
      {
        hit.transform.gameObject.GetComponent<KeyDoor>().OpenDoorEnemy();
      }
      if (hit.transform.gameObject.tag == "KeyDoorEnemy")
      {
        hit.transform.gameObject.GetComponent<KeyDoorEnemy>().OpenDoorEnemy();
      }
    }
  }

}
