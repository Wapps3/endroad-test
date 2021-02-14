using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float maxFireRate;
    private float lastFireTime = 0;
    private float bonusFireRate = 1;

    public GameObject bulletPrefab;

    public GameObject fisrtWeapon;
    public float damageFirstWeapon;

    public GameObject secondWeapon;
    public float damageSecondWeapon;

    private float bonusDamage = 1;
    private float bonusSpeedBullet = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastFireTime = maxFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        lastFireTime += Time.deltaTime;

        if (Input.GetButton("Fire"))
        {
            if(lastFireTime >= maxFireRate * bonusFireRate)
            {
                GameObject bullet = Instantiate(bulletPrefab, fisrtWeapon.gameObject.transform.position, fisrtWeapon.gameObject.transform.rotation);
                bullet.GetComponent<Bullet>().AddBonusDamage(damageFirstWeapon, bonusDamage);
                bullet.GetComponent<Bullet>().AddSpeed(bonusSpeedBullet);

                bullet = Instantiate(bulletPrefab, secondWeapon.gameObject.transform.position, secondWeapon.gameObject.transform.rotation);
                bullet.GetComponent<Bullet>().AddBonusDamage(damageSecondWeapon, bonusDamage);
                bullet.GetComponent<Bullet>().AddSpeed(bonusSpeedBullet);

                lastFireTime = 0;
            }
        }
    }

    public void TemporaryUpgradeDamage(float damage, float time)
    {
        bonusDamage += damage;

        StartCoroutine(RemoveAddDamage(damage,time));
    }

    IEnumerator RemoveAddDamage(float damage,float time)
    {
        yield return new WaitForSeconds(time);

        bonusDamage -= damage;
    }

    public void TemporaryUpgradeFireRate(float fireRate, float time)
    {
        bonusFireRate -= fireRate;

        StartCoroutine(RemoveAddFireRate(fireRate, time));
    }

    IEnumerator RemoveAddFireRate(float fireRate, float time)
    {
        yield return new WaitForSeconds(time);

        bonusFireRate += fireRate;
    }

    public void UpgradeDamage(float damageBonus)
    {
        damageFirstWeapon += damageBonus;
        damageSecondWeapon += damageBonus;
    }

    public void UpgradeFireRate(float fireRateBonus)
    {
        maxFireRate -= fireRateBonus;
    }

    public void UpgradeBulletSpeed(float speedBonus)
    {
        bonusSpeedBullet += speedBonus;
    }
}
