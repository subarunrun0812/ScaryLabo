using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{

  public GameObject cube;
  void Start()
  {
    cube.transform.DOMove(new Vector3(-3.6f, 1.1f, 8.49f), 2f);//ローカル座標で移動する方向を指定。しかしFPSコントローラーは親なのでワールド座標をしている
    cube.transform.DORotate(Vector3.up * 0f, 2f);//回転する角度（Y軸）
  }
}
