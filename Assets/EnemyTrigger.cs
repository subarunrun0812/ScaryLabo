using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading;
using TMPro;
using UnityEngine.UI;
public class EnemyTrigger : MonoBehaviour
{

  [SerializeField] public GameObject gameOver;

  [SerializeField] private GameObject enemy;
  [SerializeField] private Animator m_animator;//弾が当たった時のアニメーション

  [SerializeField] private Text stopTime;//銃が当たった時にn秒停止を表示する

  public GameManager gamemanager;//audiomixerから音を調整する

  public GameObject enemyfix;


  private void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.tag == "Player")//gameover
    {
      gameOver.SetActive(true);
      Time.timeScale = 0;
      Debug.Log("EnemyのTriggerが反応した");
    }
    if (col.gameObject.tag == "BulletGun")
    {
      StartCoroutine("getHit");
      Debug.Log("銃が当たった");
    }
  }
  public IEnumerator getHit()//銃が打たれた時の処理
  {
    enemy.GetComponent<NavMeshAgent>().isStopped = true;
    gamemanager.ShotAudio();//心臓を音を大きくする

    GetComponent<CapsuleCollider>().enabled = false;
    m_animator.SetTrigger("Death");
    //倒れる時、徐々に下にして自然に倒れるようにする
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, -0.1f, 0);
    Debug.Log("15秒静止する");
    stopTime.text = "";
    yield return new WaitForSeconds(3.8f);
    stopTime.text = "";
    yield return new WaitForSeconds(13.6f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);
    yield return new WaitForSeconds(0.1f);
    enemyfix.gameObject.transform.Translate(0, 0.1f, 0);

    GetComponent<CapsuleCollider>().enabled = true;
    gamemanager.NormalAudio();//元に戻す

    Debug.Log("15秒静止完了");
    m_animator.ResetTrigger("Death");
    enemy.GetComponent<NavMeshAgent>().isStopped = false;
  }
}
