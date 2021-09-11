using UnityEngine;
using System.Collections;

public class ItemData : MonoBehaviour
{


  //　アイテムのImage画像
  private Sprite itemSprite;
  //　アイテムの名前
  public string itemName;
  //　アイテムのタイプ



  public ItemData(Sprite image, string itemName)
  {
    this.itemSprite = image;
    this.itemName = itemName;

  }

  public Sprite GetItemSprite()
  {
    return itemSprite;
  }

  public string GetItemName()
  {
    return itemName;
  }

}
