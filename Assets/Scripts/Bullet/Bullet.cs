using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public float damage;
    private float bonusDamage = 0;

    public int playerLayer;

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
                collision.gameObject.GetComponent<StatManager>().Damage(damage * bonusDamage);
            }

            Destroy(gameObject);
        }
    }

    public void AddBonusDamage(float weaponDamage, float bonusDamage)
    {
        damage += weaponDamage;
        this.bonusDamage += bonusDamage;
    }
}
