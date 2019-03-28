//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HorizontalComponent horizontal { get { return (HorizontalComponent)GetComponent(GameComponentsLookup.Horizontal); } }
    public bool hasHorizontal { get { return HasComponent(GameComponentsLookup.Horizontal); } }

    public void AddHorizontal(float newValue) {
        var index = GameComponentsLookup.Horizontal;
        var component = (HorizontalComponent)CreateComponent(index, typeof(HorizontalComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHorizontal(float newValue) {
        var index = GameComponentsLookup.Horizontal;
        var component = (HorizontalComponent)CreateComponent(index, typeof(HorizontalComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHorizontal() {
        RemoveComponent(GameComponentsLookup.Horizontal);
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

    static Entitas.IMatcher<GameEntity> _matcherHorizontal;

    public static Entitas.IMatcher<GameEntity> Horizontal {
        get {
            if (_matcherHorizontal == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Horizontal);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHorizontal = matcher;
            }

            return _matcherHorizontal;
        }
    }
}
