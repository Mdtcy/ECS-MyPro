using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.gameObject.GetComponent<CinemachineVirtualCamera>().Follow==null && GameObject.FindGameObjectWithTag("Player")!=null)
        {
            
            this.gameObject.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }
}
