using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraftControls : MonoBehaviour
{
    public float speed;

    public float rotationSpeed;

    public float maxAngleRotation;

    public float timeToRotate;
    private float currentTimeRotating = 0;
    private int lastSignHorizontalInput;

    //public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float signHorizontal = Mathf.Sign(Input.GetAxis("Horizontal"));

        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;

        if(Input.GetButton("Horizontal"))
        {
            Vector3 eulerAngles = gameObject.transform.rotation.eulerAngles;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(eulerAngles.x, eulerAngles.y, -45 * signHorizontal));

            gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime * signHorizontal, 0, Space.World);
        }
        else
        {

        }

        
    }
}
