using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float frequency;
    public float timeInterval;

    public float distanceFromPlayer;
    public float distanceInterval;

    public float angleSpawn;

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
            nextTimeSpawn = frequency + Random.Range(-timeInterval, timeInterval);
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
                Transform playerTransform = FindObjectOfType<AirCraftControls>().transform;

                float dist = distanceFromPlayer + Random.Range(-distanceInterval, distanceInterval);

                GameObject tmpGameObject = new GameObject();
                tmpGameObject.transform.position = playerTransform.position;
                tmpGameObject.transform.rotation = playerTransform.rotation;
                Vector3 eulerAgnles = tmpGameObject.transform.rotation.eulerAngles;
                tmpGameObject.transform.rotation = Quaternion.Euler(eulerAgnles.x, eulerAgnles.y + Random.Range(-angleSpawn, angleSpawn), eulerAgnles.z);

                Vector3 randomDirection = tmpGameObject.transform.forward;

                Vector3 positionToSpawn = playerTransform.position + (randomDirection * dist) ;

                Destroy(tmpGameObject);

                Instantiate(ennemy, positionToSpawn, Quaternion.identity);

                return;
            }
            else
            {
                passFrequency += (ennemy.GetComponent<EnnemyStatManager>().GetSpawnFrequency() / totalFrequency);
            }
        }
    }
}
