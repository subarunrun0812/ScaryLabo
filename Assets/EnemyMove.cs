using UnityEngine;
using UnityEngine.AI;
using System.Collections;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{

  private Animator animator;//Enemyの歩く、走る、倒れる
  private NavMeshAgent _agent;
  private RaycastHit[] _raycastHits = new RaycastHit[10]; // _raycastHitsに、ヒットしたColliderや座標情報などが格納される

  [SerializeField] Transform points;//目的地

  public GameManager gamemanager;//bgmを停止する

  public float AddSpeed;//加速する速度


  private void Start()
  {
    _agent = GetComponent<NavMeshAgent>(); // NavMeshAgentを保持しておく
    animator = GetComponent<Animator>();
    SetDestinationRandomly();

  }


  void Update()
  {
    // Debug.Log("Enemyのスピード：" + _agent.speed);
    if (!_agent.pathPending && _agent.remainingDistance < 0.5f)//経路探索の準備ができていない　かつ　目標地点まで0.5fより遠かったら
    {
      SetDestinationRandomly();

    }
  }

  public void EnemyTransformPosition()//1FとB1Fを繋ぐ
  {
    Vector3 agentPosition = new Vector3(18, -0.6f, 9);
    _agent.enabled = false;
    transform.position = agentPosition;//ここで(0,0,0)へ移動できた
    _agent.enabled = true;
  }

  public void EnemyTransformPositionBookShelf()
  {
    Vector3 agentPosition = new Vector3(18f, -6f, 5f);
    _agent.enabled = false;
    transform.position = agentPosition;//ここで(0,0,0)へ移動できた
    _agent.enabled = true;
  }

  public void EnemyTransformPositionLibrary()
  {
    Vector3 agentPosition = new Vector3(49, -0.6f, -1.3f);
    _agent.enabled = false;
    transform.position = agentPosition;//ここで(0,0,0)へ移動できた
    _agent.enabled = true;
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      Debug.Log("hoge");
      // NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
      // GetComponent<NavMeshAgent>().isStopped = true;
    }
  }

  void SetDestinationRandomly()//見回りの処理
  {
    _agent.destination = points.GetChild(Random.Range(0, points.childCount)).position;
    var positionDiff = points.transform.position - transform.position; // enemyとpointの座標差分を計算
    var direction = positionDiff.normalized; // pointへの方向
    Debug.Log("見回りをする");
    gamemanager.NormalAudio();
    if (_agent.speed > 2)//鬼が走った時は、speedが上がるため見回りをする時は遅くする。animationも同様
    {
      _agent.speed = 1.5f;
      animator.SetBool("Running", false);//歩くアニメーションに変える
      Debug.Log(animator);
    }
  }

  // CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
  public void OnDetectObject(Collider collider)//Playerを見つけている時の処理
  {

    // 検知したオブジェクトに「Player」のタグがついていれば、そのオブジェクトを追いかける
    if (collider.gameObject.tag == "Player")
    {
      var positionDiff = collider.transform.position - transform.position; // 自身とプレイヤーの座標差分を計算
      var distance = positionDiff.magnitude; // プレイヤーとの距離を計算
      var direction = positionDiff.normalized; // プレイヤーへの方向

      // _raycastHitsに、ヒットしたColliderや座標情報などが格納される
      // RaycastAllとRaycastNonAllocは同等の機能だが、RaycastNonAllocだとメモリにゴミが残らないのでこちらを推奨
      var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);
      Debug.Log("hitCount: " + hitCount);

      if (hitCount == 1)//0 < hitCount < 10の場合は、Colliderがずっと追いかけてくるようになる
                        //hitcount2以上の場合は障害物があっても、追いかけてくる.hitcount1はお互いが見えたら追いかけてくる
      {
        _agent.destination = collider.transform.position;
        gamemanager.EnemyRunAudio();//音楽を流す。バクバク音
        if (_agent.speed < 2)//鬼の速度を早くする。アニメーションで走らす
        {
          _agent.speed += AddSpeed;//鬼のnavgationのspeedに +n 速度を追加する _agent = _agent+ n
          animator.SetBool("Running", true);
          Debug.Log(animator);
        }
      }
      // if (1 < hitCount && hitCount < 4)// 1< hitcount < 3
      // {
      //   gamemanager.EnemyArea();
      // }
      if (1 < hitCount && hitCount < 10)// 3< hitcount < 10
      {
        gamemanager.NormalAudio();
      }
    }
  }
}
