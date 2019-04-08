//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity verticalEntity { get { return GetGroup(InputMatcher.Vertical).GetSingleEntity(); } }
    public VerticalComponent vertical { get { return verticalEntity.vertical; } }
    public bool hasVertical { get { return verticalEntity != null; } }

    public InputEntity SetVertical(float newValue) {
        if (hasVertical) {
            throw new Entitas.EntitasException("Could not set Vertical!\n" + this + " already has an entity with VerticalComponent!",
                "You should check if the context already has a verticalEntity before setting it or use context.ReplaceVertical().");
        }
        var entity = CreateEntity();
        entity.AddVertical(newValue);
        return entity;
    }

    public void ReplaceVertical(float newValue) {
        var entity = verticalEntity;
        if (entity == null) {
            entity = SetVertical(newValue);
        } else {
            entity.ReplaceVertical(newValue);
        }
    }

    public void RemoveVertical() {
        verticalEntity.Destroy();
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

    public VerticalComponent vertical { get { return (VerticalComponent)GetComponent(InputComponentsLookup.Vertical); } }
    public bool hasVertical { get { return HasComponent(InputComponentsLookup.Vertical); } }

    public void AddVertical(float newValue) {
        var index = InputComponentsLookup.Vertical;
        var component = (VerticalComponent)CreateComponent(index, typeof(VerticalComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceVertical(float newValue) {
        var index = InputComponentsLookup.Vertical;
        var component = (VerticalComponent)CreateComponent(index, typeof(VerticalComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveVertical() {
        RemoveComponent(InputComponentsLookup.Vertical);
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

    static Entitas.IMatcher<InputEntity> _matcherVertical;

    public static Entitas.IMatcher<InputEntity> Vertical {
        get {
            if (_matcherVertical == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Vertical);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherVertical = matcher;
            }

            return _matcherVertical;
        }
    }
}