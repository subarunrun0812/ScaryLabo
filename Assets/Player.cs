using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  public enum KeyType
  {
    病室,
    研究室,
    MRI検査室,
    地下室へ,
    準備室,

  };

  public List<KeyType> keylist = new List<KeyType>();//アイテムを持っているか管理する


  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void onPickUp(KeyType keyType)
  {
    keylist.Add(keyType);
  }
}
