//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Security.Cryptography;
//using System.Threading;
//using UnityEngine;

//public class speedup : item
//{
//        // 10초간 이동속도 100% 증가 
//        private void OnTriggerEnter(Collider col)
//        {
//            if (col.CompareTag("Player"))
//            {
//                Player player = col.GetComponent<Player>();
//                StartCoroutine(IncreaseMoveSpeed(player));

//                GetComponent<MeshRenderer>().enabled = false;  // Destroy를 하면 코루틴이 정지되므로, 임시로 그림만 없앴음.
//                GetComponent<SphereCollider>().enabled = false;      // 충돌체 제거
//            }
//        }

//        IEnumerator IncreaseMoveSpeed(Player player)
//        {
//            float moveSpeed = player.getMoveSpeed();
//            player.SetMoveSpeed(moveSpeed * 2f);

//            yield return new WaitForSeconds(10);

//            player.SetMoveSpeed(moveSpeed);
//            Destroy(gameObject);
//        }

//}
