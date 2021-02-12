using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    public float speed;

    public float damage;

    public float timeBetweenDamage;
    private float lastTimeDamage = 0;

    public int playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastTimeDamage += Time.deltaTime;

        Vector3 target = FindPlayerPosition();

        Vector3 direction = Vector3.Normalize(target - gameObject.transform.position);

        gameObject.transform.position += direction * speed * Time.deltaTime;
        
    }

    Vector3 FindPlayerPosition()
    {
        return FindObjectOfType<AirCraftControls>().transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == playerLayer)
        {
            if (lastTimeDamage > timeBetweenDamage)
            {
                if (collision.gameObject.GetComponent<StatManager>())
                {
                    //Damage to the player
                    collision.gameObject.GetComponent<StatManager>().Damage(damage);

                    //Self Damage
                    gameObject.GetComponent<StatManager>().Damage(damage);

                    //Reset attack timer
                    lastTimeDamage = 0;
                }
            }
        }
    }
}
