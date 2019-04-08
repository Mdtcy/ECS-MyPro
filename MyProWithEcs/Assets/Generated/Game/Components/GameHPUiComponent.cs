//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HPUiComponent hPUi { get { return (HPUiComponent)GetComponent(GameComponentsLookup.HPUi); } }
    public bool hasHPUi { get { return HasComponent(GameComponentsLookup.HPUi); } }

    public void AddHPUi(UnityEngine.GameObject newCanvas) {
        var index = GameComponentsLookup.HPUi;
        var component = (HPUiComponent)CreateComponent(index, typeof(HPUiComponent));
        component.canvas = newCanvas;
        AddComponent(index, component);
    }

    public void ReplaceHPUi(UnityEngine.GameObject newCanvas) {
        var index = GameComponentsLookup.HPUi;
        var component = (HPUiComponent)CreateComponent(index, typeof(HPUiComponent));
        component.canvas = newCanvas;
        ReplaceComponent(index, component);
    }

    public void RemoveHPUi() {
        RemoveComponent(GameComponentsLookup.HPUi);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHPUi;

    public static Entitas.IMatcher<GameEntity> HPUi {
        get {
            if (_matcherHPUi == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HPUi);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHPUi = matcher;
            }

            return _matcherHPUi;
        }
    }
}
