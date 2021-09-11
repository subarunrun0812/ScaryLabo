using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BookShelfMove : MonoBehaviour
{
  [SerializeField] private Animator animator;

  [SerializeField] private AudioClip open;

  AudioSource audioSource;

  public EnemyMove enemyMove;//underground

  private int a;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    a = 0;//a＝0しまっている。a=1は開いている
  }


  public void OpenBookShelf()
  {
    if (a == 0)
    {
      Vector3 enemyPosition = new Vector3(35, -0.6f, 22.6f);
      animator.SetBool("Open", !animator.GetBool("Open"));
      audioSource.PlayOneShot(open);
      a = 1;
      StartCoroutine("EnmeyBookCorutine");
    }
  }
  IEnumerator EnmeyBookCorutine()
  {
    yield return new WaitForSeconds(5);
    enemyMove.EnemyTransformPositionBookShelf();
    Debug.Log("こルーチンがよばれた");

  }
}
