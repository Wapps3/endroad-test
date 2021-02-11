using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public float maxLife;
    private float currentLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Damage(float damage)
    {
        currentLife -= damage;

        if(currentLife <= 0)
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }
}
