using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
  public GameObject canvas;

  void Start()
  {

    StartCoroutine("tutorialTime");
  }

  IEnumerator tutorialTime()
  {
    canvas.SetActive(true);
    Debug.Log("説明を15秒表示します");
    yield return new WaitForSeconds(15);
    canvas.SetActive(false);
  }


}
