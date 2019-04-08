//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class si : MonoBehaviour
//{
//    public Transform target;
//
//    private Camera _camera;
//    // Start is called before the first frame update
//    void Start()
//    {
//        _camera=Camera.main;
//        
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        if (target!=null)
//                {
//                	  //把目标坐标转换为屏幕坐标
//                    //
//                    //Vector3 pos = _camera.WorldToScreenPoint(target.position);
//                    target = transform.parent.parent.transform;
//                    Debug.Log(target.gameObject);
//                    var pos = target.position;
//                    pos.z += 0.1f;
//                    
//                    transform.position = pos;
//                }
//       
//    }
//}
