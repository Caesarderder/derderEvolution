using System.Threading.Tasks;
using Unity.Entities;
using Unity.Scenes;
using UnityEngine.SceneManagement;
using UnityEngine;
public class GameAct : ActBase
{
   public SubScene subScene;
    public override async Task OnLoad()
    {
        _=base.OnLoad();

        //LoadAndInstantiateSubScene(subScene);
        await Manager<ResManager>.Inst.LoadScene("WorldScene");
    }

    public override async void OnLoaded()
    {
        base.OnLoaded();
    }

    async void LoadAndInstantiateSubScene(SubScene subScene)
    {
        // 异步加载SubScene
        var loadSceneAsync = SceneManager.LoadSceneAsync(subScene.SceneAsset.name, LoadSceneMode.Additive);
        //while ( !loadSceneAsync.isDone )
        //{
        //    await new WaitForEndOfFrame();
        //}

        //// 获取加载后的场景
        //Scene loadedScene = SceneManager.GetSceneByName(subScene.SceneAsset.name);

        //// 确保场景已加载并且是有效的
        //if ( loadedScene.isLoaded )
        //{
        //    // 获取场景中的实体管理器
        //    World world = World.DefaultGameObjectInjectionWorld;
        //    EntityManager entityManager = world.EntityManager;

        //    // 遍历场景中的所有实体
        //    foreach ( var entity in loadedScene.GetRootGameObjects() )
        //    {
        //        // 这里可以添加逻辑来实例化或修改实体
        //        // 例如，你可以复制实体或将其移动到另一个位置
        //        // 注意：直接实例化ECS实体与实例化GameObject不同，需要使用ECS特定的API
        //    }
        //}
    }

    public override void OnUnload()
    {
        base.OnUnload();
        Manager<UIManager>.Inst.DestroyUI<HomePanel>();
    }

    public override void OnUnloaded()
    {
        base.OnUnloaded();
    }
}
