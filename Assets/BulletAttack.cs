using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class BulletAttack : MonoBehaviour
{
  public EnemyMove enemy;

  void Start()
  {
  }
  //　コライダのIsTriggerのチェックを外し物理的な衝突をさせる場合
  // void OnTriggerEnter(Collider col)
  // {
  //   if (col.gameObject.tag == "Enemy")
  //   {
  //     Debug.Log("Navを停止した");
  //     Destroy(gameObject);
  //     Destroy(col.gameObject);
  //     col.GetComponent<NavMeshAgent>().isStopped = true;
  //   }
  // }
}
