using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudTest : MonoBehaviour
{
    private bl_HUDText HUDRoot;
    // Start is called before the first frame update
    void Start()
    {
        HUDRoot = bl_UHTUtils.GetHUDText;
        HUDTextInfo info2 = new HUDTextInfo(transform, "- " + Random.Range(50, 100));
        info2.Color = Color.white;
        info2.Size = 20;
        info2.Speed = 0;
        
        info2.VerticalAceleration = -3;
        info2.VerticalFactorScale = 1;
        info2.VerticalFactorScale = Random.Range(1.2f, 3);
        info2.VerticalPositionOffset = 3;
        HUDRoot.NewText(info2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
