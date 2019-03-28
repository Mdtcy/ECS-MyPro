using Entitas;

public class InputSystems : Feature
{
    //can change base inside string 
    public InputSystems(Contexts contexts) : base("InputSystems Systems")
    {
        //Add(new InputSystem(contexts));
        Add(new HorizontalInputSystem(contexts));
        Add(new JumpInputSystem(contexts));
    }
}