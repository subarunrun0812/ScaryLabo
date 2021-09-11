using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class password_cube : MonoBehaviour
{
  public GameObject passwordUI;//

  void Start()
  {
    passwordUI.SetActive(false);
  }
  public void ActivePasswordUI()
  {
    passwordUI.SetActive(true);
  }
}
