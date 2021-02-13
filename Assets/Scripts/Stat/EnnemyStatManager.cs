using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyStatManager : StatManager
{
    [Range(0.0f, 1.0f)]
    public float spawnFrequency;

    public float GetSpawnFrequency()
    {
        return spawnFrequency;
    }
}
