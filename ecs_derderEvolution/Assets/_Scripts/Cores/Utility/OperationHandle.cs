using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class OperationHandle<T>where T:class
{
    private Dictionary<string, AsyncOperationHandle<T>> dic_loadingOps = new(); 

    public async Task<T> Load(string address)
    {
        AsyncOperationHandle<T> handle;
        // 防止重复加载
        if ( !dic_loadingOps.ContainsKey(address) )
        {
            // 使用Addressables异步加载GameObject
            handle = Addressables.LoadAssetAsync<T>(address);
            dic_loadingOps.Add(address, handle);
        }
        else
            handle = dic_loadingOps[address];
        await handle.Task;

        if(handle.Status==AsyncOperationStatus.Succeeded)
        {
            return handle.Result;
        }
        else
        {
            UnLoad(address);
            Debug.LogError($"Failed to load  {typeof(T).Name} {address} via Addressables.");
            return null;
        }
    }

    public void UnLoad(string address)
    {
        if ( dic_loadingOps.ContainsKey(address) )
        {
            // 卸载Addressables资源
            Addressables.Release(dic_loadingOps[address]);
            dic_loadingOps.Remove(address);
        }
    }

    public void UnLoadAll()
    {
        foreach ( var handle in dic_loadingOps)
        {
            Addressables.Release(handle.Value); 
            dic_loadingOps.Remove(handle.Key);
        }
    }
}