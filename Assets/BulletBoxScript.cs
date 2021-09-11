// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BulletBoxScript : MonoBehaviour
// {

//   public GameObject canvasAim;
//   public AddForceBullet gun;
//   // Start is called before the first frame update
//   void Start()
//   {

//   }

//   // Update is called once per frame
//   void Update()
//   {
//     Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
//     RaycastHit hit;

//     if (Physics.Raycast(ray, out hit, 3f))
//     {

//       if (hit.transform.gameObject.tag == "Bullet")//銃弾を拾った後の処理
//       {
//         if (Input.GetKey(KeyCode.E))
//         {
//           var bullet = hit.transform.gameObject;
//           gun.BulletBox();
//           Destroy(bullet);
//           Debug.Log("銃弾が消えた");
//           canvasAim.SetActive(false);
//         }

//       }
//     }
//   }
// }
