using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lerpSpeed;

    public Transform objectToFollow;

    [Range(0f,2*Mathf.PI)]
    public float cameraPitch;
    public float cameraDistance;

    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        float distY = Mathf.Sin(cameraPitch) * cameraDistance;
        float distZ = Mathf.Cos(cameraPitch) * cameraDistance;

        offset.x = (distZ * -objectToFollow.forward).x;
        offset.y = distY;
        offset.z = (distZ * -objectToFollow.forward).z;

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, objectToFollow.position + offset, Time.deltaTime * lerpSpeed);


        float rotationAngleX = gameObject.transform.rotation.eulerAngles.x;

        float rotationAngleY = objectToFollow.rotation.eulerAngles.y; // objectToFollow.rotation.eulerAngles.y;

        float rotationAngleZ = gameObject.transform.rotation.eulerAngles.z;

        gameObject.transform.rotation = Quaternion.Euler(rotationAngleX, rotationAngleY, rotationAngleZ);
    }
}
