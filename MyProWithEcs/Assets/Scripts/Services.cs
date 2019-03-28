
public class Services
{
    public readonly IViewService View;
    public readonly IInputService inputService;
    public Services(IViewService view,IInputService input)
    {
        View = view;
        inputService = input;
    }
}
