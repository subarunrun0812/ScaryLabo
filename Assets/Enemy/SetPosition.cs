using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
  private Vector3 startPosition;
  //初期位置

  private Vector3 destination;
  //目的地

  void Start()
  {
    startPosition = transform.position;
    SetDestination(transform.position);
    //初期位置を設定
    Debug.Log(startPosition);

  }

  public void CreateRandomPosition()
  //ランダムな位置の作成
  {
    var randDestination = Random.insideUnitCircle * 8;
    //ランダムなVector2の値を得る
    SetDestination(startPosition + new Vector3(randDestination.x, 0, randDestination.y));
    Debug.Log(startPosition);
  }


  public void SetDestination(Vector3 position)
  //目的地を設定する
  {
    destination = position;
  }

  public Vector3 GetDestination()
  //目的地を取得する
  {
    return destination;
  }
}
