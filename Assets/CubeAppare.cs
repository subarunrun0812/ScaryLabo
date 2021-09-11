using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAppare : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    gameObject.SetActive(true);
  }

  // Update is called once per frame
  public void CubeHide()
  {
    gameObject.SetActive(false);
  }
}
