using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float maxFireRate;
    private float lastFireTime = 0;

    public GameObject bulletPrefab;

    public GameObject fisrtWeapon;
    public GameObject secondWeapon;


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
            if(lastFireTime >= maxFireRate)
            {
                Instantiate(bulletPrefab, fisrtWeapon.gameObject.transform.position, fisrtWeapon.gameObject.transform.rotation);
                Instantiate(bulletPrefab, secondWeapon.gameObject.transform.position, secondWeapon.gameObject.transform.rotation);

                lastFireTime = 0;
            }
        }
    }
}
