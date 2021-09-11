using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

//メモのテキストに貼り付けるスクリプト
public class MemoText : MonoBehaviour
{

  public GameObject Memo_text;

  public void Memo()
  {
    Memo_text.SetActive(true);
    Time.timeScale = 0;
  }
  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q))
    {
      Debug.Log("Qキーが押された");
      Memo_text.SetActive(false);
      Time.timeScale = 1;
    }
  }


  // Update is called once per frame

}
