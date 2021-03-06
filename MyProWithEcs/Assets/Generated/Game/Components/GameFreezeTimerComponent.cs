//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FreezeTimerComponent freezeTimer { get { return (FreezeTimerComponent)GetComponent(GameComponentsLookup.FreezeTimer); } }
    public bool hasFreezeTimer { get { return HasComponent(GameComponentsLookup.FreezeTimer); } }

    public void AddFreezeTimer(float newValue) {
        var index = GameComponentsLookup.FreezeTimer;
        var component = (FreezeTimerComponent)CreateComponent(index, typeof(FreezeTimerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFreezeTimer(float newValue) {
        var index = GameComponentsLookup.FreezeTimer;
        var component = (FreezeTimerComponent)CreateComponent(index, typeof(FreezeTimerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFreezeTimer() {
        RemoveComponent(GameComponentsLookup.FreezeTimer);
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

    static Entitas.IMatcher<GameEntity> _matcherFreezeTimer;

    public static Entitas.IMatcher<GameEntity> FreezeTimer {
        get {
            if (_matcherFreezeTimer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FreezeTimer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFreezeTimer = matcher;
            }

            return _matcherFreezeTimer;
        }
    }
}
