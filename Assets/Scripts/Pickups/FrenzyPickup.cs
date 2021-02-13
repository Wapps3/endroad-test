using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenzyPickup : BasePickup
{
    //0.1f = 10% increased damage
    public float damageBoost;
    //0.1f = 10% increased fire rate
    public float fireRateBoost;
    //0.1f = 10% increased speed
    public float speedBoost;

    protected override void Bonus(GameObject player)
    {
        player.GetComponent<ShootController>().TemporaryUpgradeDamage(damageBoost, lifeTime);
        player.GetComponent<ShootController>().TemporaryUpgradeFireRate(fireRateBoost, lifeTime);
        player.GetComponent<AirCraftControls>().TemporaryUpgradeSpeed(speedBoost, lifeTime);
    }
}
