using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
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
  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.E) && isNear)
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

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      isNear = true;
    }
    if (other.tag == "Enemy")
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

    if (other.tag == "Enemy")
    {
      isNear = true;
    }
  }
}
