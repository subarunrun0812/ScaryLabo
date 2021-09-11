using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyDoor : MonoBehaviour
{
  [SerializeField] private Player.KeyType keyType;
  [SerializeField] private Player player;
  private RaycastHit hit;//Rayが当たった時に当たったオブジェクト

  private bool isNear;
  public Animator animator;
  public AudioClip open;
  public AudioClip close;

  AudioSource audioSource;

  public AudioClip enable;

  int a;

  [SerializeField] private Text keynameText;//keyの種類

  //CANVASが制限時間経ったらfalseにする



  //public Text needkey;//鍵を持っていない時はmessageを伝える
  void Start()
  {
    isNear = false;
    a = 0;//ドアが閉まっている = 0,開いている = 1
    audioSource = GetComponent<AudioSource>();

    // a = 0;//ドアが閉まっている = 0,開いている = 1
  }

  public void OpenDoor()
  {

    var keyList = player.keylist;
    isNear = true;
    if (Input.GetKeyDown(KeyCode.E) && isNear)
    {
      if (keyList.Contains(keyType))
      {
        if (a == 0)
        {
          animator.SetBool("Open", !animator.GetBool("Open"));
          audioSource.PlayOneShot(open);
          a = 1;
        }

        else
        {
          animator.SetBool("Open", !animator.GetBool("Open"));
          audioSource.PlayOneShot(close);
          a = 0;
        }
      }
      else
      {
        audioSource.PlayOneShot(enable);
        StartCoroutine("NeedKeyTextName");
        Debug.Log("鍵のドアのStartCoroutineがよばれた");
      }
    }
  }

  public void OpenDoorEnemy()//enemyが鍵付きのドアを開ける
  {

    if (a == 0)
    {
      animator.SetBool("Open", !animator.GetBool("Open"));
      audioSource.PlayOneShot(open);
      a = 1;
      StartCoroutine("CloseDoorEnemy");
    }
  }

  public IEnumerator CloseDoorEnemy()//enemyrayスクリプトからよばれ、ドアをｎ秒後しめる
  {
    yield return new WaitForSeconds(4);
    animator.SetBool("Open", !animator.GetBool("Open"));
    audioSource.PlayOneShot(close);
    a = 0;
  }



  public IEnumerator NeedKeyTextName()
  {
    keynameText.text = keyType + "の鍵が必要だ";
    Debug.Log(keyType + "の鍵が必要だ");

    yield return new WaitForSeconds(2);
    keynameText.text = "";
  }


}

// if (条件式)
//   条件式がTrueの場合実行される文
// else
//   これまでの条件式のどれにも当てはまらない場合に実行される文
// a = 10;
// a = 10;
// 式：　値を返すもの     (example: a=10  OpenDoor() )
// 文：　値を返さないもの  (exmaple: a=10; Debug.Log();)





// void OnTriggerStay(Collider other)
// {
//   if (other.gameObject.tag == "Player")
//   {
//     OpenDoor();
//     Debug.Log("OpenDoor関数が呼ばれた");
//     isNear = true;
//   }
// }
