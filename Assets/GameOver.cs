using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// https://zenn.dev/ohbashunsuke/books/20200924-dotween-complete/viewer/17

public class GameOver : MonoBehaviour
{
  [SerializeField] private GameObject canvas;
  [SerializeField] private Text text;
  public GameObject Hand;//Playerについている銃、ライトの親オブジェクト
  public GameManager gamemanager;//audiomixerから音を調整する


  public void Start()
  {
    canvas.SetActive(true);
    gamemanager.audioBGM();
    Time.timeScale = 0;
    //ボタンをクリックするイベントが起きた時にOnClickButtonという自前のメソッドを実行するようにAddListenerメソッドで指定しています
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      Time.timeScale = 1;
      SceneManager.LoadScene("Underground");
    }
  }
  // void FixedUpdate()
  // {
  //   // Time.timeScale = 0;
  // }


  public void Retry()
  {
    SceneManager.LoadScene("Underground");
  }
  public GameOver()
  {

    //     canvas.SetActive(true);
    //     text.DOFade(0.2f, 1.5f);
  }


}
