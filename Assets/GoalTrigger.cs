using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
// [RequireComponent(typeof(Collider))]
public class GoalTrigger : MonoBehaviour
{


  [SerializeField] private GameObject canvas;

  // [SerializeField] private TextMeshProUGUI cleartext;

  void Start()
  {
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Time.timeScale = 0;
      canvas.SetActive(true);

      Debug.Log("ゲームクリア");
      StartCoroutine("MoveStart");

    }
  }

  IEnumerator MoveStart()
  {
    yield return new WaitForSeconds(13);//3秒テキストを表示
    SceneManager.LoadScene("Start");
  }


  // public IEnumerator gameclear()//2秒待ってからテキストを出す
  // {
  //   Debug.Log("2秒停止");
  //   yield return new WaitForSeconds(5);
  //   Debug.Log("2秒待った");
  //   cleartext.enabled = true;


  // }
}
