
public class Services
{
    public readonly IViewService View;
    public readonly IInputService inputService;
    public readonly IHudTextService hudService;
    public readonly IPhysicService PhysicService;
    public Services(IViewService view,IInputService input,IHudTextService hud,IPhysicService physic)
    {
        View = view;
        inputService = input;
        hudService = hud;
        PhysicService = physic;
    }
}
