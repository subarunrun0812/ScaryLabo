using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AddForceBullet : MonoBehaviour
{

  //弾のゲームオブジェクト
  [SerializeField]
  private GameObject bulletPrefab;
  //銃口
  [SerializeField]
  private Transform muzzle;//弾を発射するための銃口。
  //弾を飛ばす力
  [SerializeField]
  private float bulletPower = 5000f;//弾の速さ
  [SerializeField] private AudioSource a1;//AudioSource型の変数a1を宣言 使用するAudioSourceコンポーネントをアタッチ必要。銃の発射音

  [SerializeField] private AudioClip b1;//AudioClip型の変数b1を宣言
  [SerializeField] private AudioClip emptyBullet;
  [SerializeField] private AudioSource emptyAudio;


  public Animator animator;

  public GameObject biglight;//銃を打った時に出る光
  public Text shellLabel;//銃弾の表示

  public GameObject GunCanvas;


  public int shotCount = 10;

  void Start()
  {
    shellLabel.text = "×" + shotCount;
    Debug.Log("弾数を表示");
    //     //カーソルを自前のカーソルに変更
    //     Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
  }

  public void OnDisable()
  {
    GunCanvas.SetActive(false);

  }

  void Update()
  {
    GunCanvas.SetActive(true);

    // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    // transform.rotation = Quaternion.LookRotation(ray.direction);

    // RaycastHit hit;

    // if (Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("Gun")))
    // {
    //   Cursor.visible = false;
    // }
    // else
    // {
    //   Cursor.visible = true;
    // }

    //　マウスの左クリックで撃つ
    if (Input.GetButtonDown("Fire1"))
    {
      if (shotCount > 0)
      {
        Shot();
        Debug.Log("マウス1が押された");
      }
      if (shotCount == 0)//弾が入っていない音を鳴らす
      {
        emptyAudio.PlayOneShot(emptyBullet);
        Debug.Log("銃弾が無くなった");
      }
    }
    else
    {
      biglight.SetActive(false);
    }
  }

  //　敵を撃つ
  void Shot()
  {
    shotCount -= 1;//弾数1減らす
    shellLabel.text = "×" + shotCount;
    //timer = 0.0f;
    var bulletInstance = Instantiate<GameObject>(bulletPrefab, muzzle.position, muzzle.rotation);
    bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
    Destroy(bulletInstance, 2f);
    animator.enabled = true;
    animator.SetTrigger("Shot");
    biglight.SetActive(true);
    Debug.Log("Shotの中の処理が行われた");
    a1.PlayOneShot(b1);//銃の発射音を再生

  }

  public void BulletBox()//弾を拾う処理
  {
    shotCount += 1;
    shellLabel.text = "×" + shotCount;//UIを更新。
    Debug.Log("弾が補充された");
  }


}
