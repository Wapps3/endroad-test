using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateBoostPickup : BasePickup
{
    //0.1f = 10% increased fire rate
    public float fireRateBoost;

    protected override void Bonus(GameObject player)
    {
        player.GetComponent<ShootController>().TemporaryUpgradeFireRate(fireRateBoost, lifeTime);
    }
}
