using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
  //GameObjectを[]で配列でわけます。
  public GameObject[] gun;
  //int型を変数numberで取得。
  private int number;//int型には整数だけが入る

  void Start()
  {
    //Lengthで変数gunの要素数を取得してiで数を増やします。Length = 数や長さ
    for (int i = 0; i < gun.Length; i++)
    {
      //もしiと変数numberの数が同じだったら。
      if (i == number)
      {
        //正しければ配列欄をSetActiveで表示させます。
        gun[i].SetActive(true);
      }
      else
      {
        //違った場合は表示させません。
        gun[i].SetActive(false);
      }
    }
  }

  void Update()
  {
    //もしマウスボタンの右クリックが押された時の処理。
    if (Input.GetMouseButtonDown(1))
    {
      //変数numberの数はnumber+1割る変数gunの要素数になる。
      number = (number + 1) % gun.Length;
      StartCoroutine("StayChangeWeapon");

    }
  }
  public IEnumerator StayChangeWeapon()
  {
    //for文で条件を付け足し、変数gunの要素数を取得して。
    for (int i = 0; i < gun.Length; i++)
    {
      //変数numberの数とiの数が同じだったら
      if (i == number)
      {
        //セットされたオブジェクトを表示して
        gun[i].SetActive(true);
        yield return new WaitForSeconds(0.4f);


      }
      else
      {

        //セットされたオブジェクトを非表示にします。
        gun[i].SetActive(false);

      }
    }
  }
}
