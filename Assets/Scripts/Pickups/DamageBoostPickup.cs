using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoostPickup : BasePickup
{
    //0.1f = 10% increased damage
    public float damageBoost;

    protected override void Bonus(GameObject player)
    {
        player.GetComponent<ShootController>().TemporaryUpgradeDamage(damageBoost, lifeTime);
    }
}
