using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public float damage;

    public int playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
            Destroy(gameObject);

        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != playerLayer)
        {
            if (collision.gameObject.GetComponent<StatManager>())
            {
                collision.gameObject.GetComponent<StatManager>().Damage(damage);
            }

            Destroy(gameObject);
        }
    }
}
