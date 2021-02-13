using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraftControls : MonoBehaviour
{
    public float speed;
    public float acceleration;

    private float speedBonus = 1f;

    public float rotationSpeed;

    public float tiltForceAngle;
    public float maxAngleRotation;
    public float angleResetTilt;

    public float timeToRotate;
    private float currentTimeRotating = 0;

    private float currentSignHorizontalInput = 0;
    private float lastSignHorizontalInput = 0;

    //public float acceleration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lastSignHorizontalInput = currentSignHorizontalInput;
        currentSignHorizontalInput = Mathf.Sign(Input.GetAxis("Horizontal"));

        gameObject.transform.position += gameObject.transform.forward * (speed* speedBonus) * Time.deltaTime;

        if (Input.GetButton("Horizontal"))
        {
            if (currentTimeRotating + Time.deltaTime > timeToRotate)
                currentTimeRotating = timeToRotate;
            else
                currentTimeRotating += Time.deltaTime;

            AddTilt(-tiltForceAngle * currentSignHorizontalInput);
            gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime * currentSignHorizontalInput * CalculateAccelerationRatio(), 0, Space.World);
        }
        else
        {
            if (currentTimeRotating - Time.deltaTime < 0)
                currentTimeRotating = 0;
            else
                currentTimeRotating -= Time.deltaTime;

            ResetTilt();

            lastSignHorizontalInput = 0;
            currentSignHorizontalInput = 0;

            currentTimeRotating -= Time.deltaTime;
        }

        if (lastSignHorizontalInput != currentSignHorizontalInput)
        {
            currentTimeRotating = 0;
        }

    }

    float CalculateAccelerationRatio()
    {
        float ratio = currentTimeRotating / timeToRotate;

        if (ratio >= 1)
            return 1;
        else
            return ratio;
    }

    void AddTilt(float degree)
    {
        Vector3 eulerAngles = gameObject.transform.rotation.eulerAngles;

        float angleZ = eulerAngles.z + (degree * CalculateAccelerationRatio() * acceleration * Time.deltaTime );
        
        if (Mathf.Sign(degree) > 0)
        {
            if (angleZ > maxAngleRotation)
                angleZ = maxAngleRotation;
        }
        else
        {
            if(angleZ < 360 - maxAngleRotation)
                angleZ = 360 - maxAngleRotation;
        }
        
       

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(eulerAngles.x, eulerAngles.y, angleZ));
    }

    void ResetTilt()
    {
        Vector3 eulerAngles = gameObject.transform.rotation.eulerAngles;

        float angleZ = 0;

        if ( eulerAngles.z > 270 )
            angleZ = eulerAngles.z + (angleResetTilt * Time.deltaTime);
        else if( eulerAngles.z > 180 )
            angleZ = eulerAngles.z - (angleResetTilt * Time.deltaTime);
        else if( eulerAngles.z > 90 )
            angleZ = eulerAngles.z + (angleResetTilt * Time.deltaTime);
        else
            angleZ = eulerAngles.z - (angleResetTilt * Time.deltaTime);

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(eulerAngles.x, eulerAngles.y, angleZ));
    }

    public void TemporaryUpgradeSpeed(float speed, float time)
    {
        speedBonus += speed;

        StartCoroutine(RemoveAddSpeed(speed, time));
    }

    IEnumerator RemoveAddSpeed(float speed, float time)
    {
        yield return new WaitForSeconds(time);

        speedBonus -= speed;
    }
}
