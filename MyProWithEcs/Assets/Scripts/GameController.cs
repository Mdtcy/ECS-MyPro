

using UnityEngine;
using Entitas;
public class GameController : MonoBehaviour
{
    //public GameSetup gameSetUp;
    Systems _systems;


    void Start()
    {

        var contexts = Contexts.sharedInstance;





        //var entity = contexts.game.CreateEntity();
        //entity.AddGameSetUp(gameSetUp);
        //和下面这句一样
        //contexts.game.SetGameSetup(gameSetUp);
       // contexts.input.SetInput(0f, 0f);
        //contexts.input.SetJumpButton(false);

        _systems = CreateSystems(contexts);
        
        
        _systems.Initialize();
    }

    void Update()
    {

        _systems.Execute();

        _systems.Cleanup();
    }
    private static Systems CreateSystems(Contexts contexts)
    {
        var _services = new Services(new UnityViewService(),new UnityInputService());// responsible for creating gameobjects for views
                                                                                     //new UnityApplicationService(), // gives app functionality like .Quit()
                                                                                     // new UnityTimeService(), // gives .deltaTime, .fixedDeltaTime etc
                                                                                     //new InControlInputService(), // provides user input
                                                                                     // next two are monobehaviours attached to gamecontroller
                                                                                     //    GetComponent<UnityAiService>(), // async steering calculations on MB
                                                                                     // GetComponent<UnityConfigurationService>(), // editor accessable global config
                                                                                     //  new UnityCameraService(), // camera bounds, zoom, fov, orthsize etc
                                                                                     //  new UnityPhysicsService() // raycast, checkcircle, checksphere etc. );


        return new Feature("Systems")
           .Add(new ServiceRegistrationSystems(contexts, _services))//第一个注册
           .Add(new GameEventSystems(contexts))//事件监听系统，在其中添加新的子系统监听控件
           .Add(new InputSystems(contexts))

            .Add(new AddViewSystem(contexts))
            .Add(new IntializePlayerSystem(contexts))
            .Add(new ControSystems(contexts));
    }
}