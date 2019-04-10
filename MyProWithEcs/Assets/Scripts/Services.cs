
public class Services
{
    public readonly IViewService View;
    public readonly IInputService inputService;
    public readonly IHudTextService hudService;
    public Services(IViewService view,IInputService input,IHudTextService hud)
    {
        View = view;
        inputService = input;
        hudService = hud;
    }
}
