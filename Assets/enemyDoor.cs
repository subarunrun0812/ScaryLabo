using UnityEngine;
using System.Collections;

public class enemyDoor : MonoBehaviour
{
  private bool isNear;
  private Animator animator;
  public AudioClip open;
  public AudioClip close;
  AudioSource audioSource;
  int a;
  void Start()
  {
    isNear = false;
    animator = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();

    a = 0;//ドアが閉まっている = 0,開いている = 1
  }
  private void Update()
  {
    if (isNear)
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
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Enemy")
    {
      isNear = true;
    }
  }
  //   private void OnTriggerExit(Collider other)
  //   {
  //     if (other.tag == "Enemy")
  //     {
  //       isNear = false;
  //     }
  //   }
}
