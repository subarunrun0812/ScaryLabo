using UnityEngine;
using System.Collections;

public class RigidChara : MonoBehaviour
{

  //   private Animator animator;
  private Vector3 velocity;
  [SerializeField]
  private float jumpPower = 5f;
  //　地面に接地しているかどうか
  [SerializeField]
  private bool isGrounded;
  //　入力値
  private Vector3 input;
  //　歩く速さ
  [SerializeField]
  private float walkSpeed = 1.5f;
  //　rigidbody
  private Rigidbody rigid;
  //　レイヤーマスク
  [SerializeField]
  private LayerMask layerMask;
  //　前方に段差があるか調べるレイを飛ばすオフセット位置
  [SerializeField]
  private Vector3 stepRayOffset = new Vector3(0f, 0.05f, 0f);
  //　レイを飛ばす距離
  [SerializeField]
  private float stepDistance = 0.5f;
  //　昇れる段差
  [SerializeField]
  private float stepOffset = 0.3f;
  //　昇れる角度
  [SerializeField]
  private float slopeLimit = 65f;
  //　昇れる段差の位置から飛ばすレイの距離
  [SerializeField]
  private float slopeDistance = 0.6f;

  void Start()
  {
    // animator = GetComponent<Animator>();
    rigid = GetComponent<Rigidbody>();
  }

  void Update()
  {

  }

  void FixedUpdate()
  {
    //　キャラクターが接地している場合
    if (isGrounded)
    {
      //　接地したので移動速度を0にする
      velocity = Vector3.zero;
      input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

      //　方向キーが多少押されている
      if (input.magnitude > 0f)
      {
        // animator.SetFloat("Speed", input.magnitude);
        transform.LookAt(rigid.position + input.normalized);

        var stepRayPosition = rigid.position + stepRayOffset;

        //　ステップ用のレイが地面に接触しているかどうか
        if (Physics.Linecast(stepRayPosition, stepRayPosition + rigid.transform.forward * stepDistance, out var stepHit, layerMask))
        {
          //　進行方向の地面の角度が指定以下、または昇れる段差より下だった場合の移動処理

          if (Vector3.Angle(rigid.transform.up, stepHit.normal) <= slopeLimit
          || (Vector3.Angle(rigid.transform.up, stepHit.normal) > slopeLimit
            && !Physics.Linecast(rigid.position + new Vector3(0f, stepOffset, 0f), rigid.position + new Vector3(0f, stepOffset, 0f) + rigid.transform.forward * slopeDistance, layerMask))
          )
          {
            velocity = new Vector3(0f, (Quaternion.FromToRotation(Vector3.up, stepHit.normal) * rigid.transform.forward * walkSpeed).y, 0f) + rigid.transform.forward * walkSpeed;
          }
          else
          {
            //　指定した条件に当てはまらない場合は速度を0にする
            velocity = Vector3.zero;
          }

          Debug.Log(Vector3.Angle(Vector3.up, stepHit.normal));

          //　前方の壁に接触していなければ
        }
        else
        {
          velocity = transform.forward * walkSpeed;
        }

        //　キーの押しが小さすぎる場合は移動しない
      }
      else
      {
        // animator.SetFloat("Speed", 0f);
      }
      //　ジャンプ
      if (Input.GetButtonDown("Jump")
      // && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
      // && !animator.IsInTransition(0)      //　遷移途中にジャンプさせない条件
      )
      {
        // animator.SetTrigger("Jump");
        //　ジャンプしたら接地していない状態にする
        isGrounded = false;
        // animator.SetBool("IsGrounded", isGrounded);
        velocity.y = jumpPower;
      }
    }
    //　キャラクターを移動させる処理
    rigid.MovePosition(rigid.position + velocity * Time.fixedDeltaTime);
  }

  private void OnCollisionEnter(Collision collision)
  {
    //　地面に着地したかどうかの判定
    if (Physics.CheckSphere(rigid.position, 0.3f, layerMask))
    {
      isGrounded = true;
      //   animator.SetBool("IsGrounded", isGrounded);
      velocity.y = 0f;
    }
  }

  private void OnCollisionExit(Collision collision)
  {
    //　地面から降りた時の処理
    //　地面としたレイヤーのゲームオブジェクトから離れた時
    if (1 << collision.gameObject.layer == layerMask)
    {
      //　下向きにレイヤーを飛ばし地面とするレイヤーと接触しなければ地面から離れたと判定する
      if (!Physics.Linecast(rigid.position + Vector3.up * 0.2f, rigid.position + Vector3.down * 0.3f, layerMask))
      {
        isGrounded = false;
        // animator.SetBool("IsGrounded", isGrounded);
      }
    }
  }

  private void OnDrawGizmos()
  {
    var stepRayPosition = transform.position + stepRayOffset;
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(stepRayPosition, stepRayPosition + transform.forward * stepDistance);
    Gizmos.color = Color.green;
    Gizmos.DrawLine(transform.position + new Vector3(0f, stepOffset, 0f), transform.position + new Vector3(0f, stepOffset, 0f) + transform.forward * slopeDistance);
  }
}
