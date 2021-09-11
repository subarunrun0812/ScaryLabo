using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberButton : MonoBehaviour
{

  [SerializeField] TMP_Text numberText;
  public string number;

  void Start()
  {
    numberText.text = number;
  }

  public void OnClickThis()
  {
    Debug.Log(number);
  }
}
