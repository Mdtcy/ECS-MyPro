using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudTextService : IHudTextService
{
    public void floatText(Transform transform, string _string)
    {
        HUDTextInfo info=new HUDTextInfo(transform,_string);
        info.Side = bl_Guidance.Up;
        info.Size = 30;
        bl_UHTUtils.GetHUDText.NewText(info);
    }
}
