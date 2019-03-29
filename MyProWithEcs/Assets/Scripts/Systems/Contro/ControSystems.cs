using Entitas;

public class ControSystems : Feature
{
    //can change base inside string 
    public ControSystems(Contexts contexts) : base("ControSystems Systems")
    {
        
        Add(new JumpTSystem(contexts));
        Add(new HorizontalMoveTSystem(contexts));
    }
}