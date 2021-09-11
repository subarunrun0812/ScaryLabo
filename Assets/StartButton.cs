using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
  private void Start()
  {
    var button = GetComponent<Button>();
    //ボタンを押した時にリスナーを設定
    button.onClick.AddListener(() =>
    {
      //Undergroundシーンに遷移する
      SceneManager.LoadScene("Underground");
    });
  }

}
