using UnityEngine;
using System.Collections;

public class SubLocker : MonoBehaviour
{
  public Animator animator;
  public AudioClip open;
  public AudioClip close;
  AudioSource audioSource;
  int a;
  void Start()
  {
    a = 0;//ドアが閉まっている = 0,開いている = 1
    audioSource = GetComponent<AudioSource>();
  }

  public void Locker()
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
