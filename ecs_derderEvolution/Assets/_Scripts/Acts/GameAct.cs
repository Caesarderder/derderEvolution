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
        // �첽����SubScene
        var loadSceneAsync = SceneManager.LoadSceneAsync(subScene.SceneAsset.name, LoadSceneMode.Additive);
        //while ( !loadSceneAsync.isDone )
        //{
        //    await new WaitForEndOfFrame();
        //}

        //// ��ȡ���غ�ĳ���
        //Scene loadedScene = SceneManager.GetSceneByName(subScene.SceneAsset.name);

        //// ȷ�������Ѽ��ز�������Ч��
        //if ( loadedScene.isLoaded )
        //{
        //    // ��ȡ�����е�ʵ�������
        //    World world = World.DefaultGameObjectInjectionWorld;
        //    EntityManager entityManager = world.EntityManager;

        //    // ���������е�����ʵ��
        //    foreach ( var entity in loadedScene.GetRootGameObjects() )
        //    {
        //        // �����������߼���ʵ�������޸�ʵ��
        //        // ���磬����Ը���ʵ������ƶ�����һ��λ��
        //        // ע�⣺ֱ��ʵ����ECSʵ����ʵ����GameObject��ͬ����Ҫʹ��ECS�ض���API
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
