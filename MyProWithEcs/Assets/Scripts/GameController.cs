

using UnityEngine;
using Entitas;
public class GameController : MonoBehaviour
{
    public GameSetup gameSetUp;
    Systems _systems;


    void Start()
    {

        var contexts = Contexts.sharedInstance;

        //var entity = contexts.game.CreateEntity();
        //entity.AddGameSetUp(gameSetUp);
        //和下面这句一样
        contexts.meta.ReplaceGameSetup(gameSetUp);
        
        contexts.meta.ReplaceEnemyFindDistance(5,10);
        contexts.meta.ReplaceEnemyCanAttackDistance(2);
        
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
        var _services = new Services(new UnityViewService(),new UnityInputService());
        // responsible for creating gameobjects for views
        //new UnityApplicationService(), // gives app functionality like .Quit()
       // new UnityTimeService(), // gives .deltaTime, .fixedDeltaTime etc
       //new InControlInputService(), // provides user input
        // next two are monobehaviours attached to gamecontroller
        //    GetComponent<UnityAiService>(), // async steering calculations on MB
       // GetComponent<UnityConfigurationService>(), // editor accessable global config
        //  new UnityCameraService(), // camera bounds, zoom, fov, orthsize etc
         //  new UnityPhysicsService() // raycast, checkcircle, checksphere etc. );


         return new Feature("Systems")
             .Add(new ServiceRegistrationSystems(contexts, _services)) //第一个注册

             .Add(new AddViewSystem(contexts))
             .Add(new GameEventSystems(contexts)) //事件监听系统，在其中添加新的子系统监听控件
             .Add(new InputSystem(contexts,_services.inputService))
             //.Add(new InputSystems(contexts))

             .Add(new IntializeSnakeSystem(contexts))
             .Add(new IntializePlayerSystem(contexts))
             //.Add(new HPUiSystem(contexts))
             .Add(new HPUiSystem(contexts))//Hp HpUi //prefab上的HpUitransform子物体 需要单独设置
             .Add(new TimerSystem(contexts))

             //安排新系统时注意冲突情况
             .Add(new EnemyAiSystem(contexts)) // FindPlayer Direction Attack     //enemy view 
             
             
             //.Add(new HorizontalMoveTSystem(contexts))//direction //moving speed
             //.Add(new AttackStopSystem(contexts))
             .Add(new PlayerControSystem(contexts))
             .Add(new VelocityXSystem(contexts))
             .Add(new JumpTSystem(contexts))//Jump
             
             .Add(new AttackSystem(contexts))  //attack timer moving  //相关但不对它进行操作的 attackSpeed
             .Add(new DmageSystem(contexts)); //damage,hp


    }
}