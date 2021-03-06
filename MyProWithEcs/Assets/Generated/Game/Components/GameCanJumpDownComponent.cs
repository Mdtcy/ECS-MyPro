//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly CanJumpDownComponent canJumpDownComponent = new CanJumpDownComponent();

    public bool isCanJumpDown {
        get { return HasComponent(GameComponentsLookup.CanJumpDown); }
        set {
            if (value != isCanJumpDown) {
                var index = GameComponentsLookup.CanJumpDown;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : canJumpDownComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherCanJumpDown;

    public static Entitas.IMatcher<GameEntity> CanJumpDown {
        get {
            if (_matcherCanJumpDown == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CanJumpDown);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCanJumpDown = matcher;
            }

            return _matcherCanJumpDown;
        }
    }
}
