using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class HPUiSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _hps;

    public HPUiSystem(Contexts contexts)
    {
        
        _hps = contexts.game.GetGroup(GameMatcher.HP);
    }

    public void Execute()
    {
        ///
        foreach (GameEntity e in _hps.GetEntities())
        {
            if (e.hasHPUi)
            {
                var go = e.hPUi.canvas.transform.Find("Slider").GetComponent<Slider>();
                go.value = e.hP.value;
            }
            else if (!e.hasHPUi&&!e.isPlayer)
            {
                var go = (GameObject) Resources.Load("Prefabs/HpCanvas");
                var go1 = GameObject.Instantiate(go, e.view.IViewControllerInstance.HpUiTransform);
                e.AddHPUi(go1);
                
                go1.transform.Find("Slider").GetComponent<Slider>().maxValue = e.hP.value;
                go1.transform.Find("Slider").GetComponent<Slider>().direction=Slider.Direction.RightToLeft;
                //Debug.Log(go.transform.Find("Slider").GetComponent<Slider>().maxValue);
                //go.transform.Find("Slider").GetComponent<Slider>().gameObject.transform.position =e.view.IViewControllerInstance.Position;

                // var slider=go.gameObject.transform.Find("Slider");
                // slider.transform.position = Camera.main.WorldToScreenPoint(e.view.IViewControllerInstance.Position);
            }
            
            
            
        }
    }
}