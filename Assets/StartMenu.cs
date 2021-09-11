using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class StartMenu : MonoBehaviour
{

  [SerializeField] private GameObject canvas;
  [SerializeField] private Text start;
  [SerializeField] private Image image;
  void Start()
  {
    canvas.SetActive(true);
    start.DOFade(0.4f, 0.8f)
    .SetLoops(-1, LoopType.Yoyo);
  }


}
