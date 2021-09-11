using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public GameObject pausePanel;

  public GameObject Hand;//Playerについている銃、ライトの親オブジェクト
  public GameManager gameManager;


  void Start()
  {
    pausePanel.SetActive(false);
  }

  void Update()//Time.timeScale で時間の流れを指定しています。1 で通常速度、0 で完全に停止します。
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Hand.SetActive(false);
      gameManager.Mute();
      Time.timeScale = 0;
      pausePanel.SetActive(true);
    }
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Time.timeScale = 1;  // 再開
      pausePanel.SetActive(false);
      Hand.SetActive(true);
      gameManager.NormalAudio();
    }
  }




  public void Resume()
  {
    Time.timeScale = 1;  // 再開
    pausePanel.SetActive(false);
    Hand.SetActive(true);
    gameManager.NormalAudio();
  }

  public void MoveScene()//最初からやり直すbutton
  {
    SceneManager.LoadScene("Start");
  }

}
