using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class IntoLocker : MonoBehaviour
{
  public GameObject Player;


  [SerializeField]
  Renderer rendererComponent;//色を変えるために宣言
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      Player.transform.DOMove(new Vector3(-3.54f, 1.33f, 8.45f), 1f);//ローカル座標で移動する方向を指定。しかしFPSコントローラーは親なのでワールド座標をしている
      Player.transform.DORotate(Vector3.up * 0f, 1f);//回転する角度（Y軸）
      Debug.Log("ロッカーに入った。");
      this.rendererComponent.material.DOFade(endValue: 0f, duration: 1f);//Rendererを透明にする
    }
  }
}
