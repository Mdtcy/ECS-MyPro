//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly FaceRightComponent faceRightComponent = new FaceRightComponent();

    public bool isFaceRight {
        get { return HasComponent(GameComponentsLookup.FaceRight); }
        set {
            if (value != isFaceRight) {
                var index = GameComponentsLookup.FaceRight;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : faceRightComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherFaceRight;

    public static Entitas.IMatcher<GameEntity> FaceRight {
        get {
            if (_matcherFaceRight == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FaceRight);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFaceRight = matcher;
            }

            return _matcherFaceRight;
        }
    }
}
