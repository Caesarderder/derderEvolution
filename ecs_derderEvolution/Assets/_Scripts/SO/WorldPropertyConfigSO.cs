using Assets._Scripts.Models.World;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldPropertyConfigSO", menuName = "Scriptable Objects/WorldPropertyConfigSO")]
public class WorldPropertyConfigSO : ScriptableObject
{
    [SerializeField]
    public List<WorldPropertyConfig> Configs=new();

    public WorldPropertyConfig GetByIndex(int index)
    {
        if(Configs is { Count:0} )
        {
            Configs.Add(new WorldPropertyConfig());
        }

        if(index<=0)index = 0;
        if(index>=Configs.Count)index = Configs.Count-1;

        return Configs[index];
    }
}


