using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickup : MonoBehaviour
{
    public int playerLayer;
    public float lifeTime;

    [Range(0.0f, 1.0f)]
    public float spawnFrequency;

    public float speedRotation;
    public float xRotation;
    public float zRotation;
    public float yRotation;

    //Create to avoid double pick up when the aircraft move so fast it have time to collide with different element
    private bool alreadyPickUp = false;

    // Update is called once per frame
    void Update()
    {
        float rotation = Time.deltaTime * speedRotation;

        gameObject.transform.Rotate(xRotation * rotation, yRotation * rotation, zRotation * rotation, Space.World);;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (alreadyPickUp)
            return;

        if(collision.gameObject.layer == playerLayer)
        {
            alreadyPickUp = true;

            Debug.Log("Collision: " + collision.gameObject.name);

            Bonus(collision.gameObject);
            Destroy(gameObject);
        }
    }

    protected virtual void Bonus(GameObject player)
    {

    }

    public float GetSpawnFrequency()
    {
        return spawnFrequency;
    }
}
