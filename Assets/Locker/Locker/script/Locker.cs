using UnityEngine;
using System.Collections;
using DG.Tweening;


public class Locker : MonoBehaviour
{
  private bool isNear;
  private Animator animator;
  public AudioClip open;
  public AudioClip close;
  AudioSource audioSource;
  public GameObject Player;
  void Start()
  {
    isNear = false;
    animator = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
  }
  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.E) && isNear)
    {
      animator.SetBool("Open", !animator.GetBool("Open"));
      audioSource.PlayOneShot(open);
      Player.transform.DOMove(new Vector3(-3.6f, 1.1f, 8.49f), 3f);//ローカル座標で移動する方向を指定。しかしFPSコントローラーは親なのでワールド座標をしている
      Player.transform.DORotate(Vector3.up * 0f, 3f);//回転する角度（Y軸）
      Debug.Log("ロッカーに入った。");
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      isNear = true;
    }
  }
  void OnTriggerExit(Collider other)
  {
    if (other.tag == "Player")
    {
      isNear = false;
    }
  }
}
