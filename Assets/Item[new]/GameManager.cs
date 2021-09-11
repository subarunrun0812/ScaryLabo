using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public AudioMixer audioMixer;


  [SerializeField] private GameObject canvas;//画面を点滅
  [SerializeField] private Text _text;//gamemanegerについているテキストで表示する。その場所の説明などをする

  public bool gageAreaBool;//1度だけ場所の説明のテキストを表示させたい
  public float wordSpeed;//1文字あたりの表示速度

  public float waitTime;//文字を全て表示してから待つ時間

  //ゲーム開始時の説明＆アニメーションなど
  [SerializeField] public float ClearnessTime;//透明度を薄いから濃くするのにかかる時間。また、逆も同様
  [SerializeField] private Ease EaseType;//DOTWeenの再生の種類
  [SerializeField] private CanvasGroup StartCanvasGroup;//CanvasにあるcanvasGroupコンポーネント
  [SerializeField] private GameObject StartCanvas;
  [SerializeField] private GameObject enemey;
  [SerializeField] private GameObject enemey1;

  public AudioSource audioSource;//パスワードのロックが解除できた時に流す音
  public AudioClip audioClip;
  public Text keytext;


  public void Awake()
  {
    audioMixer.SetFloat("BGMVolume", -30);
    audioMixer.SetFloat("NearVolume", -35);//心臓の音
    audioMixer.SetFloat("Scream", 0);//悲鳴
    audioMixer.SetFloat("EnemyVolume", 0);
    canvas.SetActive(false);
    gageAreaBool = true;
    enemey.SetActive(false);
    enemey1.SetActive(false);
    StartCanvas.SetActive(true);

  }

  void Start()//最初の説明。なぜここにきた みたいなテキスト表示 [訂正] メモで説明をすることにした
  {
    StartCoroutine("StartMovie");
  }

  public IEnumerator StartMovie()
  {
    // string text;

    StartCanvasGroup.DOFade(0.0f, this.ClearnessTime).SetEase(this.EaseType);
    yield return new WaitForSeconds(5);
    StartCanvas.SetActive(false);
    enemey.SetActive(true);
  }

  public void Mute()//menu画面表示の時に使う
  {
    audioMixer.SetFloat("BGMVolume", -60);

  }




  public void NormalAudio()//通常時の時の音量。スタート関数と同じ.
  {
    audioMixer.SetFloat("BGMVolume", -30);
    audioMixer.SetFloat("NearVolume", -35);//心臓の音
                                           // canvasGroup.DOFade(0f, 1.5f);
    canvas.SetActive(false);
  }

  public void audioBGM()//gameoverの時に制御する
  {
    //dB単位( -80 ~ 20 ).-80は一番小さい音。
    //BGMの音量を0にして、ミュートにする
    audioMixer.SetFloat("BGMVolume", -80);
    audioMixer.SetFloat("NearVolume", -20);
    audioMixer.SetFloat("EnemyVolume", -60);
  }

  public void EnemyRunAudio()////鬼に追いかけられてる時に流れる音楽
  {
    audioMixer.SetFloat("NearVolume", 0);
    canvas.SetActive(true);

  }

  public void EnemyArea()//鬼が範囲内にいる時に流れる鼓動音。音量は小さめ.1< hitcount < 3
  {
    audioMixer.SetFloat("NearVolume", -12);
    canvas.SetActive(true);
  }
  public void ShotAudio()//銃弾がenmeyに当たった時の処理
  {
    audioMixer.SetFloat("NearVolume", -5);//心臓の音
  }

  public void GageBoxArea()//この場所の説明をする。gameManagerからのテキストから
  {
    if (gageAreaBool == true)
    {
      StartCoroutine("GageBoxAreaCorutine");
      Debug.Log("GageBoxArea関数がよばれた");
    }
  }

  public IEnumerator GageBoxAreaCorutine()
  {
    string text;

    gageAreaBool = false;
    //wordSpeed秒ごとに、文字を1文字ずつ表示.(Ease.Linear)をセットすることで一定の表示間隔で表示

    text = "彼らが噂の被験者達なのか？";
    _text.DOText(text, text.Length * wordSpeed).SetEase(Ease.Linear);
    yield return new WaitForSeconds(text.Length * wordSpeed + waitTime);
    _text.text = "";

    text = "とても気分が悪い";
    _text.DOText(text, text.Length * wordSpeed).SetEase(Ease.Linear);
    yield return new WaitForSeconds(text.Length * wordSpeed + waitTime);
    _text.text = "";

    text = "ここに長居はしないほうが良さそうだ";
    _text.DOText(text, text.Length * wordSpeed).SetEase(Ease.Linear);
    yield return new WaitForSeconds(text.Length * wordSpeed + waitTime);
    _text.text = "";
  }

  public void PasswordAudio()
  {
    audioSource.PlayOneShot(audioClip);
  }

  public void GetBullet()//銃弾を入手したときにテキストを表示する
  {
    StartCoroutine("GetBulletCorutine");
  }
  IEnumerator GetBulletCorutine()
  {
    keytext.text = ("銃弾を入手した");
    yield return new WaitForSeconds(3);
    keytext.text = ("");
  }

  public void GoalTriggerText()
  {
    _text.text = "終わる[space]";

  }

}
