using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public float maxLife;
    public float life;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Damage(float damage)
    {

        life -= damage;

        if(life <= 0)
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }
}
