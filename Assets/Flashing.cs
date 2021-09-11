using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Flashing : MonoBehaviour
{
  private CanvasGroup canvasGroup;//心臓の音が鳴っている時に背景に赤を点滅させる
  public float DurationSeconds;//透明から不透明にするのにかかる時間。また、逆も同様
  public Ease EaseType;//DOTweenのアニメーションの種類

  void OnEnable()
  {
    canvasGroup = this.GetComponent<CanvasGroup>();

    canvasGroup.DOFade(0.5f, this.DurationSeconds)//画面の周りを赤く点滅させる
               .SetEase(this.EaseType)
               .SetLoops(-1, LoopType.Yoyo);
  }
}
