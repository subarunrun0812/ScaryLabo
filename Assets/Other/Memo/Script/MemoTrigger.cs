using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//メモ用紙のゲームオブジェクトに取り付けるスクリプト
public class MemoTrigger : MonoBehaviour
{
  public GameObject MemoText;
  public GameObject memoButton;//メモを読むかどうか確認するためのUIを設置。画面右下に出る
  public GameObject esc;//閉じるボタン

  // Start is called before the first frame update





  void OnTriggerStay(Collider col)
  {
    Debug.Log("OnTriggerに入った");
    if (col.gameObject.tag == "Player")
    {
      memoButton.SetActive(true);//メモボタンを表示にする
      Debug.Log("PlayerがOnTriggerに入った");
      if (Input.GetKeyDown(KeyCode.E))
      {
        Debug.Log("コマンドEが押された");
        MemoText.gameObject.SetActive(true);//NOT演算を利用。もし0→1、1→0という感じ
        memoButton.SetActive(false);
        esc.SetActive(true);
      }
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        MemoText.gameObject.SetActive(false);
        esc.SetActive(false);
      }

    }
  }
  void OnTriggerExit(Collider col)//Trigger範囲から出たらメモボタンを非表示にする
  {
    if (col.gameObject.tag == "Player")
    {
      MemoText.gameObject.SetActive(false);
      memoButton.SetActive(false);
      Debug.Log("PlayerがOnTriggerから抜けた");
    }
  }
}
