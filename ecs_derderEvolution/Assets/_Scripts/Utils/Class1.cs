using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;

namespace Assets._Scripts.Utils
{
    public static class PerlinNoiseUtility
    {
        public static float[,] Generate2DNoiseWithSeed(int seed, int2 size, int noiseScale = 1, bool UseOctaves = true, int octaves = 4)
        {
            float[,] floats = new float[size.x, size.y];
            NoiseS3D.seed = seed;

            for ( int x = 0; x < size.x; x++ )
            {
                for ( int y = 0; y < size.y; y++ )
                {
                    float noiseValue = 0;

                    if ( UseOctaves )
                    {
                        NoiseS3D.octaves = octaves;
                        noiseValue = (float) NoiseS3D.NoiseCombinedOctaves(x * noiseScale, y * noiseScale);
                    }
                    else
                    {
                        noiseValue = (float) NoiseS3D.Noise(x * noiseScale, y * noiseScale);
                    }

                    //remap the value to 0 - 1 for color purposes
                    noiseValue = ( noiseValue + 1 ) * 0.5f;
                }
            }
            return floats;


        }
    }
}
