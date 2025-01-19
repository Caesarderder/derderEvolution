using System;
using UnityEngine;

namespace Assets._Scripts.Models.World
{
    [Serializable]
    public class WorldPropertyConfig
    {
        public int WorldSeed;

        public WorldPropertyConfig()
        {
            WorldSeed = UnityEngine.Random.Range(0,int.MaxValue);
        }
    }
}
