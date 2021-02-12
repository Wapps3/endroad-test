using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float frequency;
    public float timeDivergente;

    private float lastTimeSpawn = 1;
    private float nextTimeSpawn = 0;

    public List<GameObject> ennemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lastTimeSpawn += Time.deltaTime;

        if (lastTimeSpawn > nextTimeSpawn)
        {
            SpawnEnnemy();

            lastTimeSpawn = 0;
            nextTimeSpawn = frequency + Random.Range(-timeDivergente, timeDivergente);
        }
    }

    void SpawnEnnemy()
    {
        float totalFrequency = 0f;

        foreach(GameObject ennemy in ennemies)
        {
            totalFrequency += ennemy.GetComponent<EnnemyStatManager>().GetSpawnFrequency();
        }

        float random = Random.Range(0.0f, 1.0f);
        float passFrequency = 0.0f;

        foreach (GameObject ennemy in ennemies)
        {
            if ( passFrequency + (ennemy.GetComponent<EnnemyStatManager>().GetSpawnFrequency() / totalFrequency) >= random)
            {
                Instantiate(ennemy, new Vector3(Random.Range(-200f,200f), 0, 500), Quaternion.identity);
                return;
            }
            else
            {
                passFrequency += (ennemy.GetComponent<EnnemyStatManager>().GetSpawnFrequency() / totalFrequency);
            }
        }
    }
}
