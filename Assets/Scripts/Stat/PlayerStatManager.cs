using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : StatManager
{
    public List<float> fireRateUpgrade;
    private int fireRateLevel = 0;

    public List<float> damageUpgrade;
    private int damageLevel = 0;

    public List<float> bulletSpeedUpgrade;
    private int bulletSpeedLevel = 0;

    void Start()
    {
        UpgradeDamage();
    }

    public bool fireRateCanBeUpgrade()
    {
        if (fireRateLevel < fireRateUpgrade.Count)
            return true;
        else
            return false;
    }

    public bool damageCanBeUpgrade()
    {
        if (damageLevel < damageUpgrade.Count)
            return true;
        else
            return false;
    }

    public bool bulletSpeedCanBeUpgrade()
    {
        if (bulletSpeedLevel < bulletSpeedUpgrade.Count)
            return true;
        else
            return false;
    }

    public void UpgradeFireRate()
    {
        if( fireRateCanBeUpgrade())
        {
            fireRateLevel++;
            gameObject.GetComponent<ShootController>().UpgradeFireRate(fireRateUpgrade[fireRateLevel]);
        }
    }

    public void UpgradeDamage()
    {
        if ( damageCanBeUpgrade() )
        {
            damageLevel++;
            gameObject.GetComponent<ShootController>().UpgradeDamage(damageUpgrade[damageLevel]);
        }
    }

    public void UpgradeBulletSpeed()
    {
        if ( bulletSpeedCanBeUpgrade() )
        {
            bulletSpeedLevel++;
            gameObject.GetComponent<ShootController>().UpgradeBulletSpeed(bulletSpeedUpgrade[bulletSpeedLevel]);
        }
    }
}
