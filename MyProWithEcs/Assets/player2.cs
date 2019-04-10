using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player2 : MonoBehaviour
{
    private RaycastHit2D[] hitInfos;
    public LayerMask mask;

    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
        //设定好层 
        mask=LayerMask.NameToLayer("Enemy");
        go = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            Debug.Log("yes");
            //Debug.Log(this.transform.parent.position);
            
            //Debug.Log(transform.TransformPoint(this.gameObject.transform.position)+transform.TransformPoint(this.transform.parent.position));
            Debug.Log(Physics2D.LinecastAll(this.gameObject.transform.position, this.transform.parent.position,mask,-Mathf.Infinity,Mathf.Infinity).Length);
            if (Physics2D.LinecastAll(this.gameObject.transform.position, this.transform.parent.position,mask,-Mathf.Infinity,Mathf.Infinity).Length>0)
            {
                Debug.Log(Physics2D.LinecastAll(this.gameObject.transform.position, this.transform.parent.position,mask,-Mathf.Infinity,Mathf.Infinity).Length);
                
            }
           
           
        }
        
    }

    private void OnDrawGizmos()
    {
        
    }
}
