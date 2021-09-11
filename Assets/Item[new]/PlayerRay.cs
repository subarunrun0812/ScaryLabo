using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRay : MonoBehaviour
{

  public AddForceBullet gun;

  public GameObject canvasAim;
  //public GameObject bulletbox;//bulletBox
  [SerializeField] private AudioSource a2;//AudioSource型の変数a2を宣言 使用するAudioSourceコンポーネントをアタッチ必要。銃のリロード音
  [SerializeField] private AudioClip b2;//AudioClip型の変数b2を宣言 使用するAudioClipをアタッチ必要
  public GameManager gameManager;
  void Start()
  {
    canvasAim.SetActive(false);
  }
  void Update()
  {
    ////ビューポート座標は左下を(x, y, z)= (0,0,1)として、右上(x, y, z)= (1,1,1)としたもの
    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, 3f))
    {
      if (hit.transform.gameObject.tag == "Untagged" || hit.transform.gameObject.tag == "Player" || hit.transform.gameObject.tag == "BulletGun")
      {
        canvasAim.SetActive(false);
      }

      else
      {
        canvasAim.SetActive(true);
      }


      //上のUpdate内の処理の下に追加する
      if (Input.GetKeyDown(KeyCode.E))
      {
        canvasAim.SetActive(false);
        if (hit.transform.gameObject.tag == "Memo")//メモの内容が表示される
        {
          hit.transform.gameObject.GetComponent<MemoText>().Memo();
        }
        if (hit.transform.gameObject.tag == "Bullet")//銃弾を拾った後の処理
        {
          var bullet = hit.transform.gameObject;
          gun.BulletBox();
          Debug.Log("銃弾が消えた");
          a2.PlayOneShot(b2);//銃のリロード音を再生
          Destroy(bullet);
          gameManager.GetBullet();

        }
        if (hit.transform.gameObject.tag == "Key")
        {
          hit.transform.gameObject.GetComponent<Key>().GetKey();
        }
        if (hit.transform.gameObject.tag == "KeyDoor")
        {
          hit.transform.gameObject.GetComponent<KeyDoor>().OpenDoor();
        }
        if (hit.transform.gameObject.tag == "BookShelf")
        {
          hit.transform.gameObject.GetComponent<BookShelfMove>().OpenBookShelf();
        }
        if (hit.transform.gameObject.tag == "Locker")
        {
          hit.transform.gameObject.GetComponent<SubLocker>().Locker();
        }
        if (hit.transform.gameObject.tag == "KeyDoorEnemy")
        {
          hit.transform.gameObject.GetComponent<KeyDoorEnemy>().EnabledNeedKeyTextName();
        }
        if (hit.transform.gameObject.tag == "Password")
        {
          hit.transform.gameObject.GetComponent<password_cube>().ActivePasswordUI();
        }
      }

    }


  }
}
