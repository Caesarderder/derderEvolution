using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;
using Unity.Scenes;
using Unity.Entities.Serialization;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

public class ResManager
{
    #region Fields 亻尔 女子
    public static readonly string CWPlayer="CWPlayer";

    public static MonoManager MonoManager;

    OperationHandle<GameObject> _handlesGos=new();
    OperationHandle<SubScene> _handlesSubScenes=new();

    Dictionary<string,AsyncOperation> _handles=new();

    #endregion

    #region Methods
    public async Task Init()
    {
        MonoManager=await LoadGo<MonoManager>("MonoManager");
        GameObject.DontDestroyOnLoad(MonoManager.gameObject);
    }

    public async Task<T> LoadGo<T>(string address,Transform parent,Vector3 pos) where T : MonoBehaviour
    {
        var go=await _handlesGos.Load(address);

        if ( go != null )
        {
            GameObject loadedGameObject = GameObject.Instantiate(go,pos,go.transform.rotation,parent);
            var mono= loadedGameObject.GetComponent<T>();
            if ( mono != null )
            {
                return mono;
            }
        }
        Debug.LogError($"Failed to load  go {address} via Addressables.");
        return default;
    }
    public async Task<T> LoadGo<T>(string address,Transform parent) where T : MonoBehaviour
    {
        var go=await _handlesGos.Load(address); 
        if ( go != null )
        {
            GameObject loadedGameObject = GameObject.Instantiate(go,parent);
            var mono= loadedGameObject.GetComponent<T>();
            if ( mono != null )
            {
                return mono;
            }
        }
        Debug.LogError($"Failed to load  go {address} via Addressables.");
        return default;
    }
    /// <summary>
    /// 使用Addressable加载GameObject
    /// </summary>
    public async Task<T> LoadGo<T>(string address) where T : MonoBehaviour
    {
        var go=await _handlesGos.Load(address); 
        if ( go != null )
        {
            GameObject loadedGameObject = GameObject.Instantiate(go);
            var mono= loadedGameObject.GetComponent<T>();
            if ( mono != null )
            {
                return mono;
            }
        }
        Debug.LogError($"Failed to load  go {address} via Addressables.");
        return default;
    }

    /// <summary>
    /// 删除GameObject并释放指定的GameObject资源
    /// </summary>
    public void DestoryGo(GameObject go,string address)
    {
        if ( go != null )
        {
            UnityEngine.GameObject.Destroy(go);
        }
        _handlesGos.UnLoad(address);
    }

    public async Task LoadScene(string address)
    {
        AsyncOperation handle;
        if(_handles.ContainsKey(address))
        {
            handle= _handles[address];
        }
        else
        {
            handle = SceneManager.LoadSceneAsync(address, LoadSceneMode.Additive);
        }    
        await handle;
    }
    public void UnloadScene(string address)
    {
        if(_handles.ContainsKey(address))
        {
            Addressables.Release(_handles[address]);
            SceneManager.UnloadSceneAsync(address);
        }
    }

    #endregion
}

