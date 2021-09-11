using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Key : MonoBehaviour
{
  [SerializeField] public Player.KeyType keyType;//Inspecterからキーを選択できるメニューを作成
  [SerializeField] private Player player;

  public GameObject canvasAim;//標準があったら赤色になる

  public Text keytext;


  public void GetKey()//鍵を入手するときに呼ばれる関数
  {
    player.onPickUp(keyType);
    Debug.Log(keyType + "の鍵を入手した");
    StartCoroutine("Keyname");
  }

  IEnumerator Keyname()
  {
    keytext.text = keyType + "の鍵を入手した";
    Debug.Log("3秒" + keytext.text + "を表示する");
    GetComponent<BoxCollider>().enabled = false;
    GetComponent<MeshRenderer>().enabled = false;
    // gameObject.SetActive(false);
    yield return new WaitForSeconds(3);//3秒テキストを表示
    keytext.text = "";
    Debug.Log(keytext.text + "を表示した");
  }
  /*
    void Update()
    {
      ////ビューポート座標は左下を(x, y, z)= (0,0,1)として、右上(x, y, z)= (1,1,1)としたもの
      Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
      RaycastHit hit;


      if (Physics.Raycast(ray, out hit, 3f))
      {

        if (hit.transform.gameObject.tag == "Key")
        {

          GetKey();
          canvasAim.SetActive(true);

          Debug.Log(keyType + "に当たった");
        }
      }
    }
    */
}
