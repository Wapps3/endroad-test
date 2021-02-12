using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyStatManager : StatManager
{
    [Range(0.0f, 1.0f)]
    public float spawnFrequency;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetSpawnFrequency()
    {
        return spawnFrequency;
    }
}
