using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputText : MonoBehaviour
{
  [SerializeField] Text codeText;
  string codeTextValue = "";

  public GameObject LockWall;

  public GameManager gameManager;
  [SerializeField] private AudioSource a;

  [SerializeField] private AudioClip Click;
  [SerializeField] private AudioClip notCorrect;
  public GameObject light1;

  public GameObject light2;

  public Text _text;//gameManagerについているテキストを引用する

  void Start()
  {
    a = GetComponent<AudioSource>();
    light1.SetActive(false);
    light2.SetActive(false);
  }
  public void OnEnable()
  {
    Time.timeScale = 0;
    Cursor.lockState = CursorLockMode.Confined;//// カーソルを画面内で動かせる
    Cursor.visible = true;

  }

  private void Update()
  {
    codeText.text = codeTextValue;

    if (codeTextValue == "4510")
    {
      gameManager.PasswordAudio();
      LockWall.SetActive(false);
      Time.timeScale = 1;
      Cursor.lockState = CursorLockMode.Locked;//カーソルを画面中央に固定する
      this.gameObject.SetActive(false);
      light1.SetActive(true);
      light2.SetActive(true);
    }

    if (codeTextValue.Length >= 4)
    {
      codeTextValue = "";
      a.PlayOneShot(notCorrect);
    }
    if (Input.GetKeyDown(KeyCode.Q))
    {
      this.gameObject.SetActive(false);
      Time.timeScale = 1;
      Cursor.lockState = CursorLockMode.Locked;//カーソルを画面中央に固定する
    }
  }


  public void AddDigit(string digit)
  {
    codeTextValue += digit;
    Debug.Log(codeTextValue);
    a.PlayOneShot(Click);
  }
  public void PasswordQuit()
  {
    this.gameObject.SetActive(false);
    Time.timeScale = 1;
    Cursor.lockState = CursorLockMode.Locked;//カーソルを画面中央に固定する
  }
}
