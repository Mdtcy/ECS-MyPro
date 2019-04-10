public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        Add(new RegisterViewServiceSystem(contexts, services.View));
        //Add(new RegisterTimeServiceSystem(contexts, services.Time));
       // Add(new RegisterApplicationServiceSystem(contexts, services.Application));
        Add(new RegisterInputServiceSystem(contexts, services.inputService));
        Add(new RegisterHudServiceServiceSystem(contexts, services.hudService));
        //Add(new RegisterAiServiceSystem(contexts, services.Ai));
        //Add(new RegisterConfigurationServiceSystem(contexts, services.Config));
        // Add(new RegisterCameraServiceSystem(contexts, services.Camera));
        //Add(new RegisterPhysicsServiceSystem(contexts, services.Physics));
        // Add(new ServiceRegistrationCompleteSystem(contexts));
    }
}