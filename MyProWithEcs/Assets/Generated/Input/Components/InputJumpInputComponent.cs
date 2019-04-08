//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity jumpInputEntity { get { return GetGroup(InputMatcher.JumpInput).GetSingleEntity(); } }

    public bool isJumpInput {
        get { return jumpInputEntity != null; }
        set {
            var entity = jumpInputEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isJumpInput = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly JumpInputComponent jumpInputComponent = new JumpInputComponent();

    public bool isJumpInput {
        get { return HasComponent(InputComponentsLookup.JumpInput); }
        set {
            if (value != isJumpInput) {
                var index = InputComponentsLookup.JumpInput;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : jumpInputComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherJumpInput;

    public static Entitas.IMatcher<InputEntity> JumpInput {
        get {
            if (_matcherJumpInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.JumpInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherJumpInput = matcher;
            }

            return _matcherJumpInput;
        }
    }
}